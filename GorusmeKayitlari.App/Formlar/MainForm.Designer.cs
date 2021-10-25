namespace GorusmeKayitlari.App.Formlar
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnAraclar = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnKategori = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKategori_Ekle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKategori_Duzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKategori_Sil = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKurum = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKurum_Ekle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKurum_Duzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKurum_Sil = new System.Windows.Forms.ToolStripMenuItem();
            this.btnYetkili = new System.Windows.Forms.ToolStripMenuItem();
            this.btnYetkili_Ekle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnYetkili_Duzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnYetkili_Sil = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKullanici = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKullanici_Ekle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKullanici_Duzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKullanici_Sil = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKullaniciHesabi = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKullaniciHesabi_Ekle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKullaniciHesabi_Duzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKullaniciHesabi_Sil = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVeritabani = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVeritabaniDisaAktar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVeritabaniOtoYedekle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAraclar_Cizgi = new System.Windows.Forms.ToolStripSeparator();
            this.btnAyarlar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEklenti = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnHatirlatici = new System.Windows.Forms.ToolStripMenuItem();
            this.btnYardim = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnLisans = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGuncDenetle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKulHesapAyar = new System.Windows.Forms.ToolStripButton();
            this.lblKullaniciHesap = new System.Windows.Forms.ToolStripLabel();
            this.btnHakkinda = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tsMain
            // 
            this.tsMain.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAraclar,
            this.btnEklenti,
            this.btnYardim,
            this.btnKulHesapAyar,
            this.lblKullaniciHesap,
            this.btnHakkinda});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(716, 25);
            this.tsMain.TabIndex = 2;
            // 
            // btnAraclar
            // 
            this.btnAraclar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnKategori,
            this.btnKurum,
            this.btnYetkili,
            this.btnKullanici,
            this.btnKullaniciHesabi,
            this.btnVeritabani,
            this.btnAraclar_Cizgi,
            this.btnAyarlar});
            this.btnAraclar.Image = ((System.Drawing.Image)(resources.GetObject("btnAraclar.Image")));
            this.btnAraclar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAraclar.Name = "btnAraclar";
            this.btnAraclar.Size = new System.Drawing.Size(76, 22);
            this.btnAraclar.Text = "Araçlar";
            // 
            // btnKategori
            // 
            this.btnKategori.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnKategori_Ekle,
            this.btnKategori_Duzenle,
            this.btnKategori_Sil});
            this.btnKategori.Image = ((System.Drawing.Image)(resources.GetObject("btnKategori.Image")));
            this.btnKategori.Name = "btnKategori";
            this.btnKategori.Size = new System.Drawing.Size(164, 22);
            this.btnKategori.Text = "Kategori";
            // 
            // btnKategori_Ekle
            // 
            this.btnKategori_Ekle.Image = ((System.Drawing.Image)(resources.GetObject("btnKategori_Ekle.Image")));
            this.btnKategori_Ekle.Name = "btnKategori_Ekle";
            this.btnKategori_Ekle.Size = new System.Drawing.Size(122, 22);
            this.btnKategori_Ekle.Text = "Ekle";
            this.btnKategori_Ekle.Click += new System.EventHandler(this.BtnKategori_Ekle_Click);
            // 
            // btnKategori_Duzenle
            // 
            this.btnKategori_Duzenle.Image = ((System.Drawing.Image)(resources.GetObject("btnKategori_Duzenle.Image")));
            this.btnKategori_Duzenle.Name = "btnKategori_Duzenle";
            this.btnKategori_Duzenle.Size = new System.Drawing.Size(122, 22);
            this.btnKategori_Duzenle.Text = "Düzenle";
            this.btnKategori_Duzenle.Click += new System.EventHandler(this.BtnKategori_Duzenle_Click);
            // 
            // btnKategori_Sil
            // 
            this.btnKategori_Sil.Image = ((System.Drawing.Image)(resources.GetObject("btnKategori_Sil.Image")));
            this.btnKategori_Sil.Name = "btnKategori_Sil";
            this.btnKategori_Sil.Size = new System.Drawing.Size(122, 22);
            this.btnKategori_Sil.Text = "Sil";
            this.btnKategori_Sil.Click += new System.EventHandler(this.BtnKategori_Sil_Click);
            // 
            // btnKurum
            // 
            this.btnKurum.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnKurum_Ekle,
            this.btnKurum_Duzenle,
            this.btnKurum_Sil});
            this.btnKurum.Image = ((System.Drawing.Image)(resources.GetObject("btnKurum.Image")));
            this.btnKurum.Name = "btnKurum";
            this.btnKurum.Size = new System.Drawing.Size(164, 22);
            this.btnKurum.Text = "Kurum";
            // 
            // btnKurum_Ekle
            // 
            this.btnKurum_Ekle.Image = ((System.Drawing.Image)(resources.GetObject("btnKurum_Ekle.Image")));
            this.btnKurum_Ekle.Name = "btnKurum_Ekle";
            this.btnKurum_Ekle.Size = new System.Drawing.Size(122, 22);
            this.btnKurum_Ekle.Text = "Ekle";
            this.btnKurum_Ekle.Click += new System.EventHandler(this.BtnKurum_Ekle_Click);
            // 
            // btnKurum_Duzenle
            // 
            this.btnKurum_Duzenle.Image = ((System.Drawing.Image)(resources.GetObject("btnKurum_Duzenle.Image")));
            this.btnKurum_Duzenle.Name = "btnKurum_Duzenle";
            this.btnKurum_Duzenle.Size = new System.Drawing.Size(122, 22);
            this.btnKurum_Duzenle.Text = "Düzenle";
            this.btnKurum_Duzenle.Click += new System.EventHandler(this.BtnKurum_Duzenle_Click);
            // 
            // btnKurum_Sil
            // 
            this.btnKurum_Sil.Image = ((System.Drawing.Image)(resources.GetObject("btnKurum_Sil.Image")));
            this.btnKurum_Sil.Name = "btnKurum_Sil";
            this.btnKurum_Sil.Size = new System.Drawing.Size(122, 22);
            this.btnKurum_Sil.Text = "Sil";
            this.btnKurum_Sil.Click += new System.EventHandler(this.BtnKurum_Sil_Click);
            // 
            // btnYetkili
            // 
            this.btnYetkili.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnYetkili_Ekle,
            this.btnYetkili_Duzenle,
            this.btnYetkili_Sil});
            this.btnYetkili.Image = ((System.Drawing.Image)(resources.GetObject("btnYetkili.Image")));
            this.btnYetkili.Name = "btnYetkili";
            this.btnYetkili.Size = new System.Drawing.Size(164, 22);
            this.btnYetkili.Text = "Yetkili";
            // 
            // btnYetkili_Ekle
            // 
            this.btnYetkili_Ekle.Image = ((System.Drawing.Image)(resources.GetObject("btnYetkili_Ekle.Image")));
            this.btnYetkili_Ekle.Name = "btnYetkili_Ekle";
            this.btnYetkili_Ekle.Size = new System.Drawing.Size(122, 22);
            this.btnYetkili_Ekle.Text = "Ekle";
            this.btnYetkili_Ekle.Click += new System.EventHandler(this.BtnYetkili_Ekle_Click);
            // 
            // btnYetkili_Duzenle
            // 
            this.btnYetkili_Duzenle.Image = ((System.Drawing.Image)(resources.GetObject("btnYetkili_Duzenle.Image")));
            this.btnYetkili_Duzenle.Name = "btnYetkili_Duzenle";
            this.btnYetkili_Duzenle.Size = new System.Drawing.Size(122, 22);
            this.btnYetkili_Duzenle.Text = "Düzenle";
            this.btnYetkili_Duzenle.Click += new System.EventHandler(this.BtnYetkili_Duzenle_Click);
            // 
            // btnYetkili_Sil
            // 
            this.btnYetkili_Sil.Image = ((System.Drawing.Image)(resources.GetObject("btnYetkili_Sil.Image")));
            this.btnYetkili_Sil.Name = "btnYetkili_Sil";
            this.btnYetkili_Sil.Size = new System.Drawing.Size(122, 22);
            this.btnYetkili_Sil.Text = "Sil";
            this.btnYetkili_Sil.Click += new System.EventHandler(this.BtnYetkili_Sil_Click);
            // 
            // btnKullanici
            // 
            this.btnKullanici.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnKullanici_Ekle,
            this.btnKullanici_Duzenle,
            this.btnKullanici_Sil});
            this.btnKullanici.Image = ((System.Drawing.Image)(resources.GetObject("btnKullanici.Image")));
            this.btnKullanici.Name = "btnKullanici";
            this.btnKullanici.Size = new System.Drawing.Size(164, 22);
            this.btnKullanici.Text = "Kullanıcı";
            // 
            // btnKullanici_Ekle
            // 
            this.btnKullanici_Ekle.Image = ((System.Drawing.Image)(resources.GetObject("btnKullanici_Ekle.Image")));
            this.btnKullanici_Ekle.Name = "btnKullanici_Ekle";
            this.btnKullanici_Ekle.Size = new System.Drawing.Size(122, 22);
            this.btnKullanici_Ekle.Text = "Ekle";
            this.btnKullanici_Ekle.Click += new System.EventHandler(this.BtnKullanici_Ekle_Click);
            // 
            // btnKullanici_Duzenle
            // 
            this.btnKullanici_Duzenle.Image = ((System.Drawing.Image)(resources.GetObject("btnKullanici_Duzenle.Image")));
            this.btnKullanici_Duzenle.Name = "btnKullanici_Duzenle";
            this.btnKullanici_Duzenle.Size = new System.Drawing.Size(122, 22);
            this.btnKullanici_Duzenle.Text = "Düzenle";
            this.btnKullanici_Duzenle.Click += new System.EventHandler(this.BtnKullanici_Duzenle_Click);
            // 
            // btnKullanici_Sil
            // 
            this.btnKullanici_Sil.Image = ((System.Drawing.Image)(resources.GetObject("btnKullanici_Sil.Image")));
            this.btnKullanici_Sil.Name = "btnKullanici_Sil";
            this.btnKullanici_Sil.Size = new System.Drawing.Size(122, 22);
            this.btnKullanici_Sil.Text = "Sil";
            this.btnKullanici_Sil.Click += new System.EventHandler(this.BtnKullanici_Sil_Click);
            // 
            // btnKullaniciHesabi
            // 
            this.btnKullaniciHesabi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnKullaniciHesabi_Ekle,
            this.btnKullaniciHesabi_Duzenle,
            this.btnKullaniciHesabi_Sil});
            this.btnKullaniciHesabi.Image = ((System.Drawing.Image)(resources.GetObject("btnKullaniciHesabi.Image")));
            this.btnKullaniciHesabi.Name = "btnKullaniciHesabi";
            this.btnKullaniciHesabi.Size = new System.Drawing.Size(164, 22);
            this.btnKullaniciHesabi.Text = "Kullanıcı Hesabı";
            // 
            // btnKullaniciHesabi_Ekle
            // 
            this.btnKullaniciHesabi_Ekle.Image = ((System.Drawing.Image)(resources.GetObject("btnKullaniciHesabi_Ekle.Image")));
            this.btnKullaniciHesabi_Ekle.Name = "btnKullaniciHesabi_Ekle";
            this.btnKullaniciHesabi_Ekle.Size = new System.Drawing.Size(122, 22);
            this.btnKullaniciHesabi_Ekle.Text = "Ekle";
            this.btnKullaniciHesabi_Ekle.Click += new System.EventHandler(this.BtnKullaniciHesabi_Ekle_Click);
            // 
            // btnKullaniciHesabi_Duzenle
            // 
            this.btnKullaniciHesabi_Duzenle.Image = ((System.Drawing.Image)(resources.GetObject("btnKullaniciHesabi_Duzenle.Image")));
            this.btnKullaniciHesabi_Duzenle.Name = "btnKullaniciHesabi_Duzenle";
            this.btnKullaniciHesabi_Duzenle.Size = new System.Drawing.Size(122, 22);
            this.btnKullaniciHesabi_Duzenle.Text = "Düzenle";
            this.btnKullaniciHesabi_Duzenle.Click += new System.EventHandler(this.BtnKullaniciHesabi_Duzenle_Click);
            // 
            // btnKullaniciHesabi_Sil
            // 
            this.btnKullaniciHesabi_Sil.Image = ((System.Drawing.Image)(resources.GetObject("btnKullaniciHesabi_Sil.Image")));
            this.btnKullaniciHesabi_Sil.Name = "btnKullaniciHesabi_Sil";
            this.btnKullaniciHesabi_Sil.Size = new System.Drawing.Size(122, 22);
            this.btnKullaniciHesabi_Sil.Text = "Sil";
            this.btnKullaniciHesabi_Sil.Click += new System.EventHandler(this.BtnKullaniciHesabi_Sil_Click);
            // 
            // btnVeritabani
            // 
            this.btnVeritabani.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVeritabaniDisaAktar,
            this.btnVeritabaniOtoYedekle});
            this.btnVeritabani.Image = ((System.Drawing.Image)(resources.GetObject("btnVeritabani.Image")));
            this.btnVeritabani.Name = "btnVeritabani";
            this.btnVeritabani.Size = new System.Drawing.Size(164, 22);
            this.btnVeritabani.Text = "Veritabanı";
            // 
            // btnVeritabaniDisaAktar
            // 
            this.btnVeritabaniDisaAktar.Image = ((System.Drawing.Image)(resources.GetObject("btnVeritabaniDisaAktar.Image")));
            this.btnVeritabaniDisaAktar.Name = "btnVeritabaniDisaAktar";
            this.btnVeritabaniDisaAktar.Size = new System.Drawing.Size(175, 22);
            this.btnVeritabaniDisaAktar.Text = "Dışa Aktar";
            this.btnVeritabaniDisaAktar.Click += new System.EventHandler(this.BtnVeritabaniDisaAktar_Click);
            // 
            // btnVeritabaniOtoYedekle
            // 
            this.btnVeritabaniOtoYedekle.Image = ((System.Drawing.Image)(resources.GetObject("btnVeritabaniOtoYedekle.Image")));
            this.btnVeritabaniOtoYedekle.Name = "btnVeritabaniOtoYedekle";
            this.btnVeritabaniOtoYedekle.Size = new System.Drawing.Size(175, 22);
            this.btnVeritabaniOtoYedekle.Text = "Otomatik Yedekle";
            this.btnVeritabaniOtoYedekle.Click += new System.EventHandler(this.BtnVeritabaniOtoYedekle_Click);
            // 
            // btnAraclar_Cizgi
            // 
            this.btnAraclar_Cizgi.Name = "btnAraclar_Cizgi";
            this.btnAraclar_Cizgi.Size = new System.Drawing.Size(161, 6);
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.Image = ((System.Drawing.Image)(resources.GetObject("btnAyarlar.Image")));
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(164, 22);
            this.btnAyarlar.Text = "Ayarlar";
            this.btnAyarlar.Click += new System.EventHandler(this.BtnAyarlar_Click);
            // 
            // btnEklenti
            // 
            this.btnEklenti.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHatirlatici});
            this.btnEklenti.Image = ((System.Drawing.Image)(resources.GetObject("btnEklenti.Image")));
            this.btnEklenti.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEklenti.Name = "btnEklenti";
            this.btnEklenti.Size = new System.Drawing.Size(88, 22);
            this.btnEklenti.Text = "Eklentiler";
            // 
            // btnHatirlatici
            // 
            this.btnHatirlatici.Image = ((System.Drawing.Image)(resources.GetObject("btnHatirlatici.Image")));
            this.btnHatirlatici.Name = "btnHatirlatici";
            this.btnHatirlatici.Size = new System.Drawing.Size(129, 22);
            this.btnHatirlatici.Text = "Hatırlatıcı";
            this.btnHatirlatici.Click += new System.EventHandler(this.BtnHatirlatici_Click);
            // 
            // btnYardim
            // 
            this.btnYardim.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLisans,
            this.btnGuncDenetle});
            this.btnYardim.Image = ((System.Drawing.Image)(resources.GetObject("btnYardim.Image")));
            this.btnYardim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnYardim.Name = "btnYardim";
            this.btnYardim.Size = new System.Drawing.Size(75, 22);
            this.btnYardim.Text = "Yardım";
            // 
            // btnLisans
            // 
            this.btnLisans.Image = ((System.Drawing.Image)(resources.GetObject("btnLisans.Image")));
            this.btnLisans.Name = "btnLisans";
            this.btnLisans.Size = new System.Drawing.Size(208, 22);
            this.btnLisans.Text = "Lisans";
            this.btnLisans.Click += new System.EventHandler(this.BtnLisans_Click);
            // 
            // btnGuncDenetle
            // 
            this.btnGuncDenetle.Image = ((System.Drawing.Image)(resources.GetObject("btnGuncDenetle.Image")));
            this.btnGuncDenetle.Name = "btnGuncDenetle";
            this.btnGuncDenetle.Size = new System.Drawing.Size(208, 22);
            this.btnGuncDenetle.Text = "Güncellemeleri Denetle";
            this.btnGuncDenetle.Click += new System.EventHandler(this.BtnGuncDenetle_Click);
            // 
            // btnKulHesapAyar
            // 
            this.btnKulHesapAyar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnKulHesapAyar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnKulHesapAyar.Image = ((System.Drawing.Image)(resources.GetObject("btnKulHesapAyar.Image")));
            this.btnKulHesapAyar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnKulHesapAyar.Name = "btnKulHesapAyar";
            this.btnKulHesapAyar.Size = new System.Drawing.Size(23, 22);
            this.btnKulHesapAyar.ToolTipText = "Kullanıcı Hesabı Ayarları";
            this.btnKulHesapAyar.Visible = false;
            this.btnKulHesapAyar.Click += new System.EventHandler(this.BtnKulHesapAyar_Click);
            // 
            // lblKullaniciHesap
            // 
            this.lblKullaniciHesap.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblKullaniciHesap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblKullaniciHesap.Name = "lblKullaniciHesap";
            this.lblKullaniciHesap.Size = new System.Drawing.Size(103, 22);
            this.lblKullaniciHesap.Text = "Oturum Açılmadı";
            this.lblKullaniciHesap.Click += new System.EventHandler(this.LblKullaniciHesap_Click);
            this.lblKullaniciHesap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblKullaniciHesap_MouseDown);
            this.lblKullaniciHesap.MouseEnter += new System.EventHandler(this.LblKullaniciHesap_MouseEnter);
            this.lblKullaniciHesap.MouseLeave += new System.EventHandler(this.LblKullaniciHesap_MouseLeave);
            // 
            // btnHakkinda
            // 
            this.btnHakkinda.Image = ((System.Drawing.Image)(resources.GetObject("btnHakkinda.Image")));
            this.btnHakkinda.Name = "btnHakkinda";
            this.btnHakkinda.Size = new System.Drawing.Size(88, 25);
            this.btnHakkinda.Text = "Hakkında";
            this.btnHakkinda.Click += new System.EventHandler(this.BtnHakkinda_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 336);
            this.Controls.Add(this.tsMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Görüşme Kayıtları";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripDropDownButton btnAraclar;
        private System.Windows.Forms.ToolStripDropDownButton btnYardim;
        private System.Windows.Forms.ToolStripMenuItem btnKategori;
        private System.Windows.Forms.ToolStripMenuItem btnKategori_Ekle;
        private System.Windows.Forms.ToolStripMenuItem btnKategori_Duzenle;
        private System.Windows.Forms.ToolStripMenuItem btnKategori_Sil;
        private System.Windows.Forms.ToolStripMenuItem btnKurum;
        private System.Windows.Forms.ToolStripMenuItem btnKurum_Ekle;
        private System.Windows.Forms.ToolStripMenuItem btnKurum_Duzenle;
        private System.Windows.Forms.ToolStripMenuItem btnKurum_Sil;
        private System.Windows.Forms.ToolStripSeparator btnAraclar_Cizgi;
        private System.Windows.Forms.ToolStripMenuItem btnAyarlar;
        private System.Windows.Forms.ToolStripMenuItem btnLisans;
        private System.Windows.Forms.ToolStripMenuItem btnGuncDenetle;
        private System.Windows.Forms.ToolStripMenuItem btnVeritabani;
        private System.Windows.Forms.ToolStripMenuItem btnVeritabaniDisaAktar;
        private System.Windows.Forms.ToolStripMenuItem btnYetkili;
        private System.Windows.Forms.ToolStripMenuItem btnYetkili_Ekle;
        private System.Windows.Forms.ToolStripMenuItem btnYetkili_Duzenle;
        private System.Windows.Forms.ToolStripMenuItem btnYetkili_Sil;
        private System.Windows.Forms.ToolStripMenuItem btnKullanici;
        private System.Windows.Forms.ToolStripMenuItem btnKullanici_Ekle;
        private System.Windows.Forms.ToolStripMenuItem btnKullanici_Duzenle;
        private System.Windows.Forms.ToolStripMenuItem btnKullanici_Sil;
        public System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripLabel lblKullaniciHesap;
        private System.Windows.Forms.ToolStripButton btnKulHesapAyar;
        private System.Windows.Forms.ToolStripMenuItem btnKullaniciHesabi;
        private System.Windows.Forms.ToolStripMenuItem btnKullaniciHesabi_Ekle;
        private System.Windows.Forms.ToolStripMenuItem btnKullaniciHesabi_Duzenle;
        private System.Windows.Forms.ToolStripMenuItem btnKullaniciHesabi_Sil;
        private System.Windows.Forms.ToolStripMenuItem btnHakkinda;
        private System.Windows.Forms.ToolStripMenuItem btnVeritabaniOtoYedekle;
        private System.Windows.Forms.ToolStripDropDownButton btnEklenti;
        private System.Windows.Forms.ToolStripMenuItem btnHatirlatici;
    }
}

