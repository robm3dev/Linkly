namespace Linkly.Dialogs
{
    partial class InputDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputDialog));
            PromptTextLabel = new Label();
            InputTextBox = new TextBox();
            OkButton = new Button();
            CancelFormButton = new Button();
            SuspendLayout();
            // 
            // PromptTextLabel
            // 
            PromptTextLabel.AutoSize = true;
            PromptTextLabel.Location = new Point(14, 14);
            PromptTextLabel.Name = "PromptTextLabel";
            PromptTextLabel.Size = new Size(71, 15);
            PromptTextLabel.TabIndex = 0;
            PromptTextLabel.Text = "Prompt Text";
            // 
            // InputTextBox
            // 
            InputTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            InputTextBox.BackColor = SystemColors.Info;
            InputTextBox.BorderStyle = BorderStyle.FixedSingle;
            InputTextBox.Location = new Point(15, 36);
            InputTextBox.MaxLength = 70;
            InputTextBox.Name = "InputTextBox";
            InputTextBox.Size = new Size(562, 23);
            InputTextBox.TabIndex = 1;
            InputTextBox.WordWrap = false;
            // 
            // OkButton
            // 
            OkButton.Location = new Point(14, 65);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(75, 22);
            OkButton.TabIndex = 2;
            OkButton.Text = "Accept";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // CancelFormButton
            // 
            CancelFormButton.Location = new Point(95, 65);
            CancelFormButton.Name = "CancelFormButton";
            CancelFormButton.Size = new Size(75, 22);
            CancelFormButton.TabIndex = 3;
            CancelFormButton.Text = "Cancel";
            CancelFormButton.UseVisualStyleBackColor = true;
            CancelFormButton.Click += CancelFormButton_Click;
            // 
            // InputDialog
            // 
            AcceptButton = OkButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelFormButton;
            ClientSize = new Size(591, 97);
            Controls.Add(CancelFormButton);
            Controls.Add(OkButton);
            Controls.Add(InputTextBox);
            Controls.Add(PromptTextLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InputDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InputDialog";
            Load += InputDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PromptTextLabel;
        private TextBox InputTextBox;
        private Button OkButton;
        private Button CancelFormButton;
    }
}