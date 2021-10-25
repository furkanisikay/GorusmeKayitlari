namespace GorusmeKayitlari.Components.KullaniciHesapBilesenleri
{
    partial class Yetkiler
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
            this.txtYetkiler = new System.Windows.Forms.TextBox();
            this.btnSec = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtYetkiler
            // 
            this.txtYetkiler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYetkiler.Location = new System.Drawing.Point(0, 0);
            this.txtYetkiler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtYetkiler.Name = "txtYetkiler";
            this.txtYetkiler.ReadOnly = true;
            this.txtYetkiler.Size = new System.Drawing.Size(288, 25);
            this.txtYetkiler.TabIndex = 0;
            this.txtYetkiler.Text = "(yok)";
            // 
            // btnSec
            // 
            this.btnSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSec.Location = new System.Drawing.Point(294, 0);
            this.btnSec.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(49, 25);
            this.btnSec.TabIndex = 1;
            this.btnSec.Text = "Seç";
            this.btnSec.UseVisualStyleBackColor = true;
            this.btnSec.Click += new System.EventHandler(this.BtnSec_Click);
            // 
            // Yetkiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.txtYetkiler);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Yetkiler";
            this.Size = new System.Drawing.Size(343, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtYetkiler;
        private System.Windows.Forms.Button btnSec;
    }
}
