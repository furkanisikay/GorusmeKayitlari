namespace GorusmeKayitlari.Extensions.Reminder.UI
{
    partial class AutoCloseOptions
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
            this.chckOtoKapat = new System.Windows.Forms.CheckBox();
            this.grpOtoKapat = new System.Windows.Forms.GroupBox();
            this.lblOtoKapat = new System.Windows.Forms.Label();
            this.tbarOtoKapat = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpOtoKapat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarOtoKapat)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chckOtoKapat
            // 
            this.chckOtoKapat.AutoSize = true;
            this.chckOtoKapat.Checked = true;
            this.chckOtoKapat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckOtoKapat.Location = new System.Drawing.Point(12, 3);
            this.chckOtoKapat.Name = "chckOtoKapat";
            this.chckOtoKapat.Size = new System.Drawing.Size(98, 17);
            this.chckOtoKapat.TabIndex = 0;
            this.chckOtoKapat.Text = "Otomatik kapat";
            this.chckOtoKapat.UseVisualStyleBackColor = true;
            this.chckOtoKapat.CheckedChanged += new System.EventHandler(this.chckOtoKapat_CheckedChanged);
            // 
            // grpOtoKapat
            // 
            this.grpOtoKapat.Controls.Add(this.panel1);
            this.grpOtoKapat.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grpOtoKapat.Location = new System.Drawing.Point(3, 3);
            this.grpOtoKapat.Name = "grpOtoKapat";
            this.grpOtoKapat.Size = new System.Drawing.Size(412, 98);
            this.grpOtoKapat.TabIndex = 1;
            this.grpOtoKapat.TabStop = false;
            // 
            // lblOtoKapat
            // 
            this.lblOtoKapat.Location = new System.Drawing.Point(3, 4);
            this.lblOtoKapat.Name = "lblOtoKapat";
            this.lblOtoKapat.Size = new System.Drawing.Size(400, 29);
            this.lblOtoKapat.TabIndex = 2;
            this.lblOtoKapat.Text = "Hatırlatma penceresi görüntülendikten {0} saniye sonra pencere otomatik kaybolur." +
    "";
            this.lblOtoKapat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbarOtoKapat
            // 
            this.tbarOtoKapat.Location = new System.Drawing.Point(6, 31);
            this.tbarOtoKapat.Maximum = 60;
            this.tbarOtoKapat.Minimum = 1;
            this.tbarOtoKapat.Name = "tbarOtoKapat";
            this.tbarOtoKapat.Size = new System.Drawing.Size(397, 45);
            this.tbarOtoKapat.TabIndex = 1;
            this.tbarOtoKapat.Value = 15;
            this.tbarOtoKapat.ValueChanged += new System.EventHandler(this.tbarOtoKapat_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblOtoKapat);
            this.panel1.Controls.Add(this.tbarOtoKapat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 79);
            this.panel1.TabIndex = 3;
            // 
            // ReminderOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chckOtoKapat);
            this.Controls.Add(this.grpOtoKapat);
            this.Name = "ReminderOptions";
            this.Size = new System.Drawing.Size(418, 113);
            this.Load += new System.EventHandler(this.ReminderOptions_Load);
            this.grpOtoKapat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbarOtoKapat)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chckOtoKapat;
        private System.Windows.Forms.GroupBox grpOtoKapat;
        private System.Windows.Forms.Label lblOtoKapat;
        private System.Windows.Forms.TrackBar tbarOtoKapat;
        private System.Windows.Forms.Panel panel1;
    }
}
