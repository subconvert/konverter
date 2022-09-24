using System.Diagnostics;

namespace SubConvert
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            label1.Text = @"Конвертер encoding - а txt фајлова. 

Аутоматска транслитерација из српске латинице у ћирилицу и обрнуто.
Подржане кодне стране су windows1250, windows1251 и UTF - 8.
Тагови у титловима остају непромењени при конверзији у ћирилицу.

Коришћени су следећи nuget пакети:";
        }

        private void LlUTFUnknown_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/CharsetDetector/UTF-unknown";
            try
            {
                VisitLink(url);
            }
            catch (Exception)
            {
                UrlForm uf = new(url);
                uf.ShowDialog();
            }
        }

        private void LlCyrillicConvert_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/bajceticnenad/Cyrillic.Convert";
            try
            {
                VisitLink(url);
            }
            catch (Exception)
            {
                UrlForm uf = new(url);
                uf.ShowDialog();
            }
        }

        private void LlMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "mailto:subconvert@outlook.com";
            try
            {
                VisitLink(url);
            }
            catch (Exception)
            {
                UrlForm uf = new(url);
                uf.ShowDialog();
            }
        }

        private void lblLibVLCSharp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://code.videolan.org/videolan/LibVLCSharp";
            try
            {
                VisitLink(url);
            }
            catch (Exception)
            {
                UrlForm uf = new(url);
                uf.ShowDialog();
            }
        }

        private static void VisitLink(string url)
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

    }
}
