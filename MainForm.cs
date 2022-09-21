using System.Text;

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
                bool ok = false;
                try
                {
                    ConversionTools.ConvertFrom(sourceEncoding, ofd.FileNames);

                    ok = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
                if (ok) MessageBox.Show("Готово.");
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
                bool ok = false;
                try
                {
                    string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

                    ConversionTools.ConvertFrom(SourceEncoding.AUTODETECT, droppedFiles);

                    ok = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
                if (ok) MessageBox.Show("Готово.");
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

        private void Windows1250UTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectFiles(SourceEncoding.WIN1250);
        }

        private void Windows1251UTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectFiles(SourceEncoding.WIN1251);
        }

        private void Windows1252UTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectFiles(SourceEncoding.WIN1252);
        }

        private void UTF8ANSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectFiles(SourceEncoding.UTF8);
        }

        private void АутоматскаДетекцијаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectFiles(SourceEncoding.AUTODETECT);
        }

        private void ОПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.ShowDialog();
        }
    }
}