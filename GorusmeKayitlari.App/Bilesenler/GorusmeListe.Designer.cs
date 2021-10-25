namespace GorusmeKayitlari.App.Bilesenler
{
    partial class GorusmeListe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GorusmeListe));
            this.gboxFiltrele = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tarihFiltreleme1 = new GorusmeKayitlari.App.Bilesenler.TarihFiltreleme();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmbKullanicilar = new GorusmeKayitlari.Components.CheckedComboBox();
            this.cmsKullanicilarFiltrele = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsKullanicilarFiltrele_Yenile = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKullaniciFiltrele = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnHtmleAktar = new System.Windows.Forms.Button();
            this.btnPdfeAktar = new System.Windows.Forms.Button();
            this.btnExceleAktar = new System.Windows.Forms.Button();
            this.gboxGorusmeler = new System.Windows.Forms.GroupBox();
            this.yukleniyor1 = new GorusmeKayitlari.Components.Yukleniyor();
            this.lstGorusmeler = new System.Windows.Forms.ListView();
            this.clmMetin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTarih = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmKullanici = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmYetkili = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmKurum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsGorusmeler = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsGorusmeler_Ekle = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsGorusmeler_Duzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsGorusmeler_Sil = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsGorusmeler_Gizle = new System.Windows.Forms.ToolStripMenuItem();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.lblDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.gboxFiltrele.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.cmsKullanicilarFiltrele.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.gboxGorusmeler.SuspendLayout();
            this.cmsGorusmeler.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxFiltrele
            // 
            this.gboxFiltrele.Controls.Add(this.tabControl1);
            this.gboxFiltrele.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxFiltrele.Location = new System.Drawing.Point(0, 0);
            this.gboxFiltrele.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gboxFiltrele.Name = "gboxFiltrele";
            this.gboxFiltrele.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gboxFiltrele.Size = new System.Drawing.Size(953, 105);
            this.gboxFiltrele.TabIndex = 0;
            this.gboxFiltrele.TabStop = false;
            this.gboxFiltrele.Text = "Filtrele";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 21);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(947, 80);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tarihFiltreleme1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(939, 50);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tarihe Göre Filtrele";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tarihFiltreleme1
            // 
            this.tarihFiltreleme1.FiltrelemeAktif = true;
            this.tarihFiltreleme1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tarihFiltreleme1.Location = new System.Drawing.Point(175, 12);
            this.tarihFiltreleme1.Name = "tarihFiltreleme1";
            this.tarihFiltreleme1.SelectedIndex = 0;
            this.tarihFiltreleme1.Size = new System.Drawing.Size(755, 27);
            this.tarihFiltreleme1.TabIndex = 1;
            this.tarihFiltreleme1.FiltreleTiklandiginda += new System.EventHandler<GorusmeKayitlari.Core.Components.TarihFiltreleEventArgs>(this.BtnFiltrele_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Görüntülenecek Tarihler";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cmbKullanicilar);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnKullaniciFiltrele);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(939, 54);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kullaniciya Göre Filtrele";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmbKullanicilar
            // 
            this.cmbKullanicilar.CheckOnClick = true;
            this.cmbKullanicilar.ContextMenuStrip = this.cmsKullanicilarFiltrele;
            this.cmbKullanicilar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbKullanicilar.DropDownHeight = 1;
            this.cmbKullanicilar.FormattingEnabled = true;
            this.cmbKullanicilar.HicbirItemSecilmediYazisi = "(kullanıcı seçilmedi)";
            this.cmbKullanicilar.IntegralHeight = false;
            this.cmbKullanicilar.Location = new System.Drawing.Point(191, 13);
            this.cmbKullanicilar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbKullanicilar.Name = "cmbKullanicilar";
            this.cmbKullanicilar.Size = new System.Drawing.Size(649, 25);
            this.cmbKullanicilar.TabIndex = 5;
            this.cmbKullanicilar.ValueSeparator = ", ";
            // 
            // cmsKullanicilarFiltrele
            // 
            this.cmsKullanicilarFiltrele.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmsKullanicilarFiltrele.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsKullanicilarFiltrele_Yenile});
            this.cmsKullanicilarFiltrele.Name = "cmsKullanicilarFiltrele";
            this.cmsKullanicilarFiltrele.Size = new System.Drawing.Size(114, 28);
            // 
            // cmsKullanicilarFiltrele_Yenile
            // 
            this.cmsKullanicilarFiltrele_Yenile.Image = ((System.Drawing.Image)(resources.GetObject("cmsKullanicilarFiltrele_Yenile.Image")));
            this.cmsKullanicilarFiltrele_Yenile.Name = "cmsKullanicilarFiltrele_Yenile";
            this.cmsKullanicilarFiltrele_Yenile.Size = new System.Drawing.Size(113, 24);
            this.cmsKullanicilarFiltrele_Yenile.Text = "Yenile";
            this.cmsKullanicilarFiltrele_Yenile.ToolTipText = "Kullanıcıları tekrar yükler.";
            this.cmsKullanicilarFiltrele_Yenile.Click += new System.EventHandler(this.CmsKullanicilarFiltrele_Yenile_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "Görüntülenecek Kullanıcılar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnKullaniciFiltrele
            // 
            this.btnKullaniciFiltrele.Location = new System.Drawing.Point(846, 12);
            this.btnKullaniciFiltrele.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKullaniciFiltrele.Name = "btnKullaniciFiltrele";
            this.btnKullaniciFiltrele.Size = new System.Drawing.Size(87, 27);
            this.btnKullaniciFiltrele.TabIndex = 1;
            this.btnKullaniciFiltrele.Text = "Filtrele";
            this.btnKullaniciFiltrele.UseVisualStyleBackColor = true;
            this.btnKullaniciFiltrele.Click += new System.EventHandler(this.BtnKullaniciFiltrele_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnHtmleAktar);
            this.tabPage3.Controls.Add(this.btnPdfeAktar);
            this.tabPage3.Controls.Add(this.btnExceleAktar);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(939, 54);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Dışarı Aktar";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnHtmleAktar
            // 
            this.btnHtmleAktar.Location = new System.Drawing.Point(260, 9);
            this.btnHtmleAktar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHtmleAktar.Name = "btnHtmleAktar";
            this.btnHtmleAktar.Size = new System.Drawing.Size(121, 32);
            this.btnHtmleAktar.TabIndex = 2;
            this.btnHtmleAktar.Text = "HTML\'e Aktar";
            this.btnHtmleAktar.UseVisualStyleBackColor = true;
            this.btnHtmleAktar.Click += new System.EventHandler(this.BtnHtmleAktar_Click);
            // 
            // btnPdfeAktar
            // 
            this.btnPdfeAktar.Location = new System.Drawing.Point(132, 9);
            this.btnPdfeAktar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPdfeAktar.Name = "btnPdfeAktar";
            this.btnPdfeAktar.Size = new System.Drawing.Size(121, 32);
            this.btnPdfeAktar.TabIndex = 1;
            this.btnPdfeAktar.Text = "PDF\'e Aktar";
            this.btnPdfeAktar.UseVisualStyleBackColor = true;
            this.btnPdfeAktar.Click += new System.EventHandler(this.BtnPdfeAktar_Click);
            // 
            // btnExceleAktar
            // 
            this.btnExceleAktar.Location = new System.Drawing.Point(3, 9);
            this.btnExceleAktar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExceleAktar.Name = "btnExceleAktar";
            this.btnExceleAktar.Size = new System.Drawing.Size(121, 32);
            this.btnExceleAktar.TabIndex = 0;
            this.btnExceleAktar.Text = "EXCEL\'e Aktar";
            this.btnExceleAktar.UseVisualStyleBackColor = true;
            this.btnExceleAktar.Click += new System.EventHandler(this.BtnExceleAktar_Click);
            // 
            // gboxGorusmeler
            // 
            this.gboxGorusmeler.Controls.Add(this.yukleniyor1);
            this.gboxGorusmeler.Controls.Add(this.lstGorusmeler);
            this.gboxGorusmeler.Controls.Add(this.ssMain);
            this.gboxGorusmeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxGorusmeler.Location = new System.Drawing.Point(0, 105);
            this.gboxGorusmeler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gboxGorusmeler.Name = "gboxGorusmeler";
            this.gboxGorusmeler.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gboxGorusmeler.Size = new System.Drawing.Size(953, 355);
            this.gboxGorusmeler.TabIndex = 1;
            this.gboxGorusmeler.TabStop = false;
            // 
            // yukleniyor1
            // 
            this.yukleniyor1.BackColor = System.Drawing.Color.White;
            this.yukleniyor1.Location = new System.Drawing.Point(353, 86);
            this.yukleniyor1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.yukleniyor1.Name = "yukleniyor1";
            this.yukleniyor1.Size = new System.Drawing.Size(247, 201);
            this.yukleniyor1.TabIndex = 3;
            this.yukleniyor1.Visible = false;
            this.yukleniyor1.Yazi = "Yükleniyor...";
            this.yukleniyor1.YaziFontu = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yukleniyor1.YaziGoster = false;
            // 
            // lstGorusmeler
            // 
            this.lstGorusmeler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmMetin,
            this.clmTarih,
            this.clmKullanici,
            this.clmYetkili,
            this.clmKurum});
            this.lstGorusmeler.ContextMenuStrip = this.cmsGorusmeler;
            this.lstGorusmeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGorusmeler.FullRowSelect = true;
            this.lstGorusmeler.Location = new System.Drawing.Point(3, 21);
            this.lstGorusmeler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstGorusmeler.Name = "lstGorusmeler";
            this.lstGorusmeler.ShowItemToolTips = true;
            this.lstGorusmeler.Size = new System.Drawing.Size(947, 308);
            this.lstGorusmeler.TabIndex = 2;
            this.lstGorusmeler.UseCompatibleStateImageBehavior = false;
            this.lstGorusmeler.View = System.Windows.Forms.View.Details;
            this.lstGorusmeler.SizeChanged += new System.EventHandler(this.LstGorusmeler_SizeChanged);
            this.lstGorusmeler.DoubleClick += new System.EventHandler(this.LstGorusmeler_DoubleClick);
            this.lstGorusmeler.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LstGorusmeler_KeyUp);
            // 
            // clmMetin
            // 
            this.clmMetin.Text = "Görüşme Metni";
            this.clmMetin.Width = 468;
            // 
            // clmTarih
            // 
            this.clmTarih.Text = "Tarih";
            this.clmTarih.Width = 75;
            // 
            // clmKullanici
            // 
            this.clmKullanici.Text = "Görüşen Yetkili";
            this.clmKullanici.Width = 115;
            // 
            // clmYetkili
            // 
            this.clmYetkili.Text = "Görüşülen Yetkili";
            this.clmYetkili.Width = 133;
            // 
            // clmKurum
            // 
            this.clmKurum.Text = "Görüşülen Kurum";
            this.clmKurum.Width = 148;
            // 
            // cmsGorusmeler
            // 
            this.cmsGorusmeler.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmsGorusmeler.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsGorusmeler.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsGorusmeler_Ekle,
            this.cmsGorusmeler_Duzenle,
            this.cmsGorusmeler_Sil,
            this.cmsGorusmeler_Gizle});
            this.cmsGorusmeler.Name = "cmsGorusmeler";
            this.cmsGorusmeler.Size = new System.Drawing.Size(132, 108);
            this.cmsGorusmeler.Opening += new System.ComponentModel.CancelEventHandler(this.CmsGorusmeler_Opening);
            // 
            // cmsGorusmeler_Ekle
            // 
            this.cmsGorusmeler_Ekle.Image = ((System.Drawing.Image)(resources.GetObject("cmsGorusmeler_Ekle.Image")));
            this.cmsGorusmeler_Ekle.Name = "cmsGorusmeler_Ekle";
            this.cmsGorusmeler_Ekle.Size = new System.Drawing.Size(131, 26);
            this.cmsGorusmeler_Ekle.Text = "Ekle";
            this.cmsGorusmeler_Ekle.Click += new System.EventHandler(this.CmsGorusmeler_Ekle_Click);
            // 
            // cmsGorusmeler_Duzenle
            // 
            this.cmsGorusmeler_Duzenle.Image = ((System.Drawing.Image)(resources.GetObject("cmsGorusmeler_Duzenle.Image")));
            this.cmsGorusmeler_Duzenle.Name = "cmsGorusmeler_Duzenle";
            this.cmsGorusmeler_Duzenle.Size = new System.Drawing.Size(131, 26);
            this.cmsGorusmeler_Duzenle.Text = "Düzenle";
            this.cmsGorusmeler_Duzenle.Click += new System.EventHandler(this.CmsGorusmeler_Duzenle_Click);
            // 
            // cmsGorusmeler_Sil
            // 
            this.cmsGorusmeler_Sil.Image = ((System.Drawing.Image)(resources.GetObject("cmsGorusmeler_Sil.Image")));
            this.cmsGorusmeler_Sil.Name = "cmsGorusmeler_Sil";
            this.cmsGorusmeler_Sil.Size = new System.Drawing.Size(131, 26);
            this.cmsGorusmeler_Sil.Text = "Sil";
            this.cmsGorusmeler_Sil.Click += new System.EventHandler(this.CmsGorusmeler_Sil_Click);
            // 
            // cmsGorusmeler_Gizle
            // 
            this.cmsGorusmeler_Gizle.Image = ((System.Drawing.Image)(resources.GetObject("cmsGorusmeler_Gizle.Image")));
            this.cmsGorusmeler_Gizle.Name = "cmsGorusmeler_Gizle";
            this.cmsGorusmeler_Gizle.Size = new System.Drawing.Size(131, 26);
            this.cmsGorusmeler_Gizle.Text = "Gizle";
            this.cmsGorusmeler_Gizle.Click += new System.EventHandler(this.CmsGorusmeler_Gizle_Click);
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDurum});
            this.ssMain.Location = new System.Drawing.Point(3, 329);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(947, 22);
            this.ssMain.TabIndex = 4;
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
            // GorusmeListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gboxGorusmeler);
            this.Controls.Add(this.gboxFiltrele);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(953, 369);
            this.Name = "GorusmeListe";
            this.Size = new System.Drawing.Size(953, 460);
            this.Load += new System.EventHandler(this.GorusmeListe_Load);
            this.gboxFiltrele.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.cmsKullanicilarFiltrele.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.gboxGorusmeler.ResumeLayout(false);
            this.gboxGorusmeler.PerformLayout();
            this.cmsGorusmeler.ResumeLayout(false);
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxFiltrele;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gboxGorusmeler;
        private System.Windows.Forms.ContextMenuStrip cmsGorusmeler;
        private System.Windows.Forms.ToolStripMenuItem cmsGorusmeler_Ekle;
        private System.Windows.Forms.ToolStripMenuItem cmsGorusmeler_Duzenle;
        private System.Windows.Forms.ToolStripMenuItem cmsGorusmeler_Sil;
        private System.Windows.Forms.ToolStripMenuItem cmsGorusmeler_Gizle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKullaniciFiltrele;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem cmsKullanicilarFiltrele_Yenile;
        private System.Windows.Forms.ContextMenuStrip cmsKullanicilarFiltrele;
        private System.Windows.Forms.ListView lstGorusmeler;
        private System.Windows.Forms.ColumnHeader clmTarih;
        private System.Windows.Forms.ColumnHeader clmMetin;
        private System.Windows.Forms.ColumnHeader clmKullanici;
        private System.Windows.Forms.ColumnHeader clmYetkili;
        private System.Windows.Forms.ColumnHeader clmKurum;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnExceleAktar;
        private System.Windows.Forms.Button btnHtmleAktar;
        private System.Windows.Forms.Button btnPdfeAktar;
        private GorusmeKayitlari.Components.CheckedComboBox cmbKullanicilar;
        private GorusmeKayitlari.Components.Yukleniyor yukleniyor1;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel lblDurum;
        private TarihFiltreleme tarihFiltreleme1;
    }
}
