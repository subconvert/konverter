using Cyrillic.Convert;
using NAudio.Wave;
using NAudio.WaveFormRenderer;
using System.Text;
using System.Text.RegularExpressions;
using Button = System.Windows.Forms.Button;

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

                    var wo = new WaveOutEvent();
                    var af = new AudioFileReader(droppedFiles[0]);
                    var closing = false;
                    wo.PlaybackStopped += (s, a) => { if (closing) { wo.Dispose(); af.Dispose(); } };
                    wo.Init(af);

                    var f = new Form();

                    var flp = new FlowLayoutPanel() { FlowDirection = FlowDirection.LeftToRight };
                    flp.Dock = DockStyle.Fill;

                    var b = new Button() { Text = "Play" };
                    b.Click += (s, a) => wo.Play();
                    var b2 = new Button() { Text = "Stop" };
                    b2.Click += (s, a) => wo.Stop();
                    var b3 = new Button { Text = "Rewind" };
                    b3.Click += (s, a) => af.Position = 0;
                    var b4 = new Button { Text = "Seek to current line" };
                    b4.Click += (s, a) =>
                    {
                        try
                        {
                            //match 00:00:36
                            int currentLineIndex = rtbViewFile.GetFirstCharIndexOfCurrentLine();
                            Regex r = new Regex("(?<hours>\\d\\d):(?<minutes>\\d\\d):(?<seconds>\\d\\d)");
                            Match m = r.Match(rtbViewFile.Text.Substring(rtbViewFile.GetFirstCharIndexOfCurrentLine(), 8));

                            string hours = m.Groups["hours"].Value;
                            string minutes = m.Groups["minutes"].Value;
                            string seconds = m.Groups["seconds"].Value;

                            TimeSpan ts = new(int.Parse(hours), int.Parse(minutes), int.Parse(seconds));

                            af.CurrentTime = ts;
                        }
                        catch (Exception ex)
                        {
                            ErrorMessageForm emf = new(ex.Message, ex.StackTrace ?? string.Empty);
                            emf.ShowDialog();
                        }
                    };

                    flp.Controls.Add(b);
                    flp.Controls.Add(b2);
                    flp.Controls.Add(b3);
                    flp.Controls.Add(b4);

                    f.Controls.Add(flp);

                    f.FormClosing += (s, a) => { closing = true; wo.Stop(); };
                    f.Show();
                }
                catch (Exception ex)
                {
                    ErrorMessageForm emf = new(ex.Message, ex.StackTrace ?? string.Empty);
                    emf.ShowDialog();
                }
            }
        }
    }
}
