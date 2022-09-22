namespace SubConvert
{
    partial class FileOverwriteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileOverwriteForm));
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnOverwrite = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCheckAgain = new System.Windows.Forms.Button();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(431, 47);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Можете да промените назив фајла. Опције препиши и поново провери назив фајла кори" +
    "стиће назив унет у овом пољу:";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOverwrite
            // 
            this.btnOverwrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOverwrite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOverwrite.Location = new System.Drawing.Point(12, 112);
            this.btnOverwrite.Name = "btnOverwrite";
            this.btnOverwrite.Size = new System.Drawing.Size(122, 52);
            this.btnOverwrite.TabIndex = 1;
            this.btnOverwrite.Text = "ПРЕПИШИ!";
            this.btnOverwrite.UseVisualStyleBackColor = true;
            this.btnOverwrite.Click += new System.EventHandler(this.btnOverwrite_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(321, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 52);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "не креирај овај фајл";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnCheckAgain
            // 
            this.btnCheckAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckAgain.Location = new System.Drawing.Point(140, 112);
            this.btnCheckAgain.Name = "btnCheckAgain";
            this.btnCheckAgain.Size = new System.Drawing.Size(122, 52);
            this.btnCheckAgain.TabIndex = 4;
            this.btnCheckAgain.Text = "поново провери назив фајла";
            this.btnCheckAgain.UseVisualStyleBackColor = true;
            this.btnCheckAgain.Click += new System.EventHandler(this.btnCheckAgain_Click);
            // 
            // tbFileName
            // 
            this.tbFileName.BackColor = System.Drawing.Color.MistyRose;
            this.tbFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFileName.Location = new System.Drawing.Point(12, 72);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(431, 23);
            this.tbFileName.TabIndex = 5;
            // 
            // FileOverwriteForm
            // 
            this.AcceptButton = this.btnOverwrite;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(455, 176);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.btnCheckAgain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOverwrite);
            this.Controls.Add(this.lblInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(471, 215);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(471, 215);
            this.Name = "FileOverwriteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Фајл већ постоји!";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblInfo;
        private Button btnOverwrite;
        private Button btnCancel;
        private Button btnCheckAgain;
        private TextBox tbFileName;
    }
}