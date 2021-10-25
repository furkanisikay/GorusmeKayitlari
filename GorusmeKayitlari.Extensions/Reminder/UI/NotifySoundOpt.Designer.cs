namespace GorusmeKayitlari.Extensions.Reminder.UI
{
    partial class NotifySoundOpt
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpNotfSound = new System.Windows.Forms.GroupBox();
            this.chckNotfSound = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.txtNotSound = new System.Windows.Forms.TextBox();
            this.lblNotifyDosyasi = new System.Windows.Forms.Label();
            this.btnNotSoundGozat = new GorusmeKayitlari.Extensions.GozatButton(this.components);
            this.grpNotfSound.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNotfSound
            // 
            this.grpNotfSound.Controls.Add(this.chckNotfSound);
            this.grpNotfSound.Controls.Add(this.panel1);
            this.grpNotfSound.Location = new System.Drawing.Point(3, 3);
            this.grpNotfSound.Name = "grpNotfSound";
            this.grpNotfSound.Size = new System.Drawing.Size(416, 81);
            this.grpNotfSound.TabIndex = 6;
            this.grpNotfSound.TabStop = false;
            // 
            // chckNotfSound
            // 
            this.chckNotfSound.AutoSize = true;
            this.chckNotfSound.Checked = true;
            this.chckNotfSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckNotfSound.Location = new System.Drawing.Point(6, 0);
            this.chckNotfSound.Name = "chckNotfSound";
            this.chckNotfSound.Size = new System.Drawing.Size(81, 17);
            this.chckNotfSound.TabIndex = 9;
            this.chckNotfSound.Text = "Bildirim Sesi";
            this.chckNotfSound.UseVisualStyleBackColor = true;
            this.chckNotfSound.CheckedChanged += new System.EventHandler(this.chckNotfSound_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAciklama);
            this.panel1.Controls.Add(this.txtNotSound);
            this.panel1.Controls.Add(this.lblNotifyDosyasi);
            this.panel1.Controls.Add(this.btnNotSoundGozat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 62);
            this.panel1.TabIndex = 8;
            // 
            // lblAciklama
            // 
            this.lblAciklama.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAciklama.Location = new System.Drawing.Point(3, 4);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(404, 30);
            this.lblAciklama.TabIndex = 5;
            this.lblAciklama.Text = "Hatırlatmaların bildirimi gösterilirken arkaplanda oynatılacak bildirim sesi.";
            this.lblAciklama.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNotSound
            // 
            this.txtNotSound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotSound.Location = new System.Drawing.Point(105, 38);
            this.txtNotSound.Name = "txtNotSound";
            this.txtNotSound.ReadOnly = true;
            this.txtNotSound.Size = new System.Drawing.Size(221, 20);
            this.txtNotSound.TabIndex = 3;
            // 
            // lblNotifyDosyasi
            // 
            this.lblNotifyDosyasi.AutoSize = true;
            this.lblNotifyDosyasi.Location = new System.Drawing.Point(3, 41);
            this.lblNotifyDosyasi.Name = "lblNotifyDosyasi";
            this.lblNotifyDosyasi.Size = new System.Drawing.Size(96, 13);
            this.lblNotifyDosyasi.TabIndex = 4;
            this.lblNotifyDosyasi.Text = "Oynatılacak Dosya";
            // 
            // btnNotSoundGozat
            // 
            this.btnNotSoundGozat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotSoundGozat.Baslik = "Hatırlatmalar için bildirim sesi dosyası seçin";
            this.btnNotSoundGozat.DosyaUzantilari = "";
            this.btnNotSoundGozat.Location = new System.Drawing.Point(332, 36);
            this.btnNotSoundGozat.Name = "btnNotSoundGozat";
            this.btnNotSoundGozat.Size = new System.Drawing.Size(75, 23);
            this.btnNotSoundGozat.TabIndex = 2;
            this.btnNotSoundGozat.Text = "Gözat";
            this.btnNotSoundGozat.UseVisualStyleBackColor = true;
            this.btnNotSoundGozat.VarsayilanUzanti = "";
            this.btnNotSoundGozat.SecilenDosyaDegistiginde += new System.EventHandler<string>(this.btnNotSoundGozat_SecilenDosyaDegistiginde);
            // 
            // NotifySoundOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpNotfSound);
            this.Name = "NotifySoundOpt";
            this.Size = new System.Drawing.Size(422, 87);
            this.Load += new System.EventHandler(this.NotifySoundOpt_Load);
            this.grpNotfSound.ResumeLayout(false);
            this.grpNotfSound.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpNotfSound;
        private System.Windows.Forms.Label lblNotifyDosyasi;
        private System.Windows.Forms.TextBox txtNotSound;
        private GozatButton btnNotSoundGozat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.CheckBox chckNotfSound;
    }
}
