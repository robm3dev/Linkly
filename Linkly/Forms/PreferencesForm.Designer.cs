namespace Linkly.Forms
{
    partial class PreferencesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
            StartLinklyWhenWindowsStartsCheckBox = new CheckBox();
            StartupGroupBox = new GroupBox();
            TaskBarSettingsGroupBox = new GroupBox();
            label1 = new Label();
            OpenTaskBarSettingsButton = new Button();
            CloseFormButton = new Button();
            StartupGroupBox.SuspendLayout();
            TaskBarSettingsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // StartLinklyWhenWindowsStartsCheckBox
            // 
            StartLinklyWhenWindowsStartsCheckBox.AutoSize = true;
            StartLinklyWhenWindowsStartsCheckBox.Location = new Point(18, 33);
            StartLinklyWhenWindowsStartsCheckBox.Name = "StartLinklyWhenWindowsStartsCheckBox";
            StartLinklyWhenWindowsStartsCheckBox.Size = new Size(211, 19);
            StartLinklyWhenWindowsStartsCheckBox.TabIndex = 0;
            StartLinklyWhenWindowsStartsCheckBox.Text = "Start Linkly when Windows starts";
            StartLinklyWhenWindowsStartsCheckBox.UseVisualStyleBackColor = true;
            StartLinklyWhenWindowsStartsCheckBox.CheckedChanged += StartLinklyWhenWindowsStartsCheckBox_CheckedChanged;
            // 
            // StartupGroupBox
            // 
            StartupGroupBox.Controls.Add(StartLinklyWhenWindowsStartsCheckBox);
            StartupGroupBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            StartupGroupBox.Location = new Point(12, 12);
            StartupGroupBox.Name = "StartupGroupBox";
            StartupGroupBox.Size = new Size(598, 76);
            StartupGroupBox.TabIndex = 1;
            StartupGroupBox.TabStop = false;
            StartupGroupBox.Text = "Windows Start Up Preferences";
            // 
            // TaskBarSettingsGroupBox
            // 
            TaskBarSettingsGroupBox.Controls.Add(label1);
            TaskBarSettingsGroupBox.Controls.Add(OpenTaskBarSettingsButton);
            TaskBarSettingsGroupBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            TaskBarSettingsGroupBox.Location = new Point(12, 101);
            TaskBarSettingsGroupBox.Name = "TaskBarSettingsGroupBox";
            TaskBarSettingsGroupBox.Size = new Size(598, 129);
            TaskBarSettingsGroupBox.TabIndex = 2;
            TaskBarSettingsGroupBox.TabStop = false;
            TaskBarSettingsGroupBox.Text = "Windows TaskBar Settings";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(18, 32);
            label1.Name = "label1";
            label1.Size = new Size(559, 48);
            label1.TabIndex = 1;
            label1.Text = resources.GetString("label1.Text");
            // 
            // OpenTaskBarSettingsButton
            // 
            OpenTaskBarSettingsButton.Location = new Point(197, 92);
            OpenTaskBarSettingsButton.Name = "OpenTaskBarSettingsButton";
            OpenTaskBarSettingsButton.Size = new Size(207, 23);
            OpenTaskBarSettingsButton.TabIndex = 0;
            OpenTaskBarSettingsButton.Text = "Open Windows TaskBar Settings";
            OpenTaskBarSettingsButton.UseVisualStyleBackColor = true;
            OpenTaskBarSettingsButton.Click += OpenTaskBarSettingsButton_Click;
            // 
            // CloseFormButton
            // 
            CloseFormButton.Location = new Point(276, 236);
            CloseFormButton.Name = "CloseFormButton";
            CloseFormButton.Size = new Size(75, 23);
            CloseFormButton.TabIndex = 3;
            CloseFormButton.Text = "Close";
            CloseFormButton.UseVisualStyleBackColor = true;
            CloseFormButton.Click += CloseFormButton_Click;
            // 
            // PreferencesForm
            // 
            AcceptButton = CloseFormButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CloseFormButton;
            ClientSize = new Size(622, 266);
            Controls.Add(CloseFormButton);
            Controls.Add(TaskBarSettingsGroupBox);
            Controls.Add(StartupGroupBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PreferencesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Linkly Preferences";
            Load += PreferencesForm_Load;
            StartupGroupBox.ResumeLayout(false);
            StartupGroupBox.PerformLayout();
            TaskBarSettingsGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CheckBox StartLinklyWhenWindowsStartsCheckBox;
        private GroupBox StartupGroupBox;
        private GroupBox TaskBarSettingsGroupBox;
        private Button OpenTaskBarSettingsButton;
        private Label label1;
        private Button CloseFormButton;
    }
}