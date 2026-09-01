using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Linkly.Forms
{
    public partial class AboutLinklyForm : Form
    {
        /// <summary>
        /// The Public Class Constructor
        /// </summary>
        public AboutLinklyForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The Donate Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void DonateButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("https://www.paypal.me/robertmorrison1498/5")
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open the donation page: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// The Close Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// The Form Load Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void AboutLinklyForm_Load(object sender, EventArgs e)
        {
            var appVersion = Assembly.GetExecutingAssembly().GetName().Version;
            this.label1.Text = $"Linkly v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}";
        }


    }
}
