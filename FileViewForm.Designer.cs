namespace SubConvert
{
    partial class FileViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileViewForm));
            this.rtbViewFile = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.копирајToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFileInfo = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblEncoding = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.снимиКаоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uTF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windows1250ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windows1251ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алатиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.транслитерацијаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlWaveForm = new System.Windows.Forms.Panel();
            this.lblDnDInfo = new System.Windows.Forms.Label();
            this.транслитерујToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlFileInfo.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlWaveForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbViewFile
            // 
            this.rtbViewFile.ContextMenuStrip = this.contextMenuStrip1;
            this.rtbViewFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbViewFile.Location = new System.Drawing.Point(0, 85);
            this.rtbViewFile.Name = "rtbViewFile";
            this.rtbViewFile.Size = new System.Drawing.Size(641, 245);
            this.rtbViewFile.TabIndex = 1;
            this.rtbViewFile.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.копирајToolStripMenuItem,
            this.транслитерујToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // копирајToolStripMenuItem
            // 
            this.копирајToolStripMenuItem.Name = "копирајToolStripMenuItem";
            this.копирајToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.копирајToolStripMenuItem.Text = "Копирај";
            this.копирајToolStripMenuItem.Click += new System.EventHandler(this.КопирајToolStripMenuItem_Click);
            // 
            // pnlFileInfo
            // 
            this.pnlFileInfo.Controls.Add(this.btnSave);
            this.pnlFileInfo.Controls.Add(this.lblEncoding);
            this.pnlFileInfo.Controls.Add(this.lblFileName);
            this.pnlFileInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFileInfo.Location = new System.Drawing.Point(0, 24);
            this.pnlFileInfo.Name = "pnlFileInfo";
            this.pnlFileInfo.Size = new System.Drawing.Size(641, 61);
            this.pnlFileInfo.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(513, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сними измене";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblEncoding
            // 
            this.lblEncoding.AutoSize = true;
            this.lblEncoding.Location = new System.Drawing.Point(10, 36);
            this.lblEncoding.Name = "lblEncoding";
            this.lblEncoding.Size = new System.Drawing.Size(63, 15);
            this.lblEncoding.TabIndex = 1;
            this.lblEncoding.Text = "Encoding: ";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFileName.Location = new System.Drawing.Point(10, 11);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(59, 15);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "FileName";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.снимиКаоToolStripMenuItem,
            this.алатиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(641, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // снимиКаоToolStripMenuItem
            // 
            this.снимиКаоToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uTF8ToolStripMenuItem,
            this.windows1250ToolStripMenuItem,
            this.windows1251ToolStripMenuItem});
            this.снимиКаоToolStripMenuItem.Name = "снимиКаоToolStripMenuItem";
            this.снимиКаоToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.снимиКаоToolStripMenuItem.Text = "Фајл";
            // 
            // uTF8ToolStripMenuItem
            // 
            this.uTF8ToolStripMenuItem.Name = "uTF8ToolStripMenuItem";
            this.uTF8ToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.uTF8ToolStripMenuItem.Text = "Сними као UTF-8";
            this.uTF8ToolStripMenuItem.Click += new System.EventHandler(this.UTF8ToolStripMenuItem_Click);
            // 
            // windows1250ToolStripMenuItem
            // 
            this.windows1250ToolStripMenuItem.Name = "windows1250ToolStripMenuItem";
            this.windows1250ToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.windows1250ToolStripMenuItem.Text = "Сними као windows-1250";
            this.windows1250ToolStripMenuItem.Click += new System.EventHandler(this.Windows1250ToolStripMenuItem_Click);
            // 
            // windows1251ToolStripMenuItem
            // 
            this.windows1251ToolStripMenuItem.Name = "windows1251ToolStripMenuItem";
            this.windows1251ToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.windows1251ToolStripMenuItem.Text = "Сними као windows-1251";
            this.windows1251ToolStripMenuItem.Click += new System.EventHandler(this.Windows1251ToolStripMenuItem_Click);
            // 
            // алатиToolStripMenuItem
            // 
            this.алатиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.транслитерацијаToolStripMenuItem});
            this.алатиToolStripMenuItem.Name = "алатиToolStripMenuItem";
            this.алатиToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.алатиToolStripMenuItem.Text = "Алати";
            // 
            // транслитерацијаToolStripMenuItem
            // 
            this.транслитерацијаToolStripMenuItem.Name = "транслитерацијаToolStripMenuItem";
            this.транслитерацијаToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.транслитерацијаToolStripMenuItem.Text = "Транслитерација";
            this.транслитерацијаToolStripMenuItem.Click += new System.EventHandler(this.ТранслитерацијаToolStripMenuItem_Click);
            // 
            // pnlWaveForm
            // 
            this.pnlWaveForm.AllowDrop = true;
            this.pnlWaveForm.Controls.Add(this.lblDnDInfo);
            this.pnlWaveForm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlWaveForm.Location = new System.Drawing.Point(0, 330);
            this.pnlWaveForm.Name = "pnlWaveForm";
            this.pnlWaveForm.Size = new System.Drawing.Size(641, 100);
            this.pnlWaveForm.TabIndex = 4;
            this.pnlWaveForm.DragDrop += new System.Windows.Forms.DragEventHandler(this.PnlWaveForm_DragDrop);
            this.pnlWaveForm.DragEnter += new System.Windows.Forms.DragEventHandler(this.PnlWaveForm_DragEnter);
            // 
            // lblDnDInfo
            // 
            this.lblDnDInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDnDInfo.AutoSize = true;
            this.lblDnDInfo.Location = new System.Drawing.Point(241, 42);
            this.lblDnDInfo.Name = "lblDnDInfo";
            this.lblDnDInfo.Size = new System.Drawing.Size(151, 15);
            this.lblDnDInfo.TabIndex = 0;
            this.lblDnDInfo.Text = "Превуци медија фајл овде";
            // 
            // транслитерујToolStripMenuItem
            // 
            this.транслитерујToolStripMenuItem.Name = "транслитерујToolStripMenuItem";
            this.транслитерујToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.транслитерујToolStripMenuItem.Text = "Транслитеруј";
            this.транслитерујToolStripMenuItem.Click += new System.EventHandler(this.транслитерујToolStripMenuItem_Click);
            // 
            // FileViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 430);
            this.Controls.Add(this.rtbViewFile);
            this.Controls.Add(this.pnlWaveForm);
            this.Controls.Add(this.pnlFileInfo);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FileViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FileViewForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlFileInfo.ResumeLayout(false);
            this.pnlFileInfo.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlWaveForm.ResumeLayout(false);
            this.pnlWaveForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RichTextBox rtbViewFile;
        private Panel pnlFileInfo;
        private Label lblEncoding;
        private Label lblFileName;
        private Button btnSave;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem снимиКаоToolStripMenuItem;
        private ToolStripMenuItem uTF8ToolStripMenuItem;
        private ToolStripMenuItem windows1250ToolStripMenuItem;
        private ToolStripMenuItem windows1251ToolStripMenuItem;
        private ToolStripMenuItem алатиToolStripMenuItem;
        private ToolStripMenuItem транслитерацијаToolStripMenuItem;
        private Panel pnlWaveForm;
        private Label lblDnDInfo;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem копирајToolStripMenuItem;
        private ToolStripMenuItem транслитерујToolStripMenuItem;
    }
}