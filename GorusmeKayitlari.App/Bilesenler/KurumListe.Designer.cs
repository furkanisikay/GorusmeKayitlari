namespace GorusmeKayitlari.App.Bilesenler
{ 
    partial class KurumListe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KurumListe));
            this.lstKurumlar = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsKurumlar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsKurumlar_Goruntule = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsKurumlar_Ekle = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsKurumlar_Duzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsKurumlar_Sil = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsKurumlar_TumunuGoruntule = new System.Windows.Forms.ToolStripMenuItem();
            this.yukleniyor1 = new GorusmeKayitlari.Components.Yukleniyor();
            this.bwKurumYukle = new System.ComponentModel.BackgroundWorker();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.lblDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmsKurumlar.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstKurumlar
            // 
            this.lstKurumlar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstKurumlar.ContextMenuStrip = this.cmsKurumlar;
            this.lstKurumlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstKurumlar.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstKurumlar.Location = new System.Drawing.Point(0, 0);
            this.lstKurumlar.Name = "lstKurumlar";
            this.lstKurumlar.Size = new System.Drawing.Size(286, 352);
            this.lstKurumlar.TabIndex = 0;
            this.lstKurumlar.UseCompatibleStateImageBehavior = false;
            this.lstKurumlar.View = System.Windows.Forms.View.Details;
            this.lstKurumlar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LstKurumlar_KeyUp);
            this.lstKurumlar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LstKurumlar_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Kurumlar";
            this.columnHeader1.Width = 282;
            // 
            // cmsKurumlar
            // 
            this.cmsKurumlar.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmsKurumlar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsKurumlar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsKurumlar_Goruntule,
            this.toolStripSeparator2,
            this.cmsKurumlar_Ekle,
            this.cmsKurumlar_Duzenle,
            this.cmsKurumlar_Sil,
            this.toolStripSeparator1,
            this.cmsKurumlar_TumunuGoruntule});
            this.cmsKurumlar.Name = "contextMenuStrip1";
            this.cmsKurumlar.Size = new System.Drawing.Size(200, 146);
            this.cmsKurumlar.Opening += new System.ComponentModel.CancelEventHandler(this.CmsKurumlar_Opening);
            // 
            // cmsKurumlar_Goruntule
            // 
            this.cmsKurumlar_Goruntule.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            this.cmsKurumlar_Goruntule.Image = ((System.Drawing.Image)(resources.GetObject("cmsKurumlar_Goruntule.Image")));
            this.cmsKurumlar_Goruntule.Name = "cmsKurumlar_Goruntule";
            this.cmsKurumlar_Goruntule.Size = new System.Drawing.Size(199, 26);
            this.cmsKurumlar_Goruntule.Text = "Görüntüle";
            this.cmsKurumlar_Goruntule.Click += new System.EventHandler(this.CmsKurumlar_Goruntule_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // cmsKurumlar_Ekle
            // 
            this.cmsKurumlar_Ekle.Image = ((System.Drawing.Image)(resources.GetObject("cmsKurumlar_Ekle.Image")));
            this.cmsKurumlar_Ekle.Name = "cmsKurumlar_Ekle";
            this.cmsKurumlar_Ekle.Size = new System.Drawing.Size(199, 26);
            this.cmsKurumlar_Ekle.Text = "Ekle";
            this.cmsKurumlar_Ekle.ToolTipText = "Yeni bir kurum ekler.";
            this.cmsKurumlar_Ekle.Click += new System.EventHandler(this.CmsKurumlar_Ekle_Click);
            // 
            // cmsKurumlar_Duzenle
            // 
            this.cmsKurumlar_Duzenle.Image = ((System.Drawing.Image)(resources.GetObject("cmsKurumlar_Duzenle.Image")));
            this.cmsKurumlar_Duzenle.Name = "cmsKurumlar_Duzenle";
            this.cmsKurumlar_Duzenle.Size = new System.Drawing.Size(199, 26);
            this.cmsKurumlar_Duzenle.Text = "Düzenle";
            this.cmsKurumlar_Duzenle.ToolTipText = "Seçilen kurumu düzenler.";
            this.cmsKurumlar_Duzenle.Click += new System.EventHandler(this.CmsKurumlar_Duzenle_Click);
            // 
            // cmsKurumlar_Sil
            // 
            this.cmsKurumlar_Sil.Image = ((System.Drawing.Image)(resources.GetObject("cmsKurumlar_Sil.Image")));
            this.cmsKurumlar_Sil.Name = "cmsKurumlar_Sil";
            this.cmsKurumlar_Sil.Size = new System.Drawing.Size(199, 26);
            this.cmsKurumlar_Sil.Text = "Sil";
            this.cmsKurumlar_Sil.Click += new System.EventHandler(this.CmsKurumlar_Sil_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // cmsKurumlar_TumunuGoruntule
            // 
            this.cmsKurumlar_TumunuGoruntule.Image = ((System.Drawing.Image)(resources.GetObject("cmsKurumlar_TumunuGoruntule.Image")));
            this.cmsKurumlar_TumunuGoruntule.Name = "cmsKurumlar_TumunuGoruntule";
            this.cmsKurumlar_TumunuGoruntule.Size = new System.Drawing.Size(199, 26);
            this.cmsKurumlar_TumunuGoruntule.Text = "Tümünü Görüntüle";
            this.cmsKurumlar_TumunuGoruntule.ToolTipText = "Görüntülenen kategori ve alt kategorilerine ait kurumların görüşmeleri görüntüler" +
    ".";
            this.cmsKurumlar_TumunuGoruntule.Click += new System.EventHandler(this.CmsKurumlar_TumunuGoruntule_Click);
            // 
            // yukleniyor1
            // 
            this.yukleniyor1.BackColor = System.Drawing.Color.White;
            this.yukleniyor1.Location = new System.Drawing.Point(43, 122);
            this.yukleniyor1.Name = "yukleniyor1";
            this.yukleniyor1.Size = new System.Drawing.Size(200, 153);
            this.yukleniyor1.TabIndex = 2;
            this.yukleniyor1.Visible = false;
            this.yukleniyor1.Yazi = "Yükleniyor...";
            this.yukleniyor1.YaziFontu = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yukleniyor1.YaziGoster = false;
            // 
            // bwKurumYukle
            // 
            this.bwKurumYukle.WorkerSupportsCancellation = true;
            this.bwKurumYukle.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwKurumYukle_DoWork);
            this.bwKurumYukle.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwKurumYukle_RunWorkerCompleted);
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDurum});
            this.ssMain.Location = new System.Drawing.Point(0, 352);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(286, 22);
            this.ssMain.TabIndex = 5;
            this.ssMain.Text = "statusStrip1";
            // 
            // lblDurum
            // 
            this.lblDurum.BackColor = System.Drawing.SystemColors.Control;
            this.lblDurum.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(139, 17);
            this.lblDurum.Text = "Durum : İşlem bekleniyor";
            // 
            // KurumListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.yukleniyor1);
            this.Controls.Add(this.lstKurumlar);
            this.Controls.Add(this.ssMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "KurumListe";
            this.Size = new System.Drawing.Size(286, 374);
            this.Load += new System.EventHandler(this.KurumListe_Load);
            this.EnabledChanged += new System.EventHandler(this.KurumListe_EnabledChanged);
            this.SizeChanged += new System.EventHandler(this.KurumListe_SizeChanged);
            this.cmsKurumlar.ResumeLayout(false);
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstKurumlar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip cmsKurumlar;
        private System.Windows.Forms.ToolStripMenuItem cmsKurumlar_Goruntule;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmsKurumlar_Ekle;
        private System.Windows.Forms.ToolStripMenuItem cmsKurumlar_Duzenle;
        private System.Windows.Forms.ToolStripMenuItem cmsKurumlar_Sil;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsKurumlar_TumunuGoruntule;
        private Components.Yukleniyor yukleniyor1;
        private System.ComponentModel.BackgroundWorker bwKurumYukle;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel lblDurum;
    }
}
