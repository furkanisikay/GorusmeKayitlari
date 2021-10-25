namespace GorusmeKayitlari.Updater.Forms
{
    partial class UpdateInfoForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lblVersions = new System.Windows.Forms.Label();
            this.txtDecription = new System.Windows.Forms.RichTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::GorusmeKayitlari.Updater.Properties.Resources.update;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(80, 80);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // lblVersions
            // 
            this.lblVersions.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblVersions.Location = new System.Drawing.Point(104, 25);
            this.lblVersions.Name = "lblVersions";
            this.lblVersions.Size = new System.Drawing.Size(158, 54);
            this.lblVersions.TabIndex = 1;
            this.lblVersions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDecription
            // 
            this.txtDecription.BackColor = System.Drawing.SystemColors.Control;
            this.txtDecription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDecription.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDecription.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtDecription.Location = new System.Drawing.Point(12, 116);
            this.txtDecription.Name = "txtDecription";
            this.txtDecription.ReadOnly = true;
            this.txtDecription.Size = new System.Drawing.Size(250, 96);
            this.txtDecription.TabIndex = 2;
            this.txtDecription.TabStop = false;
            this.txtDecription.Text = "";
            this.txtDecription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDecription_KeyDown);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblDescription.Location = new System.Drawing.Point(9, 100);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(52, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Açıklama";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnBack.Location = new System.Drawing.Point(101, 218);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(73, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "Geri";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // UpdateInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 248);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDecription);
            this.Controls.Add(this.lblVersions);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateInfoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lblVersions;
        private System.Windows.Forms.RichTextBox txtDecription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnBack;
    }
}