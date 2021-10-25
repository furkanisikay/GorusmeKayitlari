namespace GorusmeKayitlari.App.Bilesenler
{
    partial class Liste
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Liste));
            this.tvKategoriler = new System.Windows.Forms.TreeView();
            this.cmsKategoriler = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsKategoriler_Ekle = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsKategoriler_Duzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsKategoriler_Sil = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsKategoriler_Yenile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnIsaretleriTemizle = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsKat_GostMod = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsKat_GostMod_Tekli = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsKat_GostMod_IsaretliKat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsKat_GostMod_AltKatDahil = new System.Windows.Forms.ToolStripMenuItem();
            this.sadeceİşaretliKategorilerinKurumlarınıGösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yukleniyor1 = new GorusmeKayitlari.Components.Yukleniyor();
            this.bwKategoriYukle = new System.ComponentModel.BackgroundWorker();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.lblDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmsKategoriler.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvKategoriler
            // 
            this.tvKategoriler.ContextMenuStrip = this.cmsKategoriler;
            this.tvKategoriler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvKategoriler.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tvKategoriler.Location = new System.Drawing.Point(0, 0);
            this.tvKategoriler.Name = "tvKategoriler";
            this.tvKategoriler.Size = new System.Drawing.Size(358, 362);
            this.tvKategoriler.TabIndex = 1;
            this.tvKategoriler.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TvKategoriler_AfterCheck);
            this.tvKategoriler.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvKategoriler_AfterSelect);
            this.tvKategoriler.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvKategoriler_NodeMouseDoubleClick);
            // 
            // cmsKategoriler
            // 
            this.cmsKategoriler.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsKategoriler_Ekle,
            this.cmsKategoriler_Duzenle,
            this.cmsKategoriler_Sil,
            this.toolStripSeparator1,
            this.cmsKategoriler_Yenile,
            this.toolStripSeparator2,
            this.btnIsaretleriTemizle,
            this.cmsKat_GostMod});
            this.cmsKategoriler.Name = "cmsKategoriler";
            this.cmsKategoriler.ShowCheckMargin = true;
            this.cmsKategoriler.Size = new System.Drawing.Size(227, 148);
            this.cmsKategoriler.Opening += new System.ComponentModel.CancelEventHandler(this.CmsKategoriler_Opening);
            // 
            // cmsKategoriler_Ekle
            // 
            this.cmsKategoriler_Ekle.Image = ((System.Drawing.Image)(resources.GetObject("cmsKategoriler_Ekle.Image")));
            this.cmsKategoriler_Ekle.Name = "cmsKategoriler_Ekle";
            this.cmsKategoriler_Ekle.Size = new System.Drawing.Size(226, 22);
            this.cmsKategoriler_Ekle.Text = "Ekle";
            this.cmsKategoriler_Ekle.Click += new System.EventHandler(this.CmsKategoriler_Ekle_Click);
            // 
            // cmsKategoriler_Duzenle
            // 
            this.cmsKategoriler_Duzenle.Image = ((System.Drawing.Image)(resources.GetObject("cmsKategoriler_Duzenle.Image")));
            this.cmsKategoriler_Duzenle.Name = "cmsKategoriler_Duzenle";
            this.cmsKategoriler_Duzenle.Size = new System.Drawing.Size(226, 22);
            this.cmsKategoriler_Duzenle.Text = "Düzenle";
            this.cmsKategoriler_Duzenle.Click += new System.EventHandler(this.CmsKategoriler_Duzenle_Click);
            // 
            // cmsKategoriler_Sil
            // 
            this.cmsKategoriler_Sil.Image = ((System.Drawing.Image)(resources.GetObject("cmsKategoriler_Sil.Image")));
            this.cmsKategoriler_Sil.Name = "cmsKategoriler_Sil";
            this.cmsKategoriler_Sil.Size = new System.Drawing.Size(226, 22);
            this.cmsKategoriler_Sil.Text = "Sil";
            this.cmsKategoriler_Sil.Click += new System.EventHandler(this.CmsKategoriler_Sil_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // cmsKategoriler_Yenile
            // 
            this.cmsKategoriler_Yenile.Image = ((System.Drawing.Image)(resources.GetObject("cmsKategoriler_Yenile.Image")));
            this.cmsKategoriler_Yenile.Name = "cmsKategoriler_Yenile";
            this.cmsKategoriler_Yenile.Size = new System.Drawing.Size(226, 22);
            this.cmsKategoriler_Yenile.Text = "Yenile";
            this.cmsKategoriler_Yenile.Click += new System.EventHandler(this.CmsKategoriler_Yenile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(223, 6);
            // 
            // btnIsaretleriTemizle
            // 
            this.btnIsaretleriTemizle.Image = ((System.Drawing.Image)(resources.GetObject("btnIsaretleriTemizle.Image")));
            this.btnIsaretleriTemizle.Name = "btnIsaretleriTemizle";
            this.btnIsaretleriTemizle.Size = new System.Drawing.Size(226, 22);
            this.btnIsaretleriTemizle.Text = "İşaretleri Temizle";
            this.btnIsaretleriTemizle.Visible = false;
            this.btnIsaretleriTemizle.Click += new System.EventHandler(this.BtnIsaretleriTemizle_Click);
            // 
            // cmsKat_GostMod
            // 
            this.cmsKat_GostMod.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsKat_GostMod_Tekli,
            this.cmsKat_GostMod_IsaretliKat,
            this.toolStripSeparator3,
            this.cmsKat_GostMod_AltKatDahil});
            this.cmsKat_GostMod.Image = ((System.Drawing.Image)(resources.GetObject("cmsKat_GostMod.Image")));
            this.cmsKat_GostMod.Name = "cmsKat_GostMod";
            this.cmsKat_GostMod.Size = new System.Drawing.Size(226, 22);
            this.cmsKat_GostMod.Text = "Kategori Gösterim Modu";
            // 
            // cmsKat_GostMod_Tekli
            // 
            this.cmsKat_GostMod_Tekli.Checked = true;
            this.cmsKat_GostMod_Tekli.CheckOnClick = true;
            this.cmsKat_GostMod_Tekli.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cmsKat_GostMod_Tekli.Name = "cmsKat_GostMod_Tekli";
            this.cmsKat_GostMod_Tekli.Size = new System.Drawing.Size(195, 22);
            this.cmsKat_GostMod_Tekli.Text = "Tekli";
            this.cmsKat_GostMod_Tekli.CheckedChanged += new System.EventHandler(this.CmsKat_GostModes_CheckedChanged);
            // 
            // cmsKat_GostMod_IsaretliKat
            // 
            this.cmsKat_GostMod_IsaretliKat.CheckOnClick = true;
            this.cmsKat_GostMod_IsaretliKat.Name = "cmsKat_GostMod_IsaretliKat";
            this.cmsKat_GostMod_IsaretliKat.Size = new System.Drawing.Size(195, 22);
            this.cmsKat_GostMod_IsaretliKat.Text = "İşaretli Kategoriler";
            this.cmsKat_GostMod_IsaretliKat.CheckedChanged += new System.EventHandler(this.CmsKat_GostModes_CheckedChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(192, 6);
            // 
            // cmsKat_GostMod_AltKatDahil
            // 
            this.cmsKat_GostMod_AltKatDahil.Checked = true;
            this.cmsKat_GostMod_AltKatDahil.CheckOnClick = true;
            this.cmsKat_GostMod_AltKatDahil.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cmsKat_GostMod_AltKatDahil.Name = "cmsKat_GostMod_AltKatDahil";
            this.cmsKat_GostMod_AltKatDahil.Size = new System.Drawing.Size(195, 22);
            this.cmsKat_GostMod_AltKatDahil.Text = "Alt Kategorileri Dahil Et";
            this.cmsKat_GostMod_AltKatDahil.ToolTipText = "Kurumlar yüklenirken bu seçenek işaretliyse yüklenecek kurumlara \r\nseçili/işaretl" +
    "i kategorilerin alt kategorilerinde bulunan kurumlarda dahil edilir.";
            this.cmsKat_GostMod_AltKatDahil.CheckedChanged += new System.EventHandler(this.CmsKat_GostMod_AltKatDahil_CheckedChanged);
            // 
            // sadeceİşaretliKategorilerinKurumlarınıGösterToolStripMenuItem
            // 
            this.sadeceİşaretliKategorilerinKurumlarınıGösterToolStripMenuItem.Name = "sadeceİşaretliKategorilerinKurumlarınıGösterToolStripMenuItem";
            this.sadeceİşaretliKategorilerinKurumlarınıGösterToolStripMenuItem.Size = new System.Drawing.Size(320, 22);
            this.sadeceİşaretliKategorilerinKurumlarınıGösterToolStripMenuItem.Text = "Sadece İşaretli Kategorilerin Kurumlarını Göster";
            // 
            // yukleniyor1
            // 
            this.yukleniyor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yukleniyor1.BackColor = System.Drawing.Color.White;
            this.yukleniyor1.Location = new System.Drawing.Point(25, 110);
            this.yukleniyor1.Name = "yukleniyor1";
            this.yukleniyor1.Size = new System.Drawing.Size(309, 165);
            this.yukleniyor1.TabIndex = 2;
            this.yukleniyor1.Visible = false;
            this.yukleniyor1.Yazi = "Yükleniyor...";
            this.yukleniyor1.YaziFontu = new System.Drawing.Font("Segoe UI", 11F);
            this.yukleniyor1.YaziGoster = true;
            // 
            // bwKategoriYukle
            // 
            this.bwKategoriYukle.WorkerSupportsCancellation = true;
            this.bwKategoriYukle.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwKategoriYukle_DoWork);
            this.bwKategoriYukle.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwKategoriYukle_RunWorkerCompleted);
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDurum});
            this.ssMain.Location = new System.Drawing.Point(0, 362);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(358, 22);
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
            // Liste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.cmsKategoriler;
            this.Controls.Add(this.yukleniyor1);
            this.Controls.Add(this.tvKategoriler);
            this.Controls.Add(this.ssMain);
            this.Name = "Liste";
            this.Size = new System.Drawing.Size(358, 384);
            this.Load += new System.EventHandler(this.Liste_Load);
            this.cmsKategoriler.ResumeLayout(false);
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvKategoriler;
        private System.Windows.Forms.ContextMenuStrip cmsKategoriler;
        private System.Windows.Forms.ToolStripMenuItem cmsKategoriler_Yenile;
        private System.Windows.Forms.ToolStripMenuItem cmsKategoriler_Ekle;
        private System.Windows.Forms.ToolStripMenuItem cmsKategoriler_Duzenle;
        private System.Windows.Forms.ToolStripMenuItem cmsKategoriler_Sil;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Components.Yukleniyor yukleniyor1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnIsaretleriTemizle;
        private System.Windows.Forms.ToolStripMenuItem sadeceİşaretliKategorilerinKurumlarınıGösterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsKat_GostMod;
        private System.Windows.Forms.ToolStripMenuItem cmsKat_GostMod_Tekli;
        private System.Windows.Forms.ToolStripMenuItem cmsKat_GostMod_IsaretliKat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cmsKat_GostMod_AltKatDahil;
        private System.ComponentModel.BackgroundWorker bwKategoriYukle;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel lblDurum;
    }
}
