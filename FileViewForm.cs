using System.Text;

namespace SubConvert
{
    public partial class FileViewForm : Form
    {
        private MyFileInfo _mfi;

        public FileViewForm(MyFileInfo mfi)
        {
            InitializeComponent();

            _mfi = mfi;
        }

        private void FileViewForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (_mfi.Folder != null && _mfi.FileName != null && _mfi.FileEncoding != null)
                    FillRichText(Path.Combine(_mfi.Folder, _mfi.FileName), _mfi.FileEncoding);

                lblEncoding.Text += _mfi.FileEncoding;
                lblFileName.Text = _mfi.FileName;

                Text += $" - {(_mfi.FileEncoding ?? "непознат енкодинг").ToUpper()}";
            }
            catch (Exception ex)
            {
                ErrorMessageForm emf = new(ex.Message, ex.StackTrace ?? string.Empty);
                emf.ShowDialog();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Да ли желите да снимите измене?",
                                                 "Потврда снимања",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                WriteRichTextToFile(_mfi.Folder, _mfi.FileName, _mfi.FileEncoding);
            }
        }

        public void FillRichText(string filePath, string encoding)
        {
            if (encoding.ToLower().Equals("windows-1250"))
                rtbViewFile.Text = File.ReadAllText(filePath, Encoding.GetEncoding(1250));
            else if (encoding.ToLower().Equals("windows-1251"))
                rtbViewFile.Text = File.ReadAllText(filePath, Encoding.GetEncoding(1251));
            else if (encoding.ToLower().Equals("utf-8"))
                rtbViewFile.Text = File.ReadAllText(filePath, Encoding.UTF8);
            else
                rtbViewFile.Text = File.ReadAllText(filePath);
        }

        public void WriteRichTextToFile(string folder, string fileName, string encoding)
        {
            if (encoding.ToLower().Equals("windows-1250"))
                ConversionTools.WriteFile(folder, fileName, rtbViewFile.Text, Encoding.GetEncoding(1250));
            else if (encoding.ToLower().Equals("windows-1251"))
                ConversionTools.WriteFile(folder, fileName, rtbViewFile.Text, Encoding.GetEncoding(1251));
            else if (encoding.ToLower().Equals("utf-8"))
                ConversionTools.WriteFile(folder, fileName, rtbViewFile.Text, Encoding.UTF8);
            else
                ConversionTools.WriteFile(folder, fileName, rtbViewFile.Text, Encoding.UTF8);
        }

        private void UTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new()
            {
                OverwritePrompt = true,
                InitialDirectory = _mfi.Folder,
                CheckPathExists = true,
                FileName = $"{Path.GetFileNameWithoutExtension(_mfi.FileName)}_UTF8{Path.GetExtension(_mfi.FileName)}"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                    WriteRichTextToFile(_mfi.Folder, sfd.FileName, "utf-8");
            }
        }

        private void Windows1250ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new()
            {
                OverwritePrompt = true,
                InitialDirectory = _mfi.Folder,
                CheckPathExists = true,
                FileName = $"{Path.GetFileNameWithoutExtension(_mfi.FileName)}_UTF8{Path.GetExtension(_mfi.FileName)}"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                    WriteRichTextToFile(_mfi.Folder, _mfi.FileName, "windows-1250");
            }
        }

        private void Windows1251ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new()
            {
                OverwritePrompt = true,
                InitialDirectory = _mfi.Folder,
                CheckPathExists = true,
                FileName = $"{Path.GetFileNameWithoutExtension(_mfi.FileName)}_UTF8{Path.GetExtension(_mfi.FileName)}"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                    WriteRichTextToFile(_mfi.Folder, _mfi.FileName, "windows-1251");
            }
        }
    }
}
