using Linkly.Dialogs;
using Linkly.Services;
using MenuItem = Linkly.Models.MenuItem;

namespace Linkly
{
    public partial class LinkDetailsSettingsForm : Form
    {
        /// <summary>
        /// The EditModeType Property
        /// </summary>
        public EditModeType EditModeType = EditModeType.New;

        /// <summary>
        /// The OutputMenuItem Property
        /// </summary>
        public MenuItem OutputMenuItem;

        /// <summary>
        /// The Public Class Constructor
        /// </summary>
        /// <param name="menuItem">The Nullable MenuItem Configuration Model; Leave null for new link creation, Populate to edit existing link.</param>
        public LinkDetailsSettingsForm(MenuItem? menuItem = null)
        {
            if (menuItem == null)
            {
                this.EditModeType = EditModeType.New;
                this.Name = "Create New Link";
                this.OutputMenuItem = new MenuItem
                {
                    MenuItemType = MenuItemType.Link,
                    LinkOptions = new Models.LinkOptions()
                };
            }
            else
            {
                this.EditModeType = EditModeType.Edit;
                this.Name = "Edit Existing Link";
                this.OutputMenuItem = menuItem;
            }

            InitializeComponent();
        }

        /// <summary>
        /// The Form Load Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void LinkDetailsSettingsForm_Load(object sender, EventArgs e)
        {
            // Populate the Browser Type ComboBox with the possible values
            var browserTypeNames = Enum.GetNames(typeof(BrowserType));
            this.BrowserComboBox.Items.AddRange(browserTypeNames);
            this.BrowserComboBox.SelectedIndex = 0;

            if (this.EditModeType == EditModeType.Edit)
            {
                this.NameTextBox.Text = this.OutputMenuItem.Name;
                this.ImageTextBox.Text = this.OutputMenuItem.ImageFileName;
                this.BrowserComboBox.SelectedIndex = (int)this.OutputMenuItem.LinkOptions.Browser;
                this.IncognitoCheckBox.Checked = this.OutputMenuItem.LinkOptions.IsIncognito;
                this.NewBrowserWindowCheckBox.Checked = this.OutputMenuItem.LinkOptions.IsNewWindow;
                this.UrlTextBox.Text = this.OutputMenuItem.LinkOptions.Url;

                if (this.OutputMenuItem.LinkOptions.ParamReplacementsDic != null &&
                    this.OutputMenuItem.LinkOptions.ParamReplacementsDic.Count > 0)
                {
                    foreach (var kvPair in this.OutputMenuItem.LinkOptions.ParamReplacementsDic)
                    {
                        var listViewItem = new ListViewItem(kvPair.Value);
                        listViewItem.SubItems.Add(kvPair.Key);
                        this.ParamsListView.Items.Add(listViewItem);
                    }
                }
            }
        }

        /// <summary>
        /// The Browse (Icon Image File) Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            // Present the user with a File Open Dialog, to their config directory for icon images
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = FileServices.ConfigDirectoryPath;
                openFileDialog.Filter = "Image Files (*.png;*.bmp;*.jpg;*.jpeg)|*.png;*.bmp;*.jpg;*.jpeg";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Assign the file name (no path) to the ImageTextBox Text Field.
                    this.ImageTextBox.Text = Path.GetFileName(openFileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// The Add Url Parameter Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void AddParamButton_Click(object sender, EventArgs e)
        {
            /* Determine what the placeholder value will be for the new Parameter value,
               based on the items in the ListView */
            var parameterPlaceholderValue = "{" + this.ParamsListView.Items.Count.ToString() + "}";

            /* Ensure the Place Holder Value has been added to the URL, before we allow the user to add the name for it. 
               Note:  This sort of allows the feature to be self-explanatory by the UI design.  It forces the user to add
                      the expected placeholder value to the URL, before ever adding the parameter name. */
            if (this.UrlTextBox.Text.Contains(parameterPlaceholderValue))
            {
                var dialogTitle = "Enter a Parameter Name";
                var promptText = "Please enter a friendly name for the parameter, which will be displayed on the dialog when the user is prompted for the parameter value.";
                using (InputDialog inputDialog = new InputDialog(dialogTitle, promptText))
                {
                    if (inputDialog.ShowDialog() == DialogResult.OK)
                    {
                        var parameterName = inputDialog.OutputTextValue;
                        var listViewItem = new ListViewItem(parameterName);
                        listViewItem.SubItems.Add(parameterPlaceholderValue);
                        this.ParamsListView.Items.Add(listViewItem);
                    }
                }
            }
            else
            {
                /* Prompt the user and inform them to add a placeholder to the URL field,
                   before attempting this action. */
                var message = $"The Link Url field does not yet contain the placeholder value of '{parameterPlaceholderValue}'.  Please add this placeholder text value to the URL field, before adding the Parameter name.";
                var dialogTitle = "URL is missing place holder value.";
                MessageBox.Show(message, dialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The Remove All Url Parameter Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void RemoveAllParamsButton_Click(object sender, EventArgs e)
        {
            this.ParamsListView.Items.Clear();
        }

        /// <summary>
        /// The Save Form Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateFormFields())
            {
                this.OutputMenuItem.MenuItemType = MenuItemType.Link;
                this.OutputMenuItem.Name = this.NameTextBox.Text.Trim();
                this.OutputMenuItem.ImageFileName = this.ImageTextBox.Text.Trim();
                this.OutputMenuItem.LinkOptions.Browser = (BrowserType)this.BrowserComboBox.SelectedIndex;
                this.OutputMenuItem.LinkOptions.Url = this.UrlTextBox.Text.Trim();
                this.OutputMenuItem.LinkOptions.IsIncognito = this.IncognitoCheckBox.Checked;
                this.OutputMenuItem.LinkOptions.IsNewWindow = this.NewBrowserWindowCheckBox.Checked;

                if (this.ParamsListView.Items.Count > 0)
                {
                    this.OutputMenuItem.LinkOptions.ParamReplacementsDic = new Dictionary<string, string>();
                    foreach (ListViewItem item in this.ParamsListView.Items)
                    {
                        this.OutputMenuItem.LinkOptions.ParamReplacementsDic.Add(item.SubItems[0].Text, item.Text);
                    }
                }
                else
                {
                    this.OutputMenuItem.LinkOptions.ParamReplacementsDic = new Dictionary<string, string>();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                var dialogTitle = "Required fields have not been populated!";
                var message = "The required fields for a Link (Name, Url & Browser) have not be populated.  Please either complete the minimum configuration or click the cancel button, instead.";
                MessageBox.Show(message, dialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// The Cancel Form Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void CancelFormButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #region Private Helper Methods

        /// <summary>
        /// Validates that the minimum necessary required fields have been populated to save the link configuration.
        /// </summary>
        /// <returns>Boolean value indicating success or failure of the validation.</returns>
        private bool ValidateFormFields()
        {
            var success = true;

            if (string.IsNullOrWhiteSpace(this.NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(this.UrlTextBox.Text))
            {
                success = false;
            }

            return success;
        }

        #endregion
    }
}
