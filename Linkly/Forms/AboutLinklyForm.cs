using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        /// The Close Button Click Event Method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
