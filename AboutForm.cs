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
            try
            {
                VisitLink("https://github.com/CharsetDetector/UTF-unknown");
            }
            catch (Exception)
            {
                UrlForm uf = new("https://github.com/CharsetDetector/UTF-unknown");
                uf.ShowDialog();
            }
        }

        private void LlCyrillicConvert_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink("https://github.com/bajceticnenad/Cyrillic.Convert");
            }
            catch (Exception)
            {
                UrlForm uf = new("https://github.com/bajceticnenad/Cyrillic.Convert");
                uf.ShowDialog();
            }
        }

        private void LlMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink("mailto:subconvert@outlook.com");
            }
            catch (Exception)
            {
                UrlForm uf = new("mailto:subconvert@outlook.com");
                uf.ShowDialog();
            }
        }

        private static void VisitLink(string url)
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
