using System.Text;
using UtfUnknown;

namespace SubConvert
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            InitializeComponent();
        }

        private static void SelectFiles(SourceEncoding sourceEncoding)
        {
            using OpenFileDialog ofd = new()
            {
                Filter = "Subtitles|*.srt;*.sub;*.txt|All files|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Multiselect = true,
                Title = "Изабери титлове"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<string> result = ConversionTools.ConvertFrom(sourceEncoding, ofd.FileNames);

                    FileListForm flf = new(result);
                    flf.Show();
                }
                catch (Exception ex)
                {
                    ErrorMessageForm emf = new(ex.Message, ex.StackTrace ?? string.Empty);
                    emf.ShowDialog();
                }
            }
        }

        private void BtnAutomatic_Click(object sender, EventArgs e)
        {
            SelectFiles(SourceEncoding.AUTODETECT);
        }

        private void BtnAutomatic_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                try
                {
                    string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

                    List<string> result = ConversionTools.ConvertFrom(SourceEncoding.AUTODETECT, droppedFiles);

                    FileListForm flf = new(result);
                    flf.Show();
                }
                catch (Exception ex)
                {
                    ErrorMessageForm emf = new(ex.Message, ex.StackTrace ?? string.Empty);
                    emf.ShowDialog();
                }
            }
        }
        private void BtnAutomatic_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }



        private void ОПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm af = new();
            af.ShowDialog();
        }

        private void ОтвориФајлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new() { Multiselect = false };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;

                DetectionResult detectionResult = CharsetDetector.DetectFromFile(filePath);

                MyFileInfo mfi = new()
                {
                    FileEncoding = detectionResult.Detected.EncodingName,
                    FileName = Path.GetFileName(filePath),
                    Folder = Path.GetDirectoryName(filePath) ?? string.Empty
                };

                FileViewForm fvf = new(mfi);
                fvf.Show();
            }
        }

        private void Windows1250UTF8ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SelectFiles(SourceEncoding.WIN1250);
        }

        private void Windows1251UTF8ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SelectFiles(SourceEncoding.WIN1251);
        }

        private void Windows1252UTF8ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SelectFiles(SourceEncoding.WIN1252);
        }

        private void UTF8ANSIToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SelectFiles(SourceEncoding.UTF8);
        }

        private void АутоматскаДетекцијаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SelectFiles(SourceEncoding.AUTODETECT);
        }
    }
}