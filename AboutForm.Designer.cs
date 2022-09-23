namespace SubConvert
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.llUTFUnknown = new System.Windows.Forms.LinkLabel();
            this.llCyrillicConvert = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.llMail = new System.Windows.Forms.LinkLabel();
            this.lblNAudio = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // llUTFUnknown
            // 
            this.llUTFUnknown.AutoSize = true;
            this.llUTFUnknown.Location = new System.Drawing.Point(14, 176);
            this.llUTFUnknown.Name = "llUTFUnknown";
            this.llUTFUnknown.Size = new System.Drawing.Size(98, 20);
            this.llUTFUnknown.TabIndex = 0;
            this.llUTFUnknown.TabStop = true;
            this.llUTFUnknown.Text = "UTF.Unknown";
            this.llUTFUnknown.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlUTFUnknown_LinkClicked);
            // 
            // llCyrillicConvert
            // 
            this.llCyrillicConvert.AutoSize = true;
            this.llCyrillicConvert.Location = new System.Drawing.Point(14, 212);
            this.llCyrillicConvert.Name = "llCyrillicConvert";
            this.llCyrillicConvert.Size = new System.Drawing.Size(107, 20);
            this.llCyrillicConvert.TabIndex = 1;
            this.llCyrillicConvert.TabStop = true;
            this.llCyrillicConvert.Text = "Cyrillic.Convert";
            this.llCyrillicConvert.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlCyrillicConvert_LinkClicked);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 144);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Контакт:";
            // 
            // llMail
            // 
            this.llMail.AutoSize = true;
            this.llMail.Location = new System.Drawing.Point(14, 293);
            this.llMail.Name = "llMail";
            this.llMail.Size = new System.Drawing.Size(178, 20);
            this.llMail.TabIndex = 4;
            this.llMail.TabStop = true;
            this.llMail.Text = "subconvert@outlook.com";
            this.llMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlMail_LinkClicked);
            // 
            // lblNAudio
            // 
            this.lblNAudio.AutoSize = true;
            this.lblNAudio.Location = new System.Drawing.Point(158, 176);
            this.lblNAudio.Name = "lblNAudio";
            this.lblNAudio.Size = new System.Drawing.Size(60, 20);
            this.lblNAudio.TabIndex = 5;
            this.lblNAudio.TabStop = true;
            this.lblNAudio.Text = "NAudio";
            this.lblNAudio.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNAudio_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 364);
            this.Controls.Add(this.lblNAudio);
            this.Controls.Add(this.llMail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.llCyrillicConvert);
            this.Controls.Add(this.llUTFUnknown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(523, 411);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(523, 411);
            this.Name = "AboutForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О програму";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LinkLabel llUTFUnknown;
        private LinkLabel llCyrillicConvert;
        private Label label1;
        private Label label2;
        private LinkLabel llMail;
        private LinkLabel lblNAudio;
    }
}