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
            this.ButtonToolTip.SetToolTip(this.NewButton, "Create a new Link, Header or Separator");
            this.ButtonToolTip.SetToolTip(this.EditButton, "Edit Selected Menu Item");
            this.ButtonToolTip.SetToolTip(this.DeleteButton, "Delete Selected Menu Item");

            listViewImages.ImageSize = new Size(16, 16); // small icons, adjust as needed
            listViewImages.ColorDepth = ColorDepth.Depth32Bit; // supports transparency
            listViewImages.Images.Add("LinkIcon", Properties.Resources.linkly_icon_512x512);
            listViewImages.Images.Add("HeaderIcon", Properties.Resources.header);
            listViewImages.Images.Add("SeparatorIcon", Properties.Resources.separator);

            // Assign to the ListView - SmallImageList is used in Details/List view
            this.LinksListView.SmallImageList = listViewImages;
        }

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
            this.LinksListView.Columns[5].Width = 275;
            this.LinksListView.Columns[6].Width = 70;
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
                            {
                                // Prompt the user for the name of the new Header Menu Item Type
                                var inputDialog = new InputDialog("Re-Enter the Header Item Text",
                                                                  "Please re-enter a new name for the new Header Menu Item:");

                                if (inputDialog.ShowDialog() == DialogResult.OK)
                                {
                                    // Update the Selected Header Name

                                    itemToEdit.Tag = config;
                                    itemToEdit.SubItems[1].Text = inputDialog.OutputTextValue;
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
                                        itemToEdit.SubItems[5].Text = config.LinkOptions.Url;
                                        itemToEdit.SubItems[6].Text = hasUrlParams.ToString();
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
            if (this.LinksListView.SelectedItems != null &&
                this.LinksListView.SelectedItems.Count == 1)
            {
                this.LinksListView.SelectedItems[0].Remove();
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
                this.LinksListView.SelectedItems.Count == 1)
            {
                var index = this.LinksListView.SelectedItems[0].Index;

                // Ensure the Selected Item is not the first item in the list.
                if (index > 0)
                {
                    var selectedItem = this.LinksListView.SelectedItems[0];

                    // Remove the selected item
                    this.LinksListView.SelectedItems[0].Remove();  
                    
                    // Re-Insert the removed item at the 1 minus the previous index.
                    this.LinksListView.Items.Insert(index - 1, selectedItem);
                    this.HasChanges = true;
                }
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
                this.LinksListView.SelectedItems.Count == 1)
            {
                var index = this.LinksListView.SelectedItems[0].Index;

                // Ensure the selection is not the last item in the list.
                if (index < this.LinksListView.Items.Count - 1)
                {
                    var selectedItem = this.LinksListView.SelectedItems[0];

                    // Remove the selected item
                    this.LinksListView.SelectedItems[0].Remove();

                    // Re-Insert the removed item at the 1 plus the previous index.
                    this.LinksListView.Items.Insert(index + 1, selectedItem);
                    this.HasChanges = true;
                }
            }
        }

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
                }

                item.SubItems.Add(config.Name);
                item.SubItems.Add(config.LinkOptions?.Browser.ToString());
                item.SubItems.Add(config.LinkOptions?.IsNewWindow.ToString());
                item.SubItems.Add(config.LinkOptions?.IsIncognito.ToString());
                item.SubItems.Add(config.LinkOptions?.Url);
                item.SubItems.Add(hasUrlParams.ToString());
                item.Tag = config;
                item.ImageKey = $"{config.MenuItemType.ToString()}Icon";

                // Add the new ListViewItem to the bottom of the Grid
                this.LinksListView.Items.Add(item);
            }
        }

        #endregion
    }
}
