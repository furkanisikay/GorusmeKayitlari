namespace GorusmeKayitlari.App.Formlar.DigerFormlar
{
    partial class KullaniciHesapEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciHesapEkle));
            this.lblKullaniciAd = new System.Windows.Forms.Label();
            this.txtKullaniciAd = new System.Windows.Forms.TextBox();
            this.nsKullanici = new GorusmeKayitlari.App.Bilesenler.NesneSec();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEkleGuncelleSil = new GorusmeKayitlari.Components.IslemButonlari();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.yYetkiler = new GorusmeKayitlari.Components.KullaniciHesapBilesenleri.Yetkiler();
            this.cmbHesapDurum = new System.Windows.Forms.ComboBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOlTarihi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cErrProMain = new GorusmeKayitlari.Components.CustomErrorProvider(this.components);
            this.lblSonDuzKullanici = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSonDuzTarihi = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pboxResim = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cErrProMain)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).BeginInit();
            this.SuspendLayout();
            // 
            // lblKullaniciAd
            // 
            this.lblKullaniciAd.AutoSize = true;
            this.lblKullaniciAd.Location = new System.Drawing.Point(44, 63);
            this.lblKullaniciAd.Name = "lblKullaniciAd";
            this.lblKullaniciAd.Size = new System.Drawing.Size(82, 19);
            this.lblKullaniciAd.TabIndex = 0;
            this.lblKullaniciAd.Text = "Kullanıcı Adı";
            // 
            // txtKullaniciAd
            // 
            this.txtKullaniciAd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKullaniciAd.Location = new System.Drawing.Point(132, 60);
            this.txtKullaniciAd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKullaniciAd.Name = "txtKullaniciAd";
            this.txtKullaniciAd.Size = new System.Drawing.Size(292, 25);
            this.txtKullaniciAd.TabIndex = 1;
            // 
            // nsKullanici
            // 
            this.nsKullanici.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nsKullanici.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nsKullanici.Location = new System.Drawing.Point(132, 26);
            this.nsKullanici.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.nsKullanici.Name = "nsKullanici";
            this.nsKullanici.SecilenNesneId = -1;
            this.nsKullanici.Size = new System.Drawing.Size(292, 25);
            this.nsKullanici.TabIndex = 0;
            this.nsKullanici.Tur = GorusmeKayitlari.Core.DB.Objects.NesneTuru.Kullanici;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hesap Kullanıcısı";
            // 
            // btnEkleGuncelleSil
            // 
            this.btnEkleGuncelleSil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEkleGuncelleSil.Durum = GorusmeKayitlari.Core.Components.IslemButonlariDurumu.Ekle;
            this.btnEkleGuncelleSil.Location = new System.Drawing.Point(12, 412);
            this.btnEkleGuncelleSil.Name = "btnEkleGuncelleSil";
            this.btnEkleGuncelleSil.Size = new System.Drawing.Size(440, 33);
            this.btnEkleGuncelleSil.TabIndex = 2;
            this.btnEkleGuncelleSil.EkleGuncelleTiklandiginda += new System.EventHandler(this.BtnEkleGuncelleSil_EkleGuncelleTiklandiginda);
            this.btnEkleGuncelleSil.SilTiklandiginda += new System.EventHandler(this.BtnEkleGuncelleSil_SilTiklandiginda);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.yYetkiler);
            this.groupBox1.Controls.Add(this.cmbHesapDurum);
            this.groupBox1.Controls.Add(this.nsKullanici);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSifre);
            this.groupBox1.Controls.Add(this.txtKullaniciAd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblKullaniciAd);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(430, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bilgiler";
            // 
            // yYetkiler
            // 
            this.yYetkiler.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.yYetkiler.Location = new System.Drawing.Point(132, 126);
            this.yYetkiler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.yYetkiler.Name = "yYetkiler";
            this.yYetkiler.Size = new System.Drawing.Size(292, 25);
            this.yYetkiler.TabIndex = 3;
            // 
            // cmbHesapDurum
            // 
            this.cmbHesapDurum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbHesapDurum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHesapDurum.FormattingEnabled = true;
            this.cmbHesapDurum.Location = new System.Drawing.Point(132, 159);
            this.cmbHesapDurum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbHesapDurum.Name = "cmbHesapDurum";
            this.cmbHesapDurum.Size = new System.Drawing.Size(292, 25);
            this.cmbHesapDurum.TabIndex = 4;
            // 
            // txtSifre
            // 
            this.txtSifre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSifre.Location = new System.Drawing.Point(132, 93);
            this.txtSifre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(292, 25);
            this.txtSifre.TabIndex = 2;
            this.txtSifre.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hesap Yetkileri";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Hesap Durumu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Hesap Şifresi";
            // 
            // lblOlTarihi
            // 
            this.lblOlTarihi.AutoSize = true;
            this.lblOlTarihi.Location = new System.Drawing.Point(128, 25);
            this.lblOlTarihi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblOlTarihi.Name = "lblOlTarihi";
            this.lblOlTarihi.Size = new System.Drawing.Size(147, 19);
            this.lblOlTarihi.TabIndex = 0;
            this.lblOlTarihi.Text = "00.00.0000 - 00:00:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Olusturulma Tarihi";
            // 
            // cErrProMain
            // 
            this.cErrProMain.AzaltilacakWidth = 20;
            this.cErrProMain.ContainerControl = this;
            this.cErrProMain.Icon = ((System.Drawing.Icon)(resources.GetObject("cErrProMain.Icon")));
            // 
            // lblSonDuzKullanici
            // 
            this.lblSonDuzKullanici.AutoSize = true;
            this.lblSonDuzKullanici.Location = new System.Drawing.Point(128, 75);
            this.lblSonDuzKullanici.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblSonDuzKullanici.Name = "lblSonDuzKullanici";
            this.lblSonDuzKullanici.Size = new System.Drawing.Size(15, 19);
            this.lblSonDuzKullanici.TabIndex = 1;
            this.lblSonDuzKullanici.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "Son Düzenleyen\r\n";
            // 
            // lblSonDuzTarihi
            // 
            this.lblSonDuzTarihi.AutoSize = true;
            this.lblSonDuzTarihi.Location = new System.Drawing.Point(128, 52);
            this.lblSonDuzTarihi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblSonDuzTarihi.Name = "lblSonDuzTarihi";
            this.lblSonDuzTarihi.Size = new System.Drawing.Size(147, 19);
            this.lblSonDuzTarihi.TabIndex = 3;
            this.lblSonDuzTarihi.Text = "00.00.0000 - 00:00:00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 19);
            this.label9.TabIndex = 4;
            this.label9.Text = "Son Düzenleme";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblSonDuzKullanici);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblOlTarihi);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtAciklama);
            this.groupBox2.Controls.Add(this.lblSonDuzTarihi);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 137);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detaylar";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAciklama.Location = new System.Drawing.Point(132, 102);
            this.txtAciklama.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(292, 25);
            this.txtAciklama.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Açıklama";
            // 
            // pboxResim
            // 
            this.pboxResim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxResim.Location = new System.Drawing.Point(195, 0);
            this.pboxResim.Name = "pboxResim";
            this.pboxResim.Size = new System.Drawing.Size(64, 64);
            this.pboxResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pboxResim.TabIndex = 13;
            this.pboxResim.TabStop = false;
            // 
            // KullaniciHesapEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 457);
            this.Controls.Add(this.pboxResim);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEkleGuncelleSil);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KullaniciHesapEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Hesap Ekle";
            this.Load += new System.EventHandler(this.KullaniciHesapAyarlari_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KullaniciHesapAyarlari_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cErrProMain)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtKullaniciAd;
        private System.Windows.Forms.Label lblKullaniciAd;
        private Bilesenler.NesneSec nsKullanici;
        private System.Windows.Forms.Label label1;
        private Components.IslemButonlari btnEkleGuncelleSil;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSifre;
        private Components.CustomErrorProvider cErrProMain;
        private System.Windows.Forms.ComboBox cmbHesapDurum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblOlTarihi;
        private System.Windows.Forms.Label lblSonDuzKullanici;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSonDuzTarihi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pboxResim;
        private Components.KullaniciHesapBilesenleri.Yetkiler yYetkiler;
    }
}