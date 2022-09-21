namespace SubConvert
{
    public partial class UrlForm : Form
    {
        public UrlForm() 
        {
            InitializeComponent();
        }

        public UrlForm(string text)
        {
            InitializeComponent();

            tbURL.Text = text;
        }

        private void BtnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbURL.Text);
        }
    }
}
