using Linkly.Forms;
using Linkly.Services;

namespace Linkly
{
    public partial class LinklyMainForm : Form
    {
        /// <summary>
        /// The FileServices instance used to manage the configuration file and directory for the application.
        /// </summary>
        public static FileServices FileServices = new FileServices();

        /// <summary>
        /// The UiMenuService instance used to manage the context menu items in the application.
        /// </summary>
        private UiMenuService UiMenuService;

        /// <summary>
        /// The LinkSettingsForm Form instance used to manage the conifguration window. 
        /// It is initialized when the user opens the conifguration window and disposed when the window is closed.
        /// </summary>
        private LinkSettingsForm? _linkConfigurationForm;

        /// <summary>
        /// The Preferences Form instance used to manage the preferences window. 
        /// It is initialized when the user opens the preferences window and disposed when the window is closed.
        /// </summary>
        private PreferencesForm? _preferencesForm;

        /// <summary>
        /// The About Linkly Form instance used to manage the about window.
        /// It is initialized when the user opens the about window and disposed when the window is closed.
        /// </summary>
        private AboutLinklyForm? _aboutLinklyForm;

        /// <summary>
        /// The Public Class Constructor for the LinklyMainForm class. 
        /// Initializes the form and sets up the UiMenuService with the MainContextMenuStrip.
        /// </summary>
        public LinklyMainForm()
        {
            InitializeComponent();
            this.UiMenuService = new UiMenuService(this.MainContextMenuStrip);
        }

        /// <summary>
        /// The Form Load Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void LinklyMainForm_Load(object sender, EventArgs e)
        {
            if (!FileServices.CheckForAndCreateConfigDirectory())
            {
                MessageBox.Show("Unable to create the configuration directory. The application will now exit.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                Application.Exit();
            }

            var configuration = FileServices.LoadConfigurationFromFile();

            if (configuration == null || configuration.Count == 0)
            {
                MessageBox.Show("No configuration data found. Please check the settings file or delete it and allow it to be re-generated.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                Application.Exit();
            }
            else
            {
                /* Populate the ContextMenuStrip with the configuration data, 
                   and return a list of any Links that have the IsLaunchOnStartup property set to true. */
                var startupLinks = this.UiMenuService.PopulateMenuItemsFromConfiguration(configuration);

                // Automatically launch all of the Links that have the IsLaunchOnStartup property set to true.
                foreach (var link in startupLinks)
                {
                    BrowserService.OpenBrowser(link, isStartup: true);
                }
            }
        }

        #region The MainContextMenuStrip Event Handlers

        /// <summary>
        /// The Link Configuration Menu Item Click Event Handler.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void linkSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_linkConfigurationForm == null || _linkConfigurationForm.IsDisposed)
            {
                _linkConfigurationForm = new LinkSettingsForm();
                _linkConfigurationForm.FormClosed += LinkSettingsForm_FormClosed;
                _linkConfigurationForm.Show();
            }
            else
            {
                _linkConfigurationForm.Activate();
                _linkConfigurationForm.BringToFront();
            }
        }

        /// <summary>
        /// The Link Settings Form Closed Event Handler.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void LinkSettingsForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (sender is LinkSettingsForm _linkConfigurationForm)
            {
                if (_linkConfigurationForm.HasChanges)
                {
                    this.UiMenuService.PopulateMenuItemsFromConfiguration(FileServices.LoadConfigurationFromFile());
                }

                _linkConfigurationForm = null;
            }
        }

        /// <summary>
        /// The Preferences Menu Item Click Event Handler.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_preferencesForm == null || _preferencesForm.IsDisposed)
            {
                _preferencesForm = new PreferencesForm();
                _preferencesForm.FormClosed += (s, args) => _preferencesForm = null;
                _preferencesForm.Show();
            }
            else
            {
                _preferencesForm.Activate();
                _preferencesForm.BringToFront();
            }
        }

        /// <summary>
        /// The About Linkly Menu Item Click Event Handler.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void aboutLinklyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_aboutLinklyForm == null || _aboutLinklyForm.IsDisposed)
            {
                _aboutLinklyForm = new AboutLinklyForm();
                _aboutLinklyForm.FormClosed += (s, args) => _aboutLinklyForm = null;
                _aboutLinklyForm.Show();
            }
            else
            {
                _aboutLinklyForm.Activate();
                _aboutLinklyForm.BringToFront();
            }
        }

        /// <summary>
        /// The Exit Menu Item Click Event Handler. 
        /// This method is called when the user clicks the "Exit" menu item in the context menu. 
        /// It exits the application.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
