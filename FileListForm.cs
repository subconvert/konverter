using System.Windows.Forms;
using UtfUnknown;

namespace SubConvert
{
    public partial class FileListForm : Form
    {
        public FileListForm(List<string> filePaths)
        {
            InitializeComponent();

            List<MyFileInfo> files = new();

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

            dgvFileList.Bind(files);

        }

        private void ContextMenuClipboard_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DataObject d = dgvFileList.GetClipboardContent();
            Clipboard.SetDataObject(d);
        }


        private void DgvFileList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvFileList.CurrentCell != null && dgvFileList.CurrentCell.Value != null)
                {
                    MyFileInfo mfi = (MyFileInfo)dgvFileList.CurrentRow.DataBoundItem;

                    FileViewForm fvf = new(mfi);
                    fvf.Show();
                }
            }
        }
    }
}
