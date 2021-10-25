namespace GorusmeKayitlari.App.Bilesenler
{
    partial class NesneSec
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
            this.btnNesneSec = new System.Windows.Forms.Button();
            this.txtNesne = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnNesneSec
            // 
            this.btnNesneSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNesneSec.Location = new System.Drawing.Point(294, 0);
            this.btnNesneSec.Name = "btnNesneSec";
            this.btnNesneSec.Size = new System.Drawing.Size(49, 25);
            this.btnNesneSec.TabIndex = 11;
            this.btnNesneSec.Text = "Seç";
            this.btnNesneSec.UseVisualStyleBackColor = true;
            this.btnNesneSec.Click += new System.EventHandler(this.BtnNesneSec_Click);
            this.btnNesneSec.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BtnNesneSec_KeyUp);
            // 
            // txtNesne
            // 
            this.txtNesne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNesne.Location = new System.Drawing.Point(0, 0);
            this.txtNesne.MaxLength = 255;
            this.txtNesne.Name = "txtNesne";
            this.txtNesne.ReadOnly = true;
            this.txtNesne.Size = new System.Drawing.Size(288, 25);
            this.txtNesne.TabIndex = 10;
            this.txtNesne.Text = "(yok)";
            this.txtNesne.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtNesne_KeyUp);
            // 
            // NesneSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNesneSec);
            this.Controls.Add(this.txtNesne);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NesneSec";
            this.Size = new System.Drawing.Size(343, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNesneSec;
        private System.Windows.Forms.TextBox txtNesne;
    }
}
