namespace SubConvert
{
    public partial class ErrorMessageForm : Form
    {
        public ErrorMessageForm(string errorMessage, string stackTrace)
        {
            InitializeComponent();

            lblErrorMessage.Text = errorMessage.Truncate(7,121);
            lblStacktrace.Text = stackTrace.Truncate(7, 121);
        }
    }
}
