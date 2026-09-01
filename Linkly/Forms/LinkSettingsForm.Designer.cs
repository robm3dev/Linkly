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
            linksListViewContextMenuStrip = new ContextMenuStrip(components);
            duplicateToolStripMenuItem = new ToolStripMenuItem();
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
            leafToolStripMenuItem = new ToolStripMenuItem();
            ButtonToolTip = new ToolTip(components);
            moveItemsUpToolStripMenuItem = new ToolStripMenuItem();
            moveItemsDownToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            linksListViewContextMenuStrip.SuspendLayout();
            HyperlinkConfigGroupBox.SuspendLayout();
            panel1.SuspendLayout();
            newItemButtonContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // LinksListView
            // 
            LinksListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LinksListView.ContextMenuStrip = linksListViewContextMenuStrip;
            LinksListView.FullRowSelect = true;
            LinksListView.GridLines = true;
            LinksListView.Location = new Point(19, 22);
            LinksListView.Name = "LinksListView";
            LinksListView.Size = new Size(1056, 436);
            LinksListView.TabIndex = 1;
            LinksListView.UseCompatibleStateImageBehavior = false;
            LinksListView.View = View.Details;
            LinksListView.DoubleClick += LinksListView_DoubleClick;
            // 
            // linksListViewContextMenuStrip
            // 
            linksListViewContextMenuStrip.Items.AddRange(new ToolStripItem[] { duplicateToolStripMenuItem, toolStripSeparator1, moveItemsUpToolStripMenuItem, moveItemsDownToolStripMenuItem });
            linksListViewContextMenuStrip.Name = "linksListViewContextMenuStrip";
            linksListViewContextMenuStrip.Size = new Size(181, 98);
            // 
            // duplicateToolStripMenuItem
            // 
            duplicateToolStripMenuItem.Image = Properties.Resources.duplicate_icon_512x512;
            duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            duplicateToolStripMenuItem.Size = new Size(180, 22);
            duplicateToolStripMenuItem.Text = "Duplicate Item(s)";
            duplicateToolStripMenuItem.Click += duplicateToolStripMenuItem_Click;
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
            HyperlinkConfigGroupBox.Size = new Size(1103, 505);
            HyperlinkConfigGroupBox.TabIndex = 0;
            HyperlinkConfigGroupBox.TabStop = false;
            HyperlinkConfigGroupBox.Text = "Context Menu Items";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(MoveDownButton);
            panel1.Controls.Add(MoveUpButton);
            panel1.Location = new Point(1073, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(24, 436);
            panel1.TabIndex = 3;
            // 
            // MoveDownButton
            // 
            MoveDownButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            MoveDownButton.Image = Properties.Resources.Arrow_Down_Blue_32x32;
            MoveDownButton.Location = new Point(0, 380);
            MoveDownButton.Name = "MoveDownButton";
            MoveDownButton.Size = new Size(24, 56);
            MoveDownButton.TabIndex = 4;
            MoveDownButton.TextImageRelation = TextImageRelation.ImageAboveText;
            MoveDownButton.UseVisualStyleBackColor = true;
            MoveDownButton.Click += MoveDownButton_Click;
            // 
            // MoveUpButton
            // 
            MoveUpButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MoveUpButton.Image = Properties.Resources.Arrow_Up_Blue_32x32;
            MoveUpButton.Location = new Point(0, 0);
            MoveUpButton.Name = "MoveUpButton";
            MoveUpButton.Size = new Size(24, 54);
            MoveUpButton.TabIndex = 2;
            MoveUpButton.TextImageRelation = TextImageRelation.ImageAboveText;
            MoveUpButton.UseVisualStyleBackColor = true;
            MoveUpButton.Click += MoveUpButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            DeleteButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DeleteButton.Image = Properties.Resources.Delete_16x16;
            DeleteButton.ImageAlign = ContentAlignment.MiddleLeft;
            DeleteButton.Location = new Point(181, 464);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 35);
            DeleteButton.TabIndex = 7;
            DeleteButton.Text = "   Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // NewButton
            // 
            NewButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            NewButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            NewButton.Image = Properties.Resources.Add_16x16;
            NewButton.ImageAlign = ContentAlignment.MiddleLeft;
            NewButton.Location = new Point(19, 464);
            NewButton.Name = "NewButton";
            NewButton.Size = new Size(75, 35);
            NewButton.TabIndex = 5;
            NewButton.Text = "   New";
            NewButton.UseVisualStyleBackColor = true;
            NewButton.Click += NewButton_Click;
            // 
            // EditButton
            // 
            EditButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            EditButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            EditButton.Image = Properties.Resources.Edit_16x16;
            EditButton.ImageAlign = ContentAlignment.MiddleLeft;
            EditButton.Location = new Point(100, 464);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(75, 35);
            EditButton.TabIndex = 6;
            EditButton.Text = "  Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // CancelFormButton
            // 
            CancelFormButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CancelFormButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            CancelFormButton.Image = Properties.Resources.Block_16x16;
            CancelFormButton.ImageAlign = ContentAlignment.MiddleLeft;
            CancelFormButton.Location = new Point(151, 523);
            CancelFormButton.Name = "CancelFormButton";
            CancelFormButton.Size = new Size(94, 31);
            CancelFormButton.TabIndex = 9;
            CancelFormButton.Text = "  Cancel";
            CancelFormButton.UseVisualStyleBackColor = true;
            CancelFormButton.Click += CancelFormButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SaveButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            SaveButton.Image = Properties.Resources.Save_16x16;
            SaveButton.ImageAlign = ContentAlignment.MiddleLeft;
            SaveButton.Location = new Point(13, 523);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(132, 31);
            SaveButton.TabIndex = 8;
            SaveButton.Text = "   Save &&  Apply";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // newItemButtonContextMenuStrip
            // 
            newItemButtonContextMenuStrip.Items.AddRange(new ToolStripItem[] { linkToolStripMenuItem, headerToolStripMenuItem, separatorToolStripMenuItem, leafToolStripMenuItem });
            newItemButtonContextMenuStrip.Name = "newItemButtonContextMenuStrip";
            newItemButtonContextMenuStrip.Size = new Size(125, 92);
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
            // leafToolStripMenuItem
            // 
            leafToolStripMenuItem.Image = Properties.Resources.Leaf;
            leafToolStripMenuItem.Name = "leafToolStripMenuItem";
            leafToolStripMenuItem.Size = new Size(124, 22);
            leafToolStripMenuItem.Text = "Leaf";
            leafToolStripMenuItem.Click += leafToolStripMenuItem_Click;
            // 
            // moveItemsUpToolStripMenuItem
            // 
            moveItemsUpToolStripMenuItem.Image = Properties.Resources.Arrow_Up_Blue_32x32;
            moveItemsUpToolStripMenuItem.Name = "moveItemsUpToolStripMenuItem";
            moveItemsUpToolStripMenuItem.Size = new Size(180, 22);
            moveItemsUpToolStripMenuItem.Text = "Move Item(s) Up";
            moveItemsUpToolStripMenuItem.Click += moveItemsUpToolStripMenuItem_Click;
            // 
            // moveItemsDownToolStripMenuItem
            // 
            moveItemsDownToolStripMenuItem.Image = Properties.Resources.Arrow_Down_Blue_32x32;
            moveItemsDownToolStripMenuItem.Name = "moveItemsDownToolStripMenuItem";
            moveItemsDownToolStripMenuItem.Size = new Size(180, 22);
            moveItemsDownToolStripMenuItem.Text = "Move Item(s) Down";
            moveItemsDownToolStripMenuItem.Click += moveItemsDownToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // LinkSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelFormButton;
            ClientSize = new Size(1128, 560);
            Controls.Add(SaveButton);
            Controls.Add(CancelFormButton);
            Controls.Add(HyperlinkConfigGroupBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            MinimumSize = new Size(400, 400);
            Name = "LinkSettingsForm";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Linkly Menu Item Configuration";
            Load += LinkSettingsForm_Load;
            linksListViewContextMenuStrip.ResumeLayout(false);
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
        private ToolStripMenuItem leafToolStripMenuItem;
        private ContextMenuStrip linksListViewContextMenuStrip;
        private ToolStripMenuItem duplicateToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem moveItemsUpToolStripMenuItem;
        private ToolStripMenuItem moveItemsDownToolStripMenuItem;
    }
}