using Linkly.Dialogs;
using Linkly.Services;
using Button = System.Windows.Forms.Button;
using MenuItem = Linkly.Models.MenuItem;

namespace Linkly
{
    public partial class LinkSettingsForm : Form
    {
        /// <summary>
        /// The Public Boolean value tracking if any changes have been made to the configuration.
        /// </summary>
        public bool HasChanges = false;

        /// <summary>
        /// The file services instance used for file operations.
        /// </summary>
        private FileServices fileServices = new FileServices();

        /// <summary>
        /// The ListViewImage List
        /// </summary>
        private ImageList listViewImages = new ImageList();

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkSettingsForm"/> class.
        /// </summary>
        public LinkSettingsForm()
        {
            InitializeComponent();

            this.ButtonToolTip.SetToolTip(this.MoveUpButton, "Move Selected Menu Item Up");
            this.ButtonToolTip.SetToolTip(this.MoveDownButton, "Move Selected Menu Item Down");
            this.ButtonToolTip.SetToolTip(this.SaveButton, "Save + Apply Changes & Close");
            this.ButtonToolTip.SetToolTip(this.CancelFormButton, "Cancel Changes & Close");
            this.ButtonToolTip.SetToolTip(this.NewButton, "Create a new Link, Header, Separator or Leaf");
            this.ButtonToolTip.SetToolTip(this.EditButton, "Edit Selected Menu Item");
            this.ButtonToolTip.SetToolTip(this.DeleteButton, "Delete Selected Menu Item");

            listViewImages.ImageSize = new Size(16, 16); // small icons, adjust as needed
            listViewImages.ColorDepth = ColorDepth.Depth32Bit; // supports transparency
            listViewImages.Images.Add("LinkIcon", Properties.Resources.linkly_icon_512x512);
            listViewImages.Images.Add("HeaderIcon", Properties.Resources.header);
            listViewImages.Images.Add("SeparatorIcon", Properties.Resources.separator);
            listViewImages.Images.Add("LeafIcon", Properties.Resources.Leaf);

            // Assign to the ListView - SmallImageList is used in Details/List view
            this.LinksListView.SmallImageList = listViewImages;
        }

        #region Button Click Events

        /// <summary>
        /// The Form Load Method for the LinkSettingsForm.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void LinkSettingsForm_Load(object sender, EventArgs e)
        {
            this.LinksListView.Columns.Add("Type");
            this.LinksListView.Columns.Add("Name");
            this.LinksListView.Columns.Add("Browser");
            this.LinksListView.Columns.Add("NewWindow?");
            this.LinksListView.Columns.Add("InCognito?");
            this.LinksListView.Columns.Add("LaunchOnStartup?");
            this.LinksListView.Columns.Add("Url");
            this.LinksListView.Columns.Add("Url Params");

            var configuration = this.fileServices.LoadConfigurationFromFile();

            if (configuration != null && configuration.Count > 0)
            {
                for (int i = 0; i < configuration.Count; i++)
                {
                    var config = configuration[i];
                    AddNewListViewItem(config);
                }
            }

            this.LinksListView.Columns[0].Width = 80;
            this.LinksListView.Columns[1].Width = 275;
            this.LinksListView.Columns[2].Width = 70;
            this.LinksListView.Columns[3].Width = 85;
            this.LinksListView.Columns[4].Width = 70;
            this.LinksListView.Columns[5].Width = 110;
            this.LinksListView.Columns[6].Width = 275;
            this.LinksListView.Columns[7].Width = 70;
        }

        /// <summary>
        /// The Save Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            var shouldCloseWindow = true;

            if (this.HasChanges)
            {
                var configuration = new List<MenuItem>();
                foreach (ListViewItem item in this.LinksListView.Items)
                {
                    var config = (MenuItem)item.Tag;
                    if (config != null)
                    {
                        configuration.Add(config);
                    }

                }

                // Only close the Window after changes are made, if the configuration was successfully saved to file.
                shouldCloseWindow = this.fileServices.SaveConfigurationToFile(configuration);
            }

            if (shouldCloseWindow)
            {
                this.Close();
            }
        }

        /// <summary>
        /// The Cancel Form Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void CancelFormButton_Click(object sender, EventArgs e)
        {
            // Set the HasChanges Property to false, to ensure we ignore any changes made on cancelling the form.
            this.HasChanges = false;
            this.Close();
        }

        /// <summary>
        /// The New Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void NewButton_Click(object sender, EventArgs e)
        {
            Button newButton = (Button)sender;

            // Position the menu at the bottom-left corner of the button
            Point menuLocation = new Point(0, 0);

            this.newItemButtonContextMenuStrip.Show(newButton, menuLocation);
        }

        /// <summary>
        /// The Edit Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (this.LinksListView.SelectedItems != null &&
                this.LinksListView.SelectedItems.Count == 1)
            {
                var itemToEdit = this.LinksListView.SelectedItems[0];
                MenuItem config = (MenuItem)itemToEdit.Tag;
                if (config != null)
                {
                    switch (config.MenuItemType)
                    {
                        case MenuItemType.Header:
                        case MenuItemType.Leaf:
                            {
                                // Prompt the user for the name of the new Header Menu Item Type
                                var inputDialog = new InputDialog($"Re-Enter the {config.MenuItemType} Item Text",
                                                                  $"Please enter a new name for the '{config.Name}' {config.MenuItemType} Menu Item:");

                                if (inputDialog.ShowDialog() == DialogResult.OK)
                                {
                                    // Update the Selected Header Name
                                    config.Name = inputDialog.OutputTextValue;
                                    itemToEdit.SubItems[1].Text = config.Name;
                                    itemToEdit.Tag = config;
                                    this.HasChanges = true;
                                }

                                break;
                            }
                        case MenuItemType.Link:
                            {
                                // Prompt the user with the new Link Configuration Dialog
                                using (var newLinkDialog = new LinkDetailsSettingsForm(config))
                                {
                                    if (newLinkDialog.ShowDialog() == DialogResult.OK)
                                    {
                                        // Update the MenuItem Model and re-assign to the ListViewItem Tag field.
                                        config = newLinkDialog.OutputMenuItem;
                                        itemToEdit.Tag = config;

                                        // Update the ListViewItem Column Text
                                        var hasUrlParams = config.LinkOptions?.ParamReplacementsDic?.Count > 0;
                                        itemToEdit.SubItems[1].Text = config.Name;
                                        itemToEdit.SubItems[2].Text = config.LinkOptions.Browser.ToString();
                                        itemToEdit.SubItems[3].Text = config.LinkOptions.IsNewWindow.ToString();
                                        itemToEdit.SubItems[4].Text = config.LinkOptions.IsIncognito.ToString();
                                        itemToEdit.SubItems[5].Text = config.LinkOptions.LaunchOnStartup.ToString();
                                        itemToEdit.SubItems[6].Text = config.LinkOptions.Url;
                                        itemToEdit.SubItems[7].Text = hasUrlParams.ToString();
                                        this.HasChanges = true;
                                    }
                                }

                                break;
                            }
                    }
                }
            }
        }

        /// <summary>
        /// The Delete Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var lastIndex = 0;

            if (this.LinksListView.SelectedItems != null &&
                this.LinksListView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this.LinksListView.SelectedItems)
                {
                    lastIndex = item.Index;
                    item.Remove();
                }

                // Re-Select the item with the index one less than the final item that was deleted.
                lastIndex--;
                if (lastIndex <= this.LinksListView.Items.Count - 1)
                {
                    this.LinksListView.SelectedItems.Clear();
                    this.LinksListView.Items[lastIndex].Selected = true;
                    this.LinksListView.Items[lastIndex].Focused = true;
                    this.LinksListView.Items[lastIndex].EnsureVisible();
                    this.LinksListView.Select();
                }

                this.HasChanges = true;
            }
        }

        /// <summary>
        /// The Move Up Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            if (this.LinksListView.SelectedItems != null &&
                this.LinksListView.SelectedItems.Count > 0)
            {
                // Cast to a typed list and sort by current index, ascending.
                var selectedItems = this.LinksListView.SelectedItems
                    .Cast<ListViewItem>()
                    .OrderBy(item => item.Index)
                    .ToList();

                // Bypass if the topmost selected item is already at the top -
                // moving it up would result in a negative index.
                if (selectedItems[0].Index == 0)
                {
                    this.LinksListView.Select();
                    return;
                }

                this.LinksListView.BeginUpdate();

                // Process items in ascending index order. Since ListViewItem.Index
                // always reflects the item's *current* live position, moving the
                // lowest-indexed item first (and working upward) keeps every
                // subsequent item's Index accurate for its own move - no manual
                // offset tracking needed, even with non-consecutive selections.
                foreach (var item in selectedItems)
                {
                    var currentIndex = item.Index;
                    item.Remove();
                    this.LinksListView.Items.Insert(currentIndex - 1, item);
                }

                // Re-select the moved items so the selection follows them.
                this.LinksListView.SelectedItems.Clear();
                foreach (var item in selectedItems)
                {
                    item.Selected = true;
                    item.Focused = true;
                    item.EnsureVisible();
                }

                this.LinksListView.Select();
                this.LinksListView.EndUpdate();
                this.HasChanges = true;
            }
        }

        /// <summary>
        /// The Move Down Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            if (this.LinksListView.SelectedItems != null &&
                this.LinksListView.SelectedItems.Count > 0)
            {
                // Cast to a typed list and sort by current index, descending.
                var selectedItems = this.LinksListView.SelectedItems
                    .Cast<ListViewItem>()
                    .OrderByDescending(item => item.Index)
                    .ToList();

                // Bypass if the bottommost selected item is already at the end -
                // moving it down would push it past the last valid index.
                if (selectedItems[0].Index == this.LinksListView.Items.Count - 1)
                {
                    this.LinksListView.Select();
                    return;
                }

                this.LinksListView.BeginUpdate();

                // Process items in descending index order. Since ListViewItem.Index
                // always reflects the item's *current* live position, moving the
                // highest-indexed item first (and working downward) keeps every
                // subsequent item's Index accurate for its own move - no manual
                // offset tracking needed, even with non-consecutive selections.
                foreach (var item in selectedItems)
                {
                    var currentIndex = item.Index;
                    item.Remove();
                    this.LinksListView.Items.Insert(currentIndex + 1, item);
                }

                // Re-select the moved items so the selection follows them.
                this.LinksListView.SelectedItems.Clear();
                foreach (var item in selectedItems)
                {
                    item.Selected = true;
                    item.Focused = true;
                    item.EnsureVisible();
                }

                this.LinksListView.Select();
                this.LinksListView.EndUpdate();
                this.HasChanges = true;
            }
        }

        #endregion

        #region LinksListView Context Menu Item Click Events

        /// <summary>
        /// The Duplicate Item(s) Context Menu Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.LinksListView.SelectedItems != null &&
                this.LinksListView.SelectedItems.Count > 0)
            {
                // Sort selected items by current index, ascending. Processing in
                // this order lets us rely on each item's live Index property,
                // since inserting a clone after an earlier item automatically
                // shifts every item below it - no manual offset tracking needed.
                var selectedItems = this.LinksListView.SelectedItems
                    .Cast<ListViewItem>()
                    .OrderBy(item => item.Index)
                    .ToList();

                this.LinksListView.BeginUpdate();

                var duplicatedItems = new List<ListViewItem>();

                foreach (var sourceItem in selectedItems)
                {
                    // Clone the ListViewItem (text, subitems, formatting, etc.)
                    var newItem = (ListViewItem)sourceItem.Clone();

                    // Deep-copy the underlying MenuItem stored in Tag, rather
                    // than letting the clone share a reference to the original.
                    if (sourceItem.Tag is MenuItem sourceMenuItem)
                    {
                        newItem.Tag = sourceMenuItem.Clone();
                    }

                    // Re-query the source item's current index right before
                    // inserting - earlier insertions in this loop may have
                    // already shifted it down from its original position.
                    int insertIndex = sourceItem.Index + 1;
                    this.LinksListView.Items.Insert(insertIndex, newItem);

                    duplicatedItems.Add(newItem);
                }

                // Select the newly duplicated items so the user sees the result.
                this.LinksListView.SelectedItems.Clear();
                foreach (var newItem in duplicatedItems)
                {
                    newItem.Selected = true;
                }

                this.LinksListView.EndUpdate();
                this.HasChanges = true;
            }
        }

        /// <summary>
        /// The Move Item(s) Up Context Menu Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void moveItemsUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MoveUpButton_Click(this, new EventArgs());
        }

        /// <summary>
        /// The Move Item(s) Down Context Menu Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void moveItemsDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MoveDownButton_Click(this, new EventArgs());
        }

        #endregion

        #region New Button ConextMenuStrip Item Click Events

        /// <summary>
        /// New Link Context Menu Item Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void linkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Prompt the user with the new Link Configuration Dialog
            using (var newLinkDialog = new LinkDetailsSettingsForm())
            {
                if (newLinkDialog.ShowDialog() == DialogResult.OK)
                {
                    // Add the new link to the ListView Control.
                    AddNewListViewItem(newLinkDialog.OutputMenuItem);
                    this.HasChanges = true;
                }
            }
        }

        /// <summary>
        /// New Header Context Menu Item Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void headerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Prompt the user for the name of the new Header Menu Item Type
            var inputDialog = new InputDialog("Enter the Header Item Text",
                                              "Please enter a name for the new Header Menu Item:");

            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                // Create the Configuration Menu Item
                var config = new MenuItem
                {
                    MenuItemType = MenuItemType.Header,
                    Name = inputDialog.OutputTextValue,
                    ImageFileName = "header.png"
                };

                AddNewListViewItem(config);
                this.HasChanges = true;
            }
        }

        /// <summary>
        /// New Separator Context Menu Item Click Event Method 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void separatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var config = new MenuItem
            {
                MenuItemType = MenuItemType.Separator,
                Name = "Separator"
            };

            AddNewListViewItem(config);
            this.HasChanges = true;
        }

        /// <summary>
        /// New Leaf Node Context Menu Item Click Event Method 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void leafToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Prompt the user for the name of the new Header Menu Item Type
            var inputDialog = new InputDialog("Enter the Leaf Item Text",
                                              "Please enter a name for the new Leaf Item:");

            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                // Create the Configuration Menu Item
                var config = new MenuItem
                {
                    MenuItemType = MenuItemType.Leaf,
                    Name = inputDialog.OutputTextValue,
                    ImageFileName = "Leaf.png"
                };

                AddNewListViewItem(config);
                this.HasChanges = true;
            }
        }

        #endregion

        #region ListView Grid Form Control Events

        /// <summary>
        /// The LinksListView Double Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void LinksListView_DoubleClick(object sender, EventArgs e)
        {
            this.EditButton_Click(this.EditButton, new EventArgs());
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and Adds a new ListViewItem to the Grid, based on the provided MenuItem Model.
        /// </summary>
        /// <param name="config">The MenuItem Configuration Model</param>
        private void AddNewListViewItem(MenuItem config)
        {
            if (config != null)
            {
                var hasUrlParams = config.LinkOptions?.ParamReplacementsDic?.Count > 0;

                // Create the new ListView Item
                var item = new ListViewItem(config.MenuItemType.ToString());
                item.SubItems.Add(config.Name);
                item.SubItems.Add(config.LinkOptions?.Browser.ToString());
                item.SubItems.Add(config.LinkOptions?.IsNewWindow.ToString());
                item.SubItems.Add(config.LinkOptions?.IsIncognito.ToString());
                item.SubItems.Add(config.LinkOptions?.LaunchOnStartup.ToString());
                item.SubItems.Add(config.LinkOptions?.Url);
                item.SubItems.Add(hasUrlParams.ToString());
                item.Tag = config;
                item.ImageKey = $"{config.MenuItemType.ToString()}Icon";

                switch (config.MenuItemType)
                {
                    case MenuItemType.Separator:
                        item.BackColor = Color.LightGray;
                        break;
                    case MenuItemType.Header:
                        item.BackColor = Color.FromArgb(206, 193, 230); // 35% Lighter than 'Dusty Lavender' (#CEC1E6)
                        break;
                    case MenuItemType.Link:
                        item.BackColor = Color.AliceBlue;
                        break;
                    case MenuItemType.Leaf:
                        item.BackColor = Color.FromArgb(200, 224, 200); // #C8E0C8 - Muted, Slightly deeper, Sage Green
                        break;
                }

                // Add the new ListViewItem to the bottom of the Grid
                this.LinksListView.Items.Add(item);
            }
        }

        #endregion
    }
}
