
// Define a Custom Message Box (Dialog) class to create Confirmation Dialogs.
public partial class HIOXModEditor : Form
{
    public partial class CustomMessageBox : Form
    {

        private System.Windows.Forms.Label lblMessage = new System.Windows.Forms.Label();
        private System.Windows.Forms.Button btnPositive = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button btnNegative = new System.Windows.Forms.Button();

        public DialogResult Result { get; private set; }

        public CustomMessageBox(string message, string title, string positiveText, string negativeText)
        {
            InitializeComponent();
            this.Text = title;
            lblMessage.Text = message;
            btnPositive.Text = positiveText;
            btnNegative.Text = negativeText;
        }

        private void InitializeComponent()
        {
            // Set basic form properties
            this.ClientSize = new Size(350, 150);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Confirm File Replace";

            // Create a table layout with 2 rows (message row + button row)
            var table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1,
            };
            // First row uses 70% of the height for the message
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 70f));
            // Second row uses 30% for the buttons
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 30f));

            // Create the message label
            lblMessage = new Label
            {
                Dock = DockStyle.Fill,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "File 'ModsData.csv' already exists.\nReplace it?"
            };
            table.Controls.Add(lblMessage, 0, 0);

            // Create a FlowLayoutPanel for the buttons (aligned to the bottom-right)
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(10)
            };

            // Negative (Cancel) button
            btnNegative = new Button
            {
                Text = "Cancel",
                AutoSize = true
            };
            btnNegative.Click += (s, e) =>
            {
                Result = DialogResult.No;
                this.Close();
            };
            buttonPanel.Controls.Add(btnNegative);

            // Positive (Confirm) button
            btnPositive = new Button
            {
                Text = "Confirm",
                AutoSize = true
            };
            btnPositive.Click += (s, e) =>
            {
                Result = DialogResult.Yes;
                this.Close();
            };
            buttonPanel.Controls.Add(btnPositive);

            // Add the button panel to row 1 of the table
            table.Controls.Add(buttonPanel, 0, 1);

            // Add the table to the form
            this.Controls.Add(table);
       }


        private void btnPositive_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Yes;
            this.Close();
        }

        private void btnNegative_Click(object sender, EventArgs e)
        {
            Result = DialogResult.No;
            this.Close();
        }

        public static bool Show(string message, string title, string positiveText, string negativeText)
        {
            using (var cmb = new CustomMessageBox(message, title, positiveText, negativeText))
            {
                cmb.ShowDialog();
                return (cmb.Result == DialogResult.Yes);
            }
        }
    }

    private static bool ConfirmDialog(string message, string title = "Confirm Change", string positiveText = "Confirm", string negativeText = "Cancel")
    {
        //System.Media.SystemSounds.Beep.Play();
        Console.Beep(500,50); Console.Beep(600,50); Console.Beep(500, 200);

        return CustomMessageBox.Show(message, title, positiveText, negativeText);
    }

}
