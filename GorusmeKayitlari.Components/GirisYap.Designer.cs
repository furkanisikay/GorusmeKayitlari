namespace GorusmeKayitlari.Components
{
    partial class GirisYap
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
                manager.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisYap));
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtKulAd = new System.Windows.Forms.TextBox();
            this.pboxSifre = new System.Windows.Forms.PictureBox();
            this.pboxKulAd = new System.Windows.Forms.PictureBox();
            this.pboxLogo = new System.Windows.Forms.PictureBox();
            this.bwGiris = new System.ComponentModel.BackgroundWorker();
            this.epMain = new GorusmeKayitlari.Components.CustomErrorProvider(this.components);
            this.yukleniyor1 = new GorusmeKayitlari.Components.Yukleniyor();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSifre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxKulAd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.White;
            this.pnlControls.Controls.Add(this.btnGirisYap);
            this.pnlControls.Controls.Add(this.txtSifre);
            this.pnlControls.Controls.Add(this.txtKulAd);
            this.pnlControls.Controls.Add(this.pboxSifre);
            this.pnlControls.Controls.Add(this.pboxKulAd);
            this.pnlControls.Controls.Add(this.pboxLogo);
            this.pnlControls.Location = new System.Drawing.Point(3, 3);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(325, 238);
            this.pnlControls.TabIndex = 0;
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.Location = new System.Drawing.Point(119, 205);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(85, 30);
            this.btnGirisYap.TabIndex = 2;
            this.btnGirisYap.Text = "Giriş Yap";
            this.btnGirisYap.UseVisualStyleBackColor = true;
            this.btnGirisYap.Click += new System.EventHandler(this.BtnGirisYap_Click);
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(30, 164);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(292, 20);
            this.txtSifre.TabIndex = 1;
            this.txtSifre.UseSystemPasswordChar = true;
            this.txtSifre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSifre_KeyUp);
            // 
            // txtKulAd
            // 
            this.txtKulAd.Location = new System.Drawing.Point(30, 135);
            this.txtKulAd.Name = "txtKulAd";
            this.txtKulAd.Size = new System.Drawing.Size(292, 20);
            this.txtKulAd.TabIndex = 0;
            this.txtKulAd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtKulAd_KeyUp);
            // 
            // pboxSifre
            // 
            this.pboxSifre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pboxSifre.BackColor = System.Drawing.Color.White;
            this.pboxSifre.Image = ((System.Drawing.Image)(resources.GetObject("pboxSifre.Image")));
            this.pboxSifre.Location = new System.Drawing.Point(4, 164);
            this.pboxSifre.Name = "pboxSifre";
            this.pboxSifre.Size = new System.Drawing.Size(20, 20);
            this.pboxSifre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxSifre.TabIndex = 53;
            this.pboxSifre.TabStop = false;
            // 
            // pboxKulAd
            // 
            this.pboxKulAd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pboxKulAd.BackColor = System.Drawing.Color.White;
            this.pboxKulAd.Image = ((System.Drawing.Image)(resources.GetObject("pboxKulAd.Image")));
            this.pboxKulAd.Location = new System.Drawing.Point(3, 134);
            this.pboxKulAd.Name = "pboxKulAd";
            this.pboxKulAd.Size = new System.Drawing.Size(23, 23);
            this.pboxKulAd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxKulAd.TabIndex = 52;
            this.pboxKulAd.TabStop = false;
            // 
            // pboxLogo
            // 
            this.pboxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxLogo.BackColor = System.Drawing.Color.White;
            this.pboxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pboxLogo.Image")));
            this.pboxLogo.Location = new System.Drawing.Point(0, 0);
            this.pboxLogo.Name = "pboxLogo";
            this.pboxLogo.Size = new System.Drawing.Size(328, 128);
            this.pboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxLogo.TabIndex = 49;
            this.pboxLogo.TabStop = false;
            // 
            // bwGiris
            // 
            this.bwGiris.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Bwkul_DoWork);
            this.bwGiris.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Bwkul_RunWorkerCompleted);
            // 
            // epMain
            // 
            this.epMain.AzaltilacakWidth = 20;
            this.epMain.ContainerControl = this;
            this.epMain.Icon = ((System.Drawing.Icon)(resources.GetObject("epMain.Icon")));
            // 
            // yukleniyor1
            // 
            this.yukleniyor1.BackColor = System.Drawing.Color.White;
            this.yukleniyor1.Location = new System.Drawing.Point(305, 247);
            this.yukleniyor1.Name = "yukleniyor1";
            this.yukleniyor1.Size = new System.Drawing.Size(27, 13);
            this.yukleniyor1.TabIndex = 53;
            this.yukleniyor1.TabStop = false;
            this.yukleniyor1.Visible = false;
            this.yukleniyor1.Yazi = "Yükleniyor...";
            this.yukleniyor1.YaziFontu = new System.Drawing.Font("Segoe UI", 10F);
            this.yukleniyor1.YaziGoster = true;
            // 
            // GirisYap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.yukleniyor1);
            this.Controls.Add(this.pnlControls);
            this.MinimumSize = new System.Drawing.Size(332, 244);
            this.Name = "GirisYap";
            this.Size = new System.Drawing.Size(332, 244);
            this.Load += new System.EventHandler(this.GirisYap_Load);
            this.SizeChanged += new System.EventHandler(this.GirisYapForm_SizeChanged);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSifre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxKulAd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pboxSifre;
        private System.Windows.Forms.PictureBox pboxKulAd;
        private System.Windows.Forms.PictureBox pboxLogo;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btnGirisYap;
        private System.ComponentModel.BackgroundWorker bwGiris;
        private CustomErrorProvider epMain;
        private Yukleniyor yukleniyor1;
        public System.Windows.Forms.Panel pnlControls;
        public System.Windows.Forms.TextBox txtKulAd;
    }
}
