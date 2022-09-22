﻿using System.Drawing.Drawing2D;
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

            dgvFileList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvFileList.Bind(files);

        }
    }
}