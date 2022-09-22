namespace SubConvert
{
    partial class ErrorMessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorMessageForm));
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblStacktrace = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Location = new System.Drawing.Point(12, 9);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(732, 121);
            this.lblErrorMessage.TabIndex = 2;
            // 
            // lblStacktrace
            // 
            this.lblStacktrace.Location = new System.Drawing.Point(12, 153);
            this.lblStacktrace.Name = "lblStacktrace";
            this.lblStacktrace.Size = new System.Drawing.Size(732, 123);
            this.lblStacktrace.TabIndex = 3;
            // 
            // ErrorMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 289);
            this.Controls.Add(this.lblStacktrace);
            this.Controls.Add(this.lblErrorMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(460, 320);
            this.Name = "ErrorMessageForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Грешка";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblErrorMessage;
        private Label lblStacktrace;
    }
}