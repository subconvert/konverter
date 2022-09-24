using Cyrillic.Convert;
using LibVLCSharp.Shared;
using System.Text;
using System.Text.RegularExpressions;

namespace SubConvert
{
    public partial class FileViewForm : Form
    {
        private MyFileInfo _mfi;

        public LibVLC _libVLC;
        public MediaPlayer _mp;


        public FileViewForm(MyFileInfo mfi)
        {
            InitializeComponent();

            _mfi = mfi;

            _libVLC = new LibVLC();
            _mp = new MediaPlayer(_libVLC);
        }

        private void FileViewForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (_mfi.Folder != null && _mfi.FileName != null && _mfi.FileEncoding != null)
                    FillRichTextFromFile(Path.Combine(_mfi.Folder, _mfi.FileName), _mfi.FileEncoding);

                RefreshLabels();

                videoView1.MediaPlayer = _mp;

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

        public void FillRichTextFromFile(string filePath, string encoding)
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
                e.Effect = DragDropEffects.Link;
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
                    string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

                    var media = new Media(_libVLC, droppedFiles[0], FromType.FromPath);
                    media.Parse(MediaParseOptions.ParseNetwork);
                    videoView1.Visible = true;

                    _mp.Media = media;

                    ThreadPool.QueueUserWorkItem(_ => _mp.Play());
                }
                catch (Exception ex)
                {
                    ErrorMessageForm emf = new(ex.Message, ex.StackTrace ?? string.Empty);
                    emf.ShowDialog();
                }
            }
        }

        private void КопирајToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbViewFile.SelectedText);
        }

        private void транслитерујToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedText = rtbViewFile.SelectedText;
            if (selectedText.IsCyrillic())
                rtbViewFile.SelectedText = selectedText.ToSerbianLatin();
            else
                rtbViewFile.SelectedText = selectedText.ToSerbianCyrilic().RestoreTags();
        }

        private void FileViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mp.Stop();
            _mp.Dispose();
            _libVLC.Dispose();
        }

        private void скочиНаВремеToolStripMenuItem_Click(object sender, EventArgs e)
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

                ThreadPool.QueueUserWorkItem(_ => _mp.SeekTo(ts));
            }
            catch (Exception ex)
            {
                ErrorMessageForm emf = new(ex.Message, ex.StackTrace ?? string.Empty);
                emf.ShowDialog();
            }
        }
    }
}
