using Linkly.Forms;
using Linkly.Models;
using Linkly.Services;
using System.Runtime.CompilerServices;

namespace Linkly
{
    public partial class LinklyMainForm : Form
    {
        public static FileServices FileServices = new FileServices();
        private UiMenuService UiMenuService;

        public LinklyMainForm()
        {
            InitializeComponent();
            this.UiMenuService = new UiMenuService(this.MainContextMenuStrip);
        }

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
                this.UiMenuService.PopulateMenuItemsFromConfiguration(configuration);
            }
        }

        private void linkSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var linkSettingsForm = new LinkSettingsForm();
            linkSettingsForm.FormClosed += LinkSettingsForm_FormClosed;
            linkSettingsForm.Show();
        }

        private void LinkSettingsForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            LinkSettingsForm linkSettingsForm = (LinkSettingsForm)sender;
            if (linkSettingsForm != null && linkSettingsForm.HasChanges)
            {
                this.UiMenuService.PopulateMenuItemsFromConfiguration(FileServices.LoadConfigurationFromFile());
            }
        }

        private void aboutLinklyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var aboutLinklyForm = new AboutLinklyForm())
            {
                aboutLinklyForm.ShowDialog();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
