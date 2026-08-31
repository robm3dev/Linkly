using Linkly.Models;
using MenuItem = Linkly.Models.MenuItem;

namespace Linkly.Services
{
    public class UiMenuService
    {
        /// <summary>
        /// The MainContextMenuStrip UI Control from the Linkly Main Form
        /// </summary>
        private ContextMenuStrip MainContextMenuStrip;

        /// <summary>
        /// The Public Class Constructor
        /// </summary>
        /// <param name="mainContextMenuStrip">The MainContextMenuStrip UI Control</param>
        public UiMenuService(ContextMenuStrip mainContextMenuStrip) 
        {
            this.MainContextMenuStrip = mainContextMenuStrip;
        }

        /// <summary>
        /// Populates the Linkly MainContextMenuStrip with the Menu Item Types
        /// defined in the Linkly Configuration file.  
        /// Note: This method is idempotent, in that it will check
        /// for and remove any existing configuration context menu items that are already present
        /// in the UI control, before it begins to re-populate the new items passed into this method.
        /// </summary>
        /// <param name="configuration">The List of MenuItem objects de-serialized from the </param>
        public void PopulateMenuItemsFromConfiguration(List<MenuItem> configuration)
        {
            /* Remove all items from the context menu until we are left with only the
               item named linklyMainToolStripSeparator and all static items below it. */
            if (this.MainContextMenuStrip.Items.Count > 0)
            {
                while (this.MainContextMenuStrip.Items[0].Name != "linklyMainToolStripSeparator")
                {
                    this.MainContextMenuStrip.Items.RemoveAt(0);
                }
            }

            // Define variables to identify leaf nodes within the list
            bool isLeafDropDown = false;
            int leafNodeOffSet = 0;
            ToolStripMenuItem currentLeafItem = null;

            /* Populate the items from the Configuration List into the ContextMenuItemStrip,
               as their designated MenuItemType, above all the static Linkly Tool Menu Items. */
            for (int i = 0; i < configuration.Count; i++)
            {
                var config = configuration[i];
                var toolStipMenuItem = new ToolStripMenuItem(config.Name)
                {
                    Tag = config,
                };

                switch (config.MenuItemType)
                {
                    case MenuItemType.Link:
                        {
                            // Set Link Nodes with a Click event handler to open the link embedded on the MenuItem's Tag field.
                            toolStipMenuItem.Click += (sender, eventArgs) =>
                            {
                                BrowserService.OpenBrowser((Models.MenuItem)toolStipMenuItem.Tag);
                            };

                            break;
                        }
                    case MenuItemType.Header:
                        {
                            // Set Header Nodes with a higher font size & bold text.
                            toolStipMenuItem.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            isLeafDropDown = false;
                            break;
                        }
                    case MenuItemType.Separator:
                        {
                            // Create & Add the Separator Node, and continue to the next iteration of the loop.
                            var toolStipSeparator = new ToolStripSeparator();
                            this.MainContextMenuStrip.Items.Insert(i - leafNodeOffSet, toolStipSeparator);
                            isLeafDropDown = false;
                            break;
                        }
                    case MenuItemType.Leaf:
                        {
                            // Set Leaf Nodes with a higher font size & bold text.
                            toolStipMenuItem.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            break;
                        }
                    default:
                        {
                            MessageBox.Show($"Invalid MenuItemType found in configuration: {config.MenuItemType}. The application will now exit.",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            Application.Exit();
                            break;
                        }
                }

                if (config.MenuItemType != MenuItemType.Separator)
                {
                    if (!string.IsNullOrEmpty(config.ImageFileName))
                    {
                        // Set the image for the menu item if an image file name is provided.
                        var imagePathFile = Path.Combine(FileServices.ConfigDirectoryPath, config.ImageFileName);
                        if (File.Exists(imagePathFile))
                        {
                            toolStipMenuItem.Image = Image.FromFile(imagePathFile);
                        }
                    }

                    // Determine if we are adding a standard ToolStripItem node, or a DropDownItem to a Leaf.
                    if (isLeafDropDown)
                    {
                        currentLeafItem.DropDownItems.Add(toolStipMenuItem);
                        leafNodeOffSet++;
                    }
                    else
                    {
                        this.MainContextMenuStrip.Items.Insert(i - leafNodeOffSet, toolStipMenuItem);
                    }
                    
                    if (config.MenuItemType == MenuItemType.Leaf)
                    {
                        // Start a new Leaf Drop Down Menu
                        isLeafDropDown = true;
                        currentLeafItem = toolStipMenuItem;
                    }
                }
            }
        }
    }
}
