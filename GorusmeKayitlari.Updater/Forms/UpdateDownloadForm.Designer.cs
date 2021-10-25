namespace GorusmeKayitlari.Updater.Forms
{
    partial class UpdateDownloadForm
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
            this.lblDownloading = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblDownSpeed = new System.Windows.Forms.Label();
            this.lblRemaTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDownloading
            // 
            this.lblDownloading.AutoSize = true;
            this.lblDownloading.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lblDownloading.Location = new System.Drawing.Point(25, 43);
            this.lblDownloading.Name = "lblDownloading";
            this.lblDownloading.Size = new System.Drawing.Size(352, 45);
            this.lblDownloading.TabIndex = 0;
            this.lblDownloading.Text = "Güncelleme İndiriliyor...";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(33, 97);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(344, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            // 
            // lblProgress
            // 
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblProgress.Location = new System.Drawing.Point(33, 123);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(344, 21);
            this.lblProgress.TabIndex = 2;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDownSpeed
            // 
            this.lblDownSpeed.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDownSpeed.Location = new System.Drawing.Point(33, 144);
            this.lblDownSpeed.Name = "lblDownSpeed";
            this.lblDownSpeed.Size = new System.Drawing.Size(344, 21);
            this.lblDownSpeed.TabIndex = 2;
            this.lblDownSpeed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRemaTime
            // 
            this.lblRemaTime.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRemaTime.Location = new System.Drawing.Point(33, 165);
            this.lblRemaTime.Name = "lblRemaTime";
            this.lblRemaTime.Size = new System.Drawing.Size(344, 21);
            this.lblRemaTime.TabIndex = 2;
            this.lblRemaTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UpdateDownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 230);
            this.Controls.Add(this.lblRemaTime);
            this.Controls.Add(this.lblDownSpeed);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblDownloading);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateDownloadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Güncelleme İndiriliyor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateDownloadForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDownloading;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblDownSpeed;
        private System.Windows.Forms.Label lblRemaTime;
    }
}