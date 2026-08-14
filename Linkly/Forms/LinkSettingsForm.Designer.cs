namespace Linkly
{
    partial class LinkSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinkSettingsForm));
            LinksListView = new ListView();
            HyperlinkConfigGroupBox = new GroupBox();
            panel1 = new Panel();
            MoveDownButton = new Button();
            MoveUpButton = new Button();
            DeleteButton = new Button();
            NewButton = new Button();
            EditButton = new Button();
            CancelFormButton = new Button();
            SaveButton = new Button();
            newItemButtonContextMenuStrip = new ContextMenuStrip(components);
            linkToolStripMenuItem = new ToolStripMenuItem();
            headerToolStripMenuItem = new ToolStripMenuItem();
            separatorToolStripMenuItem = new ToolStripMenuItem();
            ButtonToolTip = new ToolTip(components);
            HyperlinkConfigGroupBox.SuspendLayout();
            panel1.SuspendLayout();
            newItemButtonContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // LinksListView
            // 
            LinksListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LinksListView.FullRowSelect = true;
            LinksListView.GridLines = true;
            LinksListView.Location = new Point(19, 22);
            LinksListView.Name = "LinksListView";
            LinksListView.Size = new Size(924, 362);
            LinksListView.TabIndex = 0;
            LinksListView.UseCompatibleStateImageBehavior = false;
            LinksListView.View = View.Details;
            // 
            // HyperlinkConfigGroupBox
            // 
            HyperlinkConfigGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            HyperlinkConfigGroupBox.Controls.Add(panel1);
            HyperlinkConfigGroupBox.Controls.Add(DeleteButton);
            HyperlinkConfigGroupBox.Controls.Add(NewButton);
            HyperlinkConfigGroupBox.Controls.Add(EditButton);
            HyperlinkConfigGroupBox.Controls.Add(LinksListView);
            HyperlinkConfigGroupBox.Location = new Point(13, 12);
            HyperlinkConfigGroupBox.Name = "HyperlinkConfigGroupBox";
            HyperlinkConfigGroupBox.Size = new Size(971, 431);
            HyperlinkConfigGroupBox.TabIndex = 2;
            HyperlinkConfigGroupBox.TabStop = false;
            HyperlinkConfigGroupBox.Text = "Context Menu Items";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(MoveDownButton);
            panel1.Controls.Add(MoveUpButton);
            panel1.Location = new Point(941, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(24, 362);
            panel1.TabIndex = 6;
            // 
            // MoveDownButton
            // 
            MoveDownButton.Image = Properties.Resources.Arrow_Down_Blue_32x32;
            MoveDownButton.Location = new Point(0, 306);
            MoveDownButton.Name = "MoveDownButton";
            MoveDownButton.Size = new Size(24, 56);
            MoveDownButton.TabIndex = 4;
            MoveDownButton.TextImageRelation = TextImageRelation.ImageAboveText;
            MoveDownButton.UseVisualStyleBackColor = true;
            MoveDownButton.Click += MoveDownButton_Click;
            // 
            // MoveUpButton
            // 
            MoveUpButton.Image = Properties.Resources.Arrow_Up_Blue_32x32;
            MoveUpButton.Location = new Point(0, 0);
            MoveUpButton.Name = "MoveUpButton";
            MoveUpButton.Size = new Size(24, 54);
            MoveUpButton.TabIndex = 3;
            MoveUpButton.TextImageRelation = TextImageRelation.ImageAboveText;
            MoveUpButton.UseVisualStyleBackColor = true;
            MoveUpButton.Click += MoveUpButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DeleteButton.Image = Properties.Resources.Delete_16x16;
            DeleteButton.ImageAlign = ContentAlignment.MiddleLeft;
            DeleteButton.Location = new Point(181, 390);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 35);
            DeleteButton.TabIndex = 5;
            DeleteButton.Text = "   Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // NewButton
            // 
            NewButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            NewButton.Image = Properties.Resources.Add_16x16;
            NewButton.ImageAlign = ContentAlignment.MiddleLeft;
            NewButton.Location = new Point(19, 390);
            NewButton.Name = "NewButton";
            NewButton.Size = new Size(75, 35);
            NewButton.TabIndex = 2;
            NewButton.Text = "   New";
            NewButton.UseVisualStyleBackColor = true;
            NewButton.Click += NewButton_Click;
            // 
            // EditButton
            // 
            EditButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            EditButton.Image = Properties.Resources.Edit_16x16;
            EditButton.ImageAlign = ContentAlignment.MiddleLeft;
            EditButton.Location = new Point(100, 390);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(75, 35);
            EditButton.TabIndex = 1;
            EditButton.Text = "  Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // CancelFormButton
            // 
            CancelFormButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            CancelFormButton.Image = Properties.Resources.Block_16x16;
            CancelFormButton.ImageAlign = ContentAlignment.MiddleLeft;
            CancelFormButton.Location = new Point(151, 449);
            CancelFormButton.Name = "CancelFormButton";
            CancelFormButton.Size = new Size(94, 31);
            CancelFormButton.TabIndex = 3;
            CancelFormButton.Text = "  Cancel";
            CancelFormButton.UseVisualStyleBackColor = true;
            CancelFormButton.Click += CancelFormButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            SaveButton.Image = Properties.Resources.Save_16x16;
            SaveButton.ImageAlign = ContentAlignment.MiddleLeft;
            SaveButton.Location = new Point(13, 449);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(132, 31);
            SaveButton.TabIndex = 4;
            SaveButton.Text = "   Save &&  Apply";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // newItemButtonContextMenuStrip
            // 
            newItemButtonContextMenuStrip.Items.AddRange(new ToolStripItem[] { linkToolStripMenuItem, headerToolStripMenuItem, separatorToolStripMenuItem });
            newItemButtonContextMenuStrip.Name = "newItemButtonContextMenuStrip";
            newItemButtonContextMenuStrip.Size = new Size(125, 70);
            // 
            // linkToolStripMenuItem
            // 
            linkToolStripMenuItem.AutoToolTip = true;
            linkToolStripMenuItem.Image = Properties.Resources.linkly_icon_512x512;
            linkToolStripMenuItem.Name = "linkToolStripMenuItem";
            linkToolStripMenuItem.Size = new Size(124, 22);
            linkToolStripMenuItem.Text = "Link";
            linkToolStripMenuItem.Click += linkToolStripMenuItem_Click;
            // 
            // headerToolStripMenuItem
            // 
            headerToolStripMenuItem.Image = Properties.Resources.header;
            headerToolStripMenuItem.Name = "headerToolStripMenuItem";
            headerToolStripMenuItem.Size = new Size(124, 22);
            headerToolStripMenuItem.Text = "Header";
            headerToolStripMenuItem.Click += headerToolStripMenuItem_Click;
            // 
            // separatorToolStripMenuItem
            // 
            separatorToolStripMenuItem.Image = Properties.Resources.separator;
            separatorToolStripMenuItem.Name = "separatorToolStripMenuItem";
            separatorToolStripMenuItem.Size = new Size(124, 22);
            separatorToolStripMenuItem.Text = "Separator";
            separatorToolStripMenuItem.Click += separatorToolStripMenuItem_Click;
            // 
            // LinkSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelFormButton;
            ClientSize = new Size(996, 486);
            Controls.Add(SaveButton);
            Controls.Add(CancelFormButton);
            Controls.Add(HyperlinkConfigGroupBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LinkSettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Linkly Menu Item Configuration";
            Load += LinkSettingsForm_Load;
            HyperlinkConfigGroupBox.ResumeLayout(false);
            panel1.ResumeLayout(false);
            newItemButtonContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView LinksListView;
        private GroupBox HyperlinkConfigGroupBox;
        private Button CancelFormButton;
        private Button SaveButton;
        private Button MoveUpButton;
        private Button NewButton;
        private Button EditButton;
        private Button MoveDownButton;
        private ContextMenuStrip newItemButtonContextMenuStrip;
        private ToolStripMenuItem linkToolStripMenuItem;
        private ToolStripMenuItem headerToolStripMenuItem;
        private ToolStripMenuItem separatorToolStripMenuItem;
        private Button DeleteButton;
        private ToolTip ButtonToolTip;
        private Panel panel1;
    }
}