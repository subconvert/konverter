using Cyrillic.Convert;
using NAudio.Wave;
using NAudio.WaveFormRenderer;
using System.Drawing.Imaging;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SubConvert
{
    public partial class FileViewForm : Form
    {
        private MyFileInfo _mfi;
        private DirectSoundOut _dso;

        public FileViewForm(MyFileInfo mfi)
        {
            InitializeComponent();

            _mfi = mfi;
            _dso = new();
        }

        private void FileViewForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (_mfi.Folder != null && _mfi.FileName != null && _mfi.FileEncoding != null)
                    FillRichText(Path.Combine(_mfi.Folder, _mfi.FileName), _mfi.FileEncoding);

                RefreshLabels();


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
            using SaveFileDialog sfd = new()
            {
                OverwritePrompt = true,
                InitialDirectory = _mfi.Folder,
                CheckPathExists = true,
                FileName = $"{Path.GetFileNameWithoutExtension(_mfi.FileName)}_UTF8{Path.GetExtension(_mfi.FileName)}"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                _mfi.Folder = Path.GetDirectoryName(sfd.FileName);
                _mfi.FileName = Path.GetFileName(sfd.FileName);
                _mfi.FileEncoding = "utf-8";
                WriteRichTextToFile(_mfi.Folder, _mfi.FileName, _mfi.FileEncoding);
                RefreshLabels();
            };
        }

        private void Windows1250ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SaveFileDialog sfd = new()
            {
                OverwritePrompt = true,
                InitialDirectory = _mfi.Folder,
                CheckPathExists = true,
                FileName = $"{Path.GetFileNameWithoutExtension(_mfi.FileName)}_1250{Path.GetExtension(_mfi.FileName)}"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                _mfi.Folder = Path.GetDirectoryName(sfd.FileName);
                _mfi.FileName = Path.GetFileName(sfd.FileName);
                _mfi.FileEncoding = "windows-1250";
                WriteRichTextToFile(_mfi.Folder, _mfi.FileName, _mfi.FileEncoding);
                RefreshLabels();
            };
        }

        private void Windows1251ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SaveFileDialog sfd = new()
            {
                OverwritePrompt = true,
                InitialDirectory = _mfi.Folder,
                CheckPathExists = true,
                FileName = $"{Path.GetFileNameWithoutExtension(_mfi.FileName)}_1251{Path.GetExtension(_mfi.FileName)}"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                _mfi.Folder = Path.GetDirectoryName(sfd.FileName);
                _mfi.FileName = Path.GetFileName(sfd.FileName);
                _mfi.FileEncoding = "windows-1251";
                WriteRichTextToFile(_mfi.Folder, _mfi.FileName, _mfi.FileEncoding);
                RefreshLabels();
            };
        }

        private void RefreshLabels()
        {
            lblEncoding.Text = $"Енкодинг: {_mfi.FileEncoding}";
            ;
            lblFileName.Text = $"Назив фајла: {_mfi.FileName}";

            Text = $"Преглед фајла - {_mfi.FileName} - {(_mfi.FileEncoding ?? "непознат енкодинг").ToUpper()}";
        }

        private void ТранслитерацијаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbViewFile.Text.IsCyrillic())
                rtbViewFile.Text = rtbViewFile.Text.ToSerbianLatin();
            else
                rtbViewFile.Text = rtbViewFile.Text.ToSerbianCyrilic().RestoreTags();
        }

        private void PnlWaveForm_DragEnter(object sender, DragEventArgs e)
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


        private void PnlWaveForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                try
                {
                    //TODO: move to a diff thread
                    string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

                    lblDnDInfo.Visible = true;
                    _dso.Stop();

                    using (MediaFoundationReader mfReader = new(droppedFiles[0])) //new("https://s5.voscast.com:10151/stream");
                    {
                        MaxPeakProvider maxPeakProvider = new MaxPeakProvider();
                        RmsPeakProvider rmsPeakProvider = new RmsPeakProvider(100); // e.g. 200
                        SamplingPeakProvider samplingPeakProvider = new SamplingPeakProvider(200); // e.g. 200
                        AveragePeakProvider averagePeakProvider = new AveragePeakProvider(4); // e.g. 4

                        StandardWaveFormRendererSettings myRendererSettings = new StandardWaveFormRendererSettings();
                        myRendererSettings.Width = 1080;
                        myRendererSettings.TopHeight = 64;
                        myRendererSettings.BottomHeight = 64;

                        WaveFormRenderer renderer = new WaveFormRenderer();
                        Image image = renderer.Render(mfReader, averagePeakProvider, myRendererSettings);

                        lblDnDInfo.Visible = false;
                        pnlWaveForm.BackgroundImageLayout = ImageLayout.Stretch;
                        pnlWaveForm.BackgroundImage = image;
                    }

                    using MediaFoundationReader mfReader2 = new(droppedFiles[0]);
                    _dso.Init(mfReader2);
                    _dso.Play();
                }
                catch (Exception ex)
                {
                    ErrorMessageForm emf = new(ex.Message, ex.StackTrace ?? string.Empty);
                    emf.ShowDialog();
                }
            }
        }

        private void FileViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _dso.Stop();
        }

        private void зауставиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dso.Stop();
        }

        private void пустиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dso.Play();
        }

        private void тестСеекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: not working
            _dso.Stop();
            TimeSpan ts = _dso.PlaybackPosition;
            _dso.Play();

            ErrorMessageForm efm = new("Pozicija", ts.ToString());
            efm.Show();
        }
    }
}
