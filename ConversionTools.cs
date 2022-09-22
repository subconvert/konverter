using Cyrillic.Convert;
using System.Text;
using UtfUnknown;

namespace SubConvert
{
    public static class ConversionTools
    {
        public static List<string> ConvertFrom(SourceEncoding sourceEncoding, string[] filePaths)
        {
            if (sourceEncoding == SourceEncoding.AUTODETECT)
                return AutodetectEncoding(filePaths);
            else
                return ConvertFiles(sourceEncoding, filePaths);
        }

        private static List<string> AutodetectEncoding(string[] filePaths)
        {
            List<string> result = new();

            foreach (string filePath in filePaths)
            {
                DetectionResult detectionResult = CharsetDetector.DetectFromFile(filePath);

                if (detectionResult.Detected.Encoding == Encoding.GetEncoding(1250))
                    result.AddRange(ConvertOneFile(SourceEncoding.WIN1250, filePath));
                else if (detectionResult.Detected.Encoding == Encoding.GetEncoding(1251))
                    result.AddRange(ConvertOneFile(SourceEncoding.WIN1251, filePath));
                else if (detectionResult.Detected.Encoding == Encoding.UTF8)
                    result.AddRange(ConvertOneFile(SourceEncoding.UTF8, filePath));
                else result.AddRange(ConvertOneFile(SourceEncoding.WIN1252, filePath));
            }

            return result;
        }

        private static List<string> ConvertFiles(SourceEncoding sourceEncoding, string[] filePaths)
        {
            List<string> result = new();
            foreach (string filePath in filePaths)
                result.AddRange(ConvertOneFile(sourceEncoding, filePath));

            return result;
        }

        private static List<string> ConvertOneFile(SourceEncoding sourceEncoding, string filePath)
        {
            List<string> result = new();

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
                        result.Add(WriteFile(folder, $"{fileNameWithoutExtension}_Lat_UTF8{extension}", s, Encoding.UTF8));
                        s = s.ToSerbianCyrilic();
                        s = s.RestoreTags();
                        result.Add(WriteFile(folder, $"{fileNameWithoutExtension}_Cyr_UTF8{extension}", s, Encoding.UTF8));
                        result.Add(WriteFile(folder, $"{fileNameWithoutExtension}_Cyr_1251{extension}", s, Encoding.GetEncoding(1251)));
                        break;
                    case SourceEncoding.WIN1251:
                        result.Add(WriteFile(folder, $"{fileNameWithoutExtension}_Cyr_UTF8{extension}", s, Encoding.UTF8));
                        s = s.ToSerbianLatin();
                        result.Add(WriteFile(folder, $"{fileNameWithoutExtension}_Lat_UTF8{extension}", s, Encoding.UTF8));
                        result.Add(WriteFile(folder, $"{fileNameWithoutExtension}_Lat_1250{extension}", s, Encoding.GetEncoding(1250)));
                        break;
                    case SourceEncoding.WIN1252:
                        result.Add(WriteFile(folder, $"{fileNameWithoutExtension}_UTF8{extension}", s, Encoding.UTF8));
                        break;
                    case SourceEncoding.UTF8:
                        if (s.IsCyrillic())
                        {
                            result.Add(WriteFile(folder, $"{fileNameWithoutExtension}_Cyr_1251{extension}", s, Encoding.GetEncoding(1251)));
                            s = s.ToSerbianLatin();
                            result.Add(WriteFile(folder, $"{fileNameWithoutExtension}_Lat_UTF8{extension}", s, Encoding.UTF8));
                            result.Add(WriteFile(folder, $"{fileNameWithoutExtension}_Lat_1250{extension}", s, Encoding.GetEncoding(1250)));
                        }
                        else
                        {
                            result.Add(WriteFile(folder, $"{fileNameWithoutExtension}_Lat_1250{extension}", s, Encoding.GetEncoding(1250)));
                            s = s.ToSerbianCyrilic();
                            s = s.RestoreTags();
                            result.Add(WriteFile(folder, $"{fileNameWithoutExtension}_Cyr_UTF8{extension}", s, Encoding.UTF8));
                            result.Add(WriteFile(folder, $"{fileNameWithoutExtension}_Cyr_1251{extension}", s, Encoding.GetEncoding(1251)));
                        }
                        break;
                    default:
                        break;
                }
            return result;
        }

        public static string WriteFile(string folder, string fileName, string content, Encoding destinationEncoding)
        {
            string outputFileName = Path.Combine(folder, fileName);
            if (File.Exists(Path.Combine(folder, fileName)))
            {
                FileOverwriteForm fof = new(fileName);
                fof.ShowDialog();
                if (fof.DialogResult == DialogResult.OK)
                    File.WriteAllText(outputFileName, content, destinationEncoding);
                else if (fof.DialogResult == DialogResult.Continue)
                    return WriteFile(folder, fof.newFileName, content, destinationEncoding);
            }
            else
            {
                File.WriteAllText(Path.Combine(folder, fileName), content, destinationEncoding);
            }
            return outputFileName;
        }
    }
}