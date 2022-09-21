using Cyrillic.Convert;
using System.Text;
using UtfUnknown;

namespace SubConvert
{
    public static class ConversionTools
    {
        public static void ConvertFrom(SourceEncoding sourceEncoding, string[] filePaths)
        {
            if (sourceEncoding == SourceEncoding.AUTODETECT)
                AutodetectEncoding(filePaths);
            else
                ConvertFiles(sourceEncoding, filePaths);
        }

        private static void AutodetectEncoding(string[] filePaths)
        {
            foreach (string filePath in filePaths)
            {
                DetectionResult result = CharsetDetector.DetectFromFile(filePath);

                if (result.Detected.Encoding == Encoding.GetEncoding(1250))
                    ConvertOneFile(SourceEncoding.WIN1250, filePath);
                else if (result.Detected.Encoding == Encoding.GetEncoding(1251))
                    ConvertOneFile(SourceEncoding.WIN1251, filePath);
                else if (result.Detected.Encoding == Encoding.UTF8)
                    ConvertOneFile(SourceEncoding.UTF8, filePath);
                else ConvertOneFile(SourceEncoding.WIN1252, filePath);
            }
        }

        private static void ConvertFiles(SourceEncoding sourceEncoding, string[] filePaths)
        {
            foreach (string filePath in filePaths)
            {
                ConvertOneFile(sourceEncoding, filePath);
            }
        }

        private static void ConvertOneFile(SourceEncoding sourceEncoding, string filePath)
        {
            string? folder = Path.GetDirectoryName(filePath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
            string extension = Path.GetExtension(filePath);

            string s = string.Empty;
            switch (sourceEncoding)
            {
                case SourceEncoding.WIN1250:
                    s = File.ReadAllText(filePath, Encoding.GetEncoding(1250));
                    break;
                case SourceEncoding.WIN1251:
                    s = File.ReadAllText(filePath, Encoding.GetEncoding(1251));
                    break;
                case SourceEncoding.WIN1252:
                    s = File.ReadAllText(filePath, Encoding.GetEncoding(1252));
                    break;
                case SourceEncoding.UTF8:
                    s = File.ReadAllText(filePath, Encoding.UTF8);
                    break;
                default:
                    break;
            }

            folder ??= Environment.GetFolderPath(Environment.SpecialFolder.Personal);


            if (!s.Equals(string.Empty))
                switch (sourceEncoding)
                {
                    case SourceEncoding.WIN1250:
                        WriteFile(folder, $"{fileNameWithoutExtension}_Lat_UTF8{extension}", s, Encoding.UTF8);
                        s = s.ToSerbianCyrilic();
                        s = s.RestoreTags();
                        WriteFile(folder, $"{fileNameWithoutExtension}_Cyr_UTF8{extension}", s, Encoding.UTF8);
                        WriteFile(folder, $"{fileNameWithoutExtension}_Cyr_1251{extension}", s, Encoding.GetEncoding(1251));
                        break;
                    case SourceEncoding.WIN1251:
                        WriteFile(folder, $"{fileNameWithoutExtension}_Cyr_UTF8{extension}", s, Encoding.UTF8);
                        s = s.ToSerbianLatin();
                        WriteFile(folder, $"{fileNameWithoutExtension}_Lat_UTF8{extension}", s, Encoding.UTF8);
                        WriteFile(folder, $"{fileNameWithoutExtension}_Lat_1250{extension}", s, Encoding.GetEncoding(1250));
                        break;
                    case SourceEncoding.WIN1252:
                        WriteFile(folder, $"{fileNameWithoutExtension}_UTF8{extension}", s, Encoding.UTF8);
                        break;
                    case SourceEncoding.UTF8:
                        if (s.IsCyrillic())
                        {
                            WriteFile(folder, $"{fileNameWithoutExtension}_Cyr_1251{extension}", s, Encoding.GetEncoding(1251));
                            s = s.ToSerbianLatin();
                            WriteFile(folder, $"{fileNameWithoutExtension}_Lat_UTF8{extension}", s, Encoding.UTF8);
                            WriteFile(folder, $"{fileNameWithoutExtension}_Lat_1250{extension}", s, Encoding.GetEncoding(1250));
                        }
                        else
                        {
                            WriteFile(folder, $"{fileNameWithoutExtension}_Lat_1250{extension}", s, Encoding.GetEncoding(1250));
                            s = s.ToSerbianCyrilic();
                            s = s.RestoreTags();
                            WriteFile(folder, $"{fileNameWithoutExtension}_Cyr_UTF8{extension}", s, Encoding.UTF8);
                            WriteFile(folder, $"{fileNameWithoutExtension}_Cyr_1251{extension}", s, Encoding.GetEncoding(1251));
                        }
                        break;
                    default:
                        break;
                }
        }

        private static void WriteFile(string folder, string fileName, string content, Encoding destinationEncoding)
        {
            if (File.Exists(Path.Combine(folder, fileName)))
            {
                FileOverwriteForm fof = new(fileName);
                fof.ShowDialog();
                if (fof.DialogResult == DialogResult.OK)
                    File.WriteAllText(Path.Combine(folder, fileName), content, destinationEncoding);
                else if (fof.DialogResult == DialogResult.Continue)
                    WriteFile(folder, fof.newFileName, content, destinationEncoding);
            }
            else
                File.WriteAllText(Path.Combine(folder, fileName), content, destinationEncoding);
        }
    }
}