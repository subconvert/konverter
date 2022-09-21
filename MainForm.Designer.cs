namespace SubConvert
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAutomatic = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.титловиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windows1250UTF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windows1251UTF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windows1252UTF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uTF8ANSIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.аутоматскаДетекцијаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограмуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAutomatic);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(214, 145);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnAutomatic
            // 
            this.btnAutomatic.AllowDrop = true;
            this.btnAutomatic.BackgroundImage = global::SubConvert.Properties.Resources.konverter5;
            this.btnAutomatic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAutomatic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutomatic.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAutomatic.Location = new System.Drawing.Point(3, 3);
            this.btnAutomatic.Name = "btnAutomatic";
            this.btnAutomatic.Size = new System.Drawing.Size(207, 140);
            this.btnAutomatic.TabIndex = 2;
            this.btnAutomatic.TabStop = false;
            this.btnAutomatic.UseVisualStyleBackColor = true;
            this.btnAutomatic.Click += new System.EventHandler(this.BtnAutomatic_Click);
            this.btnAutomatic.DragDrop += new System.Windows.Forms.DragEventHandler(this.BtnAutomatic_DragDrop);
            this.btnAutomatic.DragEnter += new System.Windows.Forms.DragEventHandler(this.BtnAutomatic_DragEnter);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.титловиToolStripMenuItem,
            this.оПрограмуToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(214, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // титловиToolStripMenuItem
            // 
            this.титловиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windows1250UTF8ToolStripMenuItem,
            this.windows1251UTF8ToolStripMenuItem,
            this.windows1252UTF8ToolStripMenuItem,
            this.uTF8ANSIToolStripMenuItem,
            this.toolStripSeparator1,
            this.аутоматскаДетекцијаToolStripMenuItem});
            this.титловиToolStripMenuItem.Name = "титловиToolStripMenuItem";
            this.титловиToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.титловиToolStripMenuItem.Text = "Титлови";
            // 
            // windows1250UTF8ToolStripMenuItem
            // 
            this.windows1250UTF8ToolStripMenuItem.Name = "windows1250UTF8ToolStripMenuItem";
            this.windows1250UTF8ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.windows1250UTF8ToolStripMenuItem.Text = "windows-1250 -> UTF-8";
            this.windows1250UTF8ToolStripMenuItem.Click += new System.EventHandler(this.Windows1250UTF8ToolStripMenuItem_Click);
            // 
            // windows1251UTF8ToolStripMenuItem
            // 
            this.windows1251UTF8ToolStripMenuItem.Name = "windows1251UTF8ToolStripMenuItem";
            this.windows1251UTF8ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.windows1251UTF8ToolStripMenuItem.Text = "windows-1251 -> UTF-8";
            this.windows1251UTF8ToolStripMenuItem.Click += new System.EventHandler(this.Windows1251UTF8ToolStripMenuItem_Click);
            // 
            // windows1252UTF8ToolStripMenuItem
            // 
            this.windows1252UTF8ToolStripMenuItem.Name = "windows1252UTF8ToolStripMenuItem";
            this.windows1252UTF8ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.windows1252UTF8ToolStripMenuItem.Text = "windows-1252 -> UTF-8";
            this.windows1252UTF8ToolStripMenuItem.Click += new System.EventHandler(this.Windows1252UTF8ToolStripMenuItem_Click);
            // 
            // uTF8ANSIToolStripMenuItem
            // 
            this.uTF8ANSIToolStripMenuItem.Name = "uTF8ANSIToolStripMenuItem";
            this.uTF8ANSIToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.uTF8ANSIToolStripMenuItem.Text = "UTF-8 -> ANSI";
            this.uTF8ANSIToolStripMenuItem.Click += new System.EventHandler(this.UTF8ANSIToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);
            // 
            // аутоматскаДетекцијаToolStripMenuItem
            // 
            this.аутоматскаДетекцијаToolStripMenuItem.Name = "аутоматскаДетекцијаToolStripMenuItem";
            this.аутоматскаДетекцијаToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.аутоматскаДетекцијаToolStripMenuItem.Text = "аутоматска детекција";
            this.аутоматскаДетекцијаToolStripMenuItem.Click += new System.EventHandler(this.АутоматскаДетекцијаToolStripMenuItem_Click);
            // 
            // оПрограмуToolStripMenuItem
            // 
            this.оПрограмуToolStripMenuItem.Name = "оПрограмуToolStripMenuItem";
            this.оПрограмуToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.оПрограмуToolStripMenuItem.Text = "О програму";
            this.оПрограмуToolStripMenuItem.Click += new System.EventHandler(this.ОПрограмуToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 169);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(230, 208);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(230, 208);
            this.Name = "MainForm";
            this.Text = "Конвертер";
            this.TopMost = true;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnAutomatic;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem титловиToolStripMenuItem;
        private ToolStripMenuItem windows1250UTF8ToolStripMenuItem;
        private ToolStripMenuItem windows1251UTF8ToolStripMenuItem;
        private ToolStripMenuItem аутоматскаДетекцијаToolStripMenuItem;
        private ToolStripMenuItem uTF8ANSIToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem windows1252UTF8ToolStripMenuItem;
        private ToolStripMenuItem оПрограмуToolStripMenuItem;
    }
}