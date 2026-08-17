namespace Linkly
{
    partial class LinkDetailsSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinkDetailsSettingsForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            NameTextBox = new TextBox();
            UrlTextBox = new TextBox();
            BrowserComboBox = new ComboBox();
            ParamsListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            SaveButton = new Button();
            CancelFormButton = new Button();
            label5 = new Label();
            ImageTextBox = new TextBox();
            BrowseButton = new Button();
            NewBrowserWindowCheckBox = new CheckBox();
            IncognitoCheckBox = new CheckBox();
            groupBox1 = new GroupBox();
            RemoveAllParamsButton = new Button();
            AddParamButton = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 33);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 206);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 9;
            label2.Text = "Url:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 107);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 2;
            label3.Text = "Browser:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 246);
            label4.Name = "label4";
            label4.Size = new Size(87, 15);
            label4.TabIndex = 11;
            label4.Text = "Url Parameters:";
            // 
            // NameTextBox
            // 
            NameTextBox.BackColor = SystemColors.Info;
            NameTextBox.BorderStyle = BorderStyle.FixedSingle;
            NameTextBox.Location = new Point(80, 30);
            NameTextBox.MaxLength = 80;
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(557, 23);
            NameTextBox.TabIndex = 2;
            // 
            // UrlTextBox
            // 
            UrlTextBox.BackColor = SystemColors.Info;
            UrlTextBox.BorderStyle = BorderStyle.FixedSingle;
            UrlTextBox.Location = new Point(80, 203);
            UrlTextBox.Name = "UrlTextBox";
            UrlTextBox.Size = new Size(557, 23);
            UrlTextBox.TabIndex = 10;
            // 
            // BrowserComboBox
            // 
            BrowserComboBox.BackColor = SystemColors.Info;
            BrowserComboBox.FormattingEnabled = true;
            BrowserComboBox.Location = new Point(80, 104);
            BrowserComboBox.Name = "BrowserComboBox";
            BrowserComboBox.Size = new Size(557, 23);
            BrowserComboBox.TabIndex = 6;
            // 
            // ParamsListView
            // 
            ParamsListView.BackColor = SystemColors.Info;
            ParamsListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            ParamsListView.FullRowSelect = true;
            ParamsListView.GridLines = true;
            ParamsListView.Location = new Point(114, 246);
            ParamsListView.Name = "ParamsListView";
            ParamsListView.Size = new Size(523, 140);
            ParamsListView.TabIndex = 12;
            ParamsListView.UseCompatibleStateImageBehavior = false;
            ParamsListView.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Param Name";
            columnHeader1.Width = 270;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Param Placeholder Value";
            columnHeader2.Width = 245;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(13, 448);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 15;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelFormButton
            // 
            CancelFormButton.Location = new Point(94, 448);
            CancelFormButton.Name = "CancelFormButton";
            CancelFormButton.Size = new Size(75, 23);
            CancelFormButton.TabIndex = 16;
            CancelFormButton.Text = "Cancel";
            CancelFormButton.UseVisualStyleBackColor = true;
            CancelFormButton.Click += CancelFormButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 69);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 3;
            label5.Text = "Icon";
            // 
            // ImageTextBox
            // 
            ImageTextBox.BackColor = SystemColors.Info;
            ImageTextBox.BorderStyle = BorderStyle.FixedSingle;
            ImageTextBox.Enabled = false;
            ImageTextBox.Location = new Point(80, 66);
            ImageTextBox.Name = "ImageTextBox";
            ImageTextBox.ReadOnly = true;
            ImageTextBox.Size = new Size(476, 23);
            ImageTextBox.TabIndex = 4;
            // 
            // BrowseButton
            // 
            BrowseButton.Location = new Point(562, 66);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(75, 23);
            BrowseButton.TabIndex = 5;
            BrowseButton.Text = "Browse...";
            BrowseButton.UseVisualStyleBackColor = true;
            BrowseButton.Click += BrowseButton_Click;
            // 
            // NewBrowserWindowCheckBox
            // 
            NewBrowserWindowCheckBox.AutoSize = true;
            NewBrowserWindowCheckBox.Location = new Point(257, 169);
            NewBrowserWindowCheckBox.Name = "NewBrowserWindowCheckBox";
            NewBrowserWindowCheckBox.Size = new Size(147, 19);
            NewBrowserWindowCheckBox.TabIndex = 8;
            NewBrowserWindowCheckBox.Text = "New Browser Window?";
            NewBrowserWindowCheckBox.UseVisualStyleBackColor = true;
            // 
            // IncognitoCheckBox
            // 
            IncognitoCheckBox.AutoSize = true;
            IncognitoCheckBox.Location = new Point(257, 145);
            IncognitoCheckBox.Name = "IncognitoCheckBox";
            IncognitoCheckBox.Size = new Size(116, 19);
            IncognitoCheckBox.TabIndex = 7;
            IncognitoCheckBox.Text = "Incognito Mode?";
            IncognitoCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RemoveAllParamsButton);
            groupBox1.Controls.Add(AddParamButton);
            groupBox1.Controls.Add(BrowserComboBox);
            groupBox1.Controls.Add(IncognitoCheckBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(ParamsListView);
            groupBox1.Controls.Add(UrlTextBox);
            groupBox1.Controls.Add(NewBrowserWindowCheckBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(BrowseButton);
            groupBox1.Controls.Add(NameTextBox);
            groupBox1.Controls.Add(ImageTextBox);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(13, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(657, 430);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Link Configuration";
            // 
            // RemoveAllParamsButton
            // 
            RemoveAllParamsButton.Location = new Point(196, 394);
            RemoveAllParamsButton.Name = "RemoveAllParamsButton";
            RemoveAllParamsButton.Size = new Size(75, 23);
            RemoveAllParamsButton.TabIndex = 14;
            RemoveAllParamsButton.Text = "Remove All";
            RemoveAllParamsButton.UseVisualStyleBackColor = true;
            RemoveAllParamsButton.Click += RemoveAllParamsButton_Click;
            // 
            // AddParamButton
            // 
            AddParamButton.Location = new Point(115, 394);
            AddParamButton.Name = "AddParamButton";
            AddParamButton.Size = new Size(75, 23);
            AddParamButton.TabIndex = 13;
            AddParamButton.Text = "Add";
            AddParamButton.UseVisualStyleBackColor = true;
            AddParamButton.Click += AddParamButton_Click;
            // 
            // LinkDetailsSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 482);
            Controls.Add(groupBox1);
            Controls.Add(CancelFormButton);
            Controls.Add(SaveButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "LinkDetailsSettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Link Configuration";
            Load += LinkDetailsSettingsForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox NameTextBox;
        private TextBox UrlTextBox;
        private ComboBox BrowserComboBox;
        private ListView ParamsListView;
        private Button SaveButton;
        private Button CancelFormButton;
        private Label label5;
        private TextBox ImageTextBox;
        private Button BrowseButton;
        private CheckBox NewBrowserWindowCheckBox;
        private CheckBox IncognitoCheckBox;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private GroupBox groupBox1;
        private Button AddParamButton;
        private Button RemoveAllParamsButton;
    }
}