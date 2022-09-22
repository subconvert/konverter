using UtfUnknown;

namespace SubConvert
{
    public partial class FileListForm : Form
    {
        private List<MyFileInfo> files = new();

        public FileListForm(List<string> filePaths)
        {
            InitializeComponent();

            foreach (string filePath in filePaths)
            {
                DetectionResult detectionResult = CharsetDetector.DetectFromFile(filePath);

                files.Add(new MyFileInfo() 
                { 
                    FileEncoding = detectionResult.Detected.EncodingName,
                    FileName = Path.GetFileName(filePath),
                    Folder = Path.GetDirectoryName(filePath) ?? string.Empty
                });
            }

            dgvFileList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvFileList.Bind(files);
        }
    }
}
