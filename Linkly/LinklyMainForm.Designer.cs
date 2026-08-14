namespace Linkly
{
    partial class LinklyMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinklyMainForm));
            MainNotifyIcon = new NotifyIcon(components);
            MainContextMenuStrip = new ContextMenuStrip(components);
            linklyMainToolStripSeparator = new ToolStripSeparator();
            linkSettingsToolStripMenuItem = new ToolStripMenuItem();
            aboutLinklyToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            MainContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MainNotifyIcon
            // 
            MainNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            MainNotifyIcon.BalloonTipText = "Get Yer Links Here!";
            MainNotifyIcon.BalloonTipTitle = "Linkly";
            MainNotifyIcon.ContextMenuStrip = MainContextMenuStrip;
            MainNotifyIcon.Icon = (Icon)resources.GetObject("MainNotifyIcon.Icon");
            MainNotifyIcon.Text = "Linkly";
            MainNotifyIcon.Visible = true;
            // 
            // MainContextMenuStrip
            // 
            MainContextMenuStrip.Items.AddRange(new ToolStripItem[] { linklyMainToolStripSeparator, linkSettingsToolStripMenuItem, aboutLinklyToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            MainContextMenuStrip.Name = "MainContextMenuStrip";
            MainContextMenuStrip.Size = new Size(210, 104);
            // 
            // linklyMainToolStripSeparator
            // 
            linklyMainToolStripSeparator.Name = "linklyMainToolStripSeparator";
            linklyMainToolStripSeparator.Size = new Size(206, 6);
            // 
            // linkSettingsToolStripMenuItem
            // 
            linkSettingsToolStripMenuItem.Image = Properties.Resources.MenuItemConfiguration_512x512;
            linkSettingsToolStripMenuItem.Name = "linkSettingsToolStripMenuItem";
            linkSettingsToolStripMenuItem.Size = new Size(209, 22);
            linkSettingsToolStripMenuItem.Text = "Menu Item Configuration";
            linkSettingsToolStripMenuItem.Click += linkSettingsToolStripMenuItem_Click;
            // 
            // aboutLinklyToolStripMenuItem
            // 
            aboutLinklyToolStripMenuItem.Image = Properties.Resources.linkly_icon_v2_512x512;
            aboutLinklyToolStripMenuItem.Name = "aboutLinklyToolStripMenuItem";
            aboutLinklyToolStripMenuItem.Size = new Size(209, 22);
            aboutLinklyToolStripMenuItem.Text = "About Linkly";
            aboutLinklyToolStripMenuItem.Click += aboutLinklyToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(206, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = Properties.Resources.Exit_512x512;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(209, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // LinklyMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 74);
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "LinklyMainForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "LinklyMainForm";
            WindowState = FormWindowState.Minimized;
            Load += LinklyMainForm_Load;
            MainContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon MainNotifyIcon;
        private ContextMenuStrip MainContextMenuStrip;
        private ToolStripMenuItem linkSettingsToolStripMenuItem;
        private ToolStripSeparator linklyMainToolStripSeparator;
        private ToolStripMenuItem aboutLinklyToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}