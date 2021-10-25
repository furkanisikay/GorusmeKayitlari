namespace GorusmeKayitlari.Reminder.Formlar
{
    partial class HatirlatmaListesi
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

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HatirlatmaListesi));
            this.lstHatirlatmalar = new System.Windows.Forms.ListView();
            this.clmMetin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTarih = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsHatırlatmaListesi = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnHatirlatmaEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHatirlatmaDuzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHatirlatmaSil = new System.Windows.Forms.ToolStripMenuItem();
            this.bwHatirlatmaYukle = new System.ComponentModel.BackgroundWorker();
            this.ssHatirlatma = new System.Windows.Forms.StatusStrip();
            this.lblDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.yukleniyor1 = new GorusmeKayitlari.Components.Yukleniyor();
            this.bwHatirlatmalariYukle = new System.ComponentModel.BackgroundWorker();
            this.cmsHatırlatmaListesi.SuspendLayout();
            this.ssHatirlatma.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstHatirlatmalar
            // 
            this.lstHatirlatmalar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmMetin,
            this.clmTarih});
            this.lstHatirlatmalar.ContextMenuStrip = this.cmsHatırlatmaListesi;
            this.lstHatirlatmalar.Location = new System.Drawing.Point(12, 12);
            this.lstHatirlatmalar.Name = "lstHatirlatmalar";
            this.lstHatirlatmalar.Size = new System.Drawing.Size(475, 304);
            this.lstHatirlatmalar.TabIndex = 0;
            this.lstHatirlatmalar.UseCompatibleStateImageBehavior = false;
            this.lstHatirlatmalar.View = System.Windows.Forms.View.Details;
            // 
            // clmMetin
            // 
            this.clmMetin.Text = "Hatırlatma Metni";
            this.clmMetin.Width = 349;
            // 
            // clmTarih
            // 
            this.clmTarih.Text = "Hatırlatma Tarihi";
            this.clmTarih.Width = 121;
            // 
            // cmsHatırlatmaListesi
            // 
            this.cmsHatırlatmaListesi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHatirlatmaEkle,
            this.btnHatirlatmaDuzenle,
            this.btnHatirlatmaSil});
            this.cmsHatırlatmaListesi.Name = "cmsHatırlatmaListesi";
            this.cmsHatırlatmaListesi.Size = new System.Drawing.Size(117, 70);
            // 
            // btnHatirlatmaEkle
            // 
            this.btnHatirlatmaEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnHatirlatmaEkle.Image")));
            this.btnHatirlatmaEkle.Name = "btnHatirlatmaEkle";
            this.btnHatirlatmaEkle.Size = new System.Drawing.Size(116, 22);
            this.btnHatirlatmaEkle.Text = "Ekle";
            this.btnHatirlatmaEkle.Click += new System.EventHandler(this.BtnHatirlatmaEkle_Click);
            // 
            // btnHatirlatmaDuzenle
            // 
            this.btnHatirlatmaDuzenle.Image = ((System.Drawing.Image)(resources.GetObject("btnHatirlatmaDuzenle.Image")));
            this.btnHatirlatmaDuzenle.Name = "btnHatirlatmaDuzenle";
            this.btnHatirlatmaDuzenle.Size = new System.Drawing.Size(116, 22);
            this.btnHatirlatmaDuzenle.Text = "Düzenle";
            this.btnHatirlatmaDuzenle.Click += new System.EventHandler(this.BtnHatirlatmaDuzenle_Click);
            // 
            // btnHatirlatmaSil
            // 
            this.btnHatirlatmaSil.Image = ((System.Drawing.Image)(resources.GetObject("btnHatirlatmaSil.Image")));
            this.btnHatirlatmaSil.Name = "btnHatirlatmaSil";
            this.btnHatirlatmaSil.Size = new System.Drawing.Size(116, 22);
            this.btnHatirlatmaSil.Text = "Sil";
            this.btnHatirlatmaSil.Click += new System.EventHandler(this.BtnHatirlatmaSil_Click);
            // 
            // ssHatirlatma
            // 
            this.ssHatirlatma.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDurum});
            this.ssHatirlatma.Location = new System.Drawing.Point(0, 319);
            this.ssHatirlatma.Name = "ssHatirlatma";
            this.ssHatirlatma.Size = new System.Drawing.Size(499, 22);
            this.ssHatirlatma.TabIndex = 1;
            this.ssHatirlatma.Text = "statusStrip1";
            // 
            // lblDurum
            // 
            this.lblDurum.BackColor = System.Drawing.SystemColors.Control;
            this.lblDurum.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(139, 17);
            this.lblDurum.Text = "Durum : İşlem bekleniyor";
            // 
            // yukleniyor1
            // 
            this.yukleniyor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yukleniyor1.BackColor = System.Drawing.Color.White;
            this.yukleniyor1.Location = new System.Drawing.Point(95, 82);
            this.yukleniyor1.Name = "yukleniyor1";
            this.yukleniyor1.Size = new System.Drawing.Size(309, 165);
            this.yukleniyor1.TabIndex = 3;
            this.yukleniyor1.Visible = false;
            this.yukleniyor1.Yazi = "Yükleniyor...";
            this.yukleniyor1.YaziFontu = new System.Drawing.Font("Segoe UI", 11F);
            this.yukleniyor1.YaziGoster = true;
            // 
            // bwHatirlatmalariYukle
            // 
            this.bwHatirlatmalariYukle.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwHatirlatmalariYukle_DoWork);
            this.bwHatirlatmalariYukle.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwHatirlatmalariYukle_RunWorkerCompleted);
            // 
            // HatirlatmaListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 341);
            this.Controls.Add(this.yukleniyor1);
            this.Controls.Add(this.ssHatirlatma);
            this.Controls.Add(this.lstHatirlatmalar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HatirlatmaListesi";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Görüşme Hatırlatıcı";
            this.Load += new System.EventHandler(this.HatirlatmaListesi_Load);
            this.cmsHatırlatmaListesi.ResumeLayout(false);
            this.ssHatirlatma.ResumeLayout(false);
            this.ssHatirlatma.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstHatirlatmalar;
        private System.Windows.Forms.ColumnHeader clmMetin;
        private System.Windows.Forms.ColumnHeader clmTarih;
        private System.Windows.Forms.ContextMenuStrip cmsHatırlatmaListesi;
        private System.Windows.Forms.ToolStripMenuItem btnHatirlatmaEkle;
        private System.Windows.Forms.ToolStripMenuItem btnHatirlatmaDuzenle;
        private System.Windows.Forms.ToolStripMenuItem btnHatirlatmaSil;
        private System.ComponentModel.BackgroundWorker bwHatirlatmaYukle;
        private System.Windows.Forms.StatusStrip ssHatirlatma;
        private Components.Yukleniyor yukleniyor1;
        private System.ComponentModel.BackgroundWorker bwHatirlatmalariYukle;
        private System.Windows.Forms.ToolStripStatusLabel lblDurum;
    }
}

