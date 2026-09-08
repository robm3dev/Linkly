using Linkly.Services;
using System.Diagnostics;

namespace Linkly.Forms
{
    public partial class PreferencesForm : Form
    {
        /// <summary>
        /// The WindowsSettingsService instance used to manage Windows startup settings for the application.
        /// </summary>
        private readonly WindowsSettingsService _windowsSettingsService = new WindowsSettingsService();

        /// <summary>
        /// A constant string representing the unique name of the application for Windows startup registration.
        /// </summary>
        private const string StartupAppName = "Linkly";

        /// <summary>
        /// The Public Class Constructor for the PreferencesForm class.
        /// </summary>
        public PreferencesForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The Form Load Event Method for the PreferencesForm class.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void PreferencesForm_Load(object sender, EventArgs e)
        {
            /* Set the checkbox to reflect whether Linkly is currently registered to launch at Windows startup. */
            this.StartLinklyWhenWindowsStartsCheckBox.Checked = _windowsSettingsService.IsRegisteredForStartup(StartupAppName);
        }

        /// <summary>
        /// The CheckedChanged event handler for the StartLinklyWhenWindowsStartsCheckBox.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void StartLinklyWhenWindowsStartsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            /* Set or remove Linkly from Windows startup based on the checkbox state. */
            if (this.StartLinklyWhenWindowsStartsCheckBox.Checked)
            {
                _windowsSettingsService.AddToWindowsStartup(StartupAppName);
            }
            else
            {
                _windowsSettingsService.RemoveFromWindowsStartup(StartupAppName);
            }
        }

        /// <summary>
        /// The Open Taskbar Settings Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void OpenTaskBarSettingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("ms-settings:taskbar")
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Unable to open Taskbar Settings: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// The Close Form Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void CloseFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
