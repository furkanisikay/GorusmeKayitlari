namespace GorusmeKayitlari.Components.ExcelBilesenleri
{
    partial class RenkKutusu
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
            this.pBoxRenk = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRenk)).BeginInit();
            this.SuspendLayout();
            // 
            // pBoxRenk
            // 
            this.pBoxRenk.BackColor = System.Drawing.Color.White;
            this.pBoxRenk.Location = new System.Drawing.Point(1, 1);
            this.pBoxRenk.Name = "pBoxRenk";
            this.pBoxRenk.Size = new System.Drawing.Size(16, 16);
            this.pBoxRenk.TabIndex = 0;
            this.pBoxRenk.TabStop = false;
            this.pBoxRenk.BackColorChanged += new System.EventHandler(this.pBoxRenk_BackColorChanged);
            this.pBoxRenk.Click += new System.EventHandler(this.pBoxRenk_Click);
            // 
            // RenkKutusu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pBoxRenk);
            this.Name = "RenkKutusu";
            this.Size = new System.Drawing.Size(18, 18);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRenk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pBoxRenk;
    }
}
