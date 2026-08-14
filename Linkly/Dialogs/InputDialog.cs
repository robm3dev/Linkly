namespace Linkly.Dialogs
{
    public partial class InputDialog : Form
    {
        /// <summary>
        /// The Private Title Text to be displayed as the header title the Input Dialog Form
        /// </summary>
        private string titleText;

        /// <summary>
        /// The Private Prompt Text to be displayed in the Input Dialog Form
        /// </summary>
        private string promptText;

        /// <summary>
        /// The Public Output Value entered by the user in the Input Dialog Form
        /// </summary>
        public string OutputTextValue;

        /// <summary>
        /// Initializes a new instance of the InputDialog class with the specified prompt text.
        /// </summary>
        /// <param name="promptText">The prompt text to be displayed in the input dialog.</param>
        public InputDialog(string titleText, string promptText)
        {
            InitializeComponent();
            this.titleText = titleText;
            this.promptText = promptText;
            this.OutputTextValue = string.Empty;
        }

        /// <summary>
        /// The Form Load Event Handler; 
        /// Sets the Form Title & Prompt Text Label to the provided prompt text.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void InputDialog_Load(object sender, EventArgs e)
        {
            this.Text = titleText;
            this.PromptTextLabel.Text = promptText;
        }

        /// <summary>
        /// The OK Button Click Event Handler;
        /// Validates input was entered, then sets the DialogResult to OK and closes the form.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (string.IsNullOrWhiteSpace(this.InputTextBox.Text.Trim()))
            {
                MessageBox.Show("Input cannot be empty. Please enter a value.", 
                                "Validation Error", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning);
            }
            else
            {
                this.OutputTextValue = this.InputTextBox.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// The Cancel Button Click Event Handler;
        /// Sets the DialogResult to Cancel and closes the form.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void CancelFormButton_Click(object sender, EventArgs e)
        {
            this.OutputTextValue = string.Empty;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
