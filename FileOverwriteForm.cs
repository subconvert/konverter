namespace SubConvert
{
    public partial class FileOverwriteForm : Form
    {
        public string newFileName = string.Empty;

        public FileOverwriteForm()
        {
            InitializeComponent();
        }

        public FileOverwriteForm(string fileName)
        {
            InitializeComponent();

            newFileName = fileName;
            tbFileName.Text = fileName;
        }

        private void btnOverwrite_Click(object sender, EventArgs e)
        {
            newFileName = tbFileName.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCheckAgain_Click(object sender, EventArgs e)
        {
            newFileName = tbFileName.Text;
            DialogResult = DialogResult.Continue;
        }
    }
}
