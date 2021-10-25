namespace GorusmeKayitlari.App.Formlar
{
    partial class KurumEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KurumEkle));
            this.gboxTemel = new System.Windows.Forms.GroupBox();
            this.nsYetkili = new GorusmeKayitlari.App.Bilesenler.NesneSec();
            this.nsKategori = new GorusmeKayitlari.App.Bilesenler.NesneSec();
            this.lblYetkili = new System.Windows.Forms.Label();
            this.lblKategori = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.lblAd = new System.Windows.Forms.Label();
            this.pboxResim = new System.Windows.Forms.PictureBox();
            this.gboxIletisim = new System.Windows.Forms.GroupBox();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.lblAdres = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.MaskedTextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.MaskedTextBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.txtEPosta = new System.Windows.Forms.TextBox();
            this.lblEPosta = new System.Windows.Forms.Label();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.btnEkleGuncelleSil = new GorusmeKayitlari.Components.IslemButonlari();
            this.cErrProMain = new GorusmeKayitlari.Components.CustomErrorProvider(this.components);
            this.gboxTemel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).BeginInit();
            this.gboxIletisim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cErrProMain)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxTemel
            // 
            this.gboxTemel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxTemel.Controls.Add(this.nsYetkili);
            this.gboxTemel.Controls.Add(this.nsKategori);
            this.gboxTemel.Controls.Add(this.lblYetkili);
            this.gboxTemel.Controls.Add(this.lblKategori);
            this.gboxTemel.Controls.Add(this.txtAd);
            this.gboxTemel.Controls.Add(this.lblAd);
            this.gboxTemel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gboxTemel.Location = new System.Drawing.Point(12, 70);
            this.gboxTemel.Name = "gboxTemel";
            this.gboxTemel.Size = new System.Drawing.Size(361, 117);
            this.gboxTemel.TabIndex = 0;
            this.gboxTemel.TabStop = false;
            this.gboxTemel.Text = "Temel Bilgiler";
            // 
            // nsYetkili
            // 
            this.nsYetkili.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nsYetkili.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cErrProMain.SetIconAlignment(this.nsYetkili, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.nsYetkili.Location = new System.Drawing.Point(88, 86);
            this.nsYetkili.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nsYetkili.Name = "nsYetkili";
            this.nsYetkili.SecilenNesneId = -1;
            this.nsYetkili.Size = new System.Drawing.Size(267, 25);
            this.nsYetkili.TabIndex = 2;
            this.nsYetkili.Tur = GorusmeKayitlari.Core.DB.Objects.NesneTuru.Yetkili;
            this.nsYetkili.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            // 
            // nsKategori
            // 
            this.nsKategori.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nsKategori.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cErrProMain.SetIconAlignment(this.nsKategori, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.nsKategori.Location = new System.Drawing.Point(88, 55);
            this.nsKategori.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nsKategori.Name = "nsKategori";
            this.nsKategori.SecilenNesneId = -1;
            this.nsKategori.Size = new System.Drawing.Size(267, 25);
            this.nsKategori.TabIndex = 1;
            this.nsKategori.Tur = GorusmeKayitlari.Core.DB.Objects.NesneTuru.Kategori;
            this.nsKategori.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            // 
            // lblYetkili
            // 
            this.lblYetkili.Location = new System.Drawing.Point(16, 86);
            this.lblYetkili.Name = "lblYetkili";
            this.lblYetkili.Size = new System.Drawing.Size(66, 25);
            this.lblYetkili.TabIndex = 8;
            this.lblYetkili.Text = "Yetkili";
            this.lblYetkili.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKategori
            // 
            this.lblKategori.Location = new System.Drawing.Point(16, 55);
            this.lblKategori.Name = "lblKategori";
            this.lblKategori.Size = new System.Drawing.Size(66, 25);
            this.lblKategori.TabIndex = 6;
            this.lblKategori.Text = "Kategori";
            this.lblKategori.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAd
            // 
            this.txtAd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAd.Location = new System.Drawing.Point(88, 24);
            this.txtAd.MaxLength = 60;
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(267, 25);
            this.txtAd.TabIndex = 0;
            this.txtAd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            // 
            // lblAd
            // 
            this.lblAd.Location = new System.Drawing.Point(16, 24);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(66, 25);
            this.lblAd.TabIndex = 4;
            this.lblAd.Text = "Ad";
            this.lblAd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pboxResim
            // 
            this.pboxResim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxResim.Location = new System.Drawing.Point(160, 0);
            this.pboxResim.Name = "pboxResim";
            this.pboxResim.Size = new System.Drawing.Size(64, 64);
            this.pboxResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pboxResim.TabIndex = 9;
            this.pboxResim.TabStop = false;
            // 
            // gboxIletisim
            // 
            this.gboxIletisim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxIletisim.Controls.Add(this.txtAdres);
            this.gboxIletisim.Controls.Add(this.lblAdres);
            this.gboxIletisim.Controls.Add(this.txtFax);
            this.gboxIletisim.Controls.Add(this.lblFax);
            this.gboxIletisim.Controls.Add(this.txtTelefon);
            this.gboxIletisim.Controls.Add(this.txtAciklama);
            this.gboxIletisim.Controls.Add(this.lblAciklama);
            this.gboxIletisim.Controls.Add(this.txtEPosta);
            this.gboxIletisim.Controls.Add(this.lblEPosta);
            this.gboxIletisim.Controls.Add(this.lblTelefon);
            this.gboxIletisim.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gboxIletisim.Location = new System.Drawing.Point(12, 193);
            this.gboxIletisim.Name = "gboxIletisim";
            this.gboxIletisim.Size = new System.Drawing.Size(361, 180);
            this.gboxIletisim.TabIndex = 1;
            this.gboxIletisim.TabStop = false;
            this.gboxIletisim.Text = "İletişim Bilgileri";
            // 
            // txtAdres
            // 
            this.txtAdres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdres.Location = new System.Drawing.Point(88, 117);
            this.txtAdres.MaxLength = 255;
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(267, 25);
            this.txtAdres.TabIndex = 3;
            this.txtAdres.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            // 
            // lblAdres
            // 
            this.lblAdres.Location = new System.Drawing.Point(16, 117);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new System.Drawing.Size(66, 25);
            this.lblAdres.TabIndex = 13;
            this.lblAdres.Text = "Adres";
            this.lblAdres.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFax
            // 
            this.txtFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFax.Location = new System.Drawing.Point(88, 55);
            this.txtFax.Mask = "0(999) 000-0000";
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(267, 25);
            this.txtFax.TabIndex = 1;
            this.txtFax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtFax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            // 
            // lblFax
            // 
            this.lblFax.Location = new System.Drawing.Point(16, 55);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(66, 25);
            this.lblFax.TabIndex = 10;
            this.lblFax.Text = "Fax";
            this.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefon.Location = new System.Drawing.Point(88, 24);
            this.txtTelefon.Mask = "0(999) 000-0000";
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(267, 25);
            this.txtTelefon.TabIndex = 0;
            this.txtTelefon.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtTelefon.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            // 
            // txtAciklama
            // 
            this.txtAciklama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAciklama.Location = new System.Drawing.Point(88, 149);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(267, 25);
            this.txtAciklama.TabIndex = 4;
            this.txtAciklama.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            // 
            // lblAciklama
            // 
            this.lblAciklama.Location = new System.Drawing.Point(16, 149);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(66, 25);
            this.lblAciklama.TabIndex = 8;
            this.lblAciklama.Text = "Açıklama";
            this.lblAciklama.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEPosta
            // 
            this.txtEPosta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEPosta.Location = new System.Drawing.Point(88, 86);
            this.txtEPosta.MaxLength = 255;
            this.txtEPosta.Name = "txtEPosta";
            this.txtEPosta.Size = new System.Drawing.Size(267, 25);
            this.txtEPosta.TabIndex = 2;
            this.txtEPosta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            // 
            // lblEPosta
            // 
            this.lblEPosta.Location = new System.Drawing.Point(16, 86);
            this.lblEPosta.Name = "lblEPosta";
            this.lblEPosta.Size = new System.Drawing.Size(66, 25);
            this.lblEPosta.TabIndex = 6;
            this.lblEPosta.Text = "E-Posta";
            this.lblEPosta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTelefon
            // 
            this.lblTelefon.Location = new System.Drawing.Point(16, 24);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(66, 25);
            this.lblTelefon.TabIndex = 4;
            this.lblTelefon.Text = "Telefon";
            this.lblTelefon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnEkleGuncelleSil
            // 
            this.btnEkleGuncelleSil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEkleGuncelleSil.Durum = GorusmeKayitlari.Core.Components.IslemButonlariDurumu.Ekle;
            this.btnEkleGuncelleSil.Location = new System.Drawing.Point(12, 392);
            this.btnEkleGuncelleSil.Name = "btnEkleGuncelleSil";
            this.btnEkleGuncelleSil.Size = new System.Drawing.Size(361, 43);
            this.btnEkleGuncelleSil.TabIndex = 2;
            this.btnEkleGuncelleSil.EkleGuncelleTiklandiginda += new System.EventHandler(this.BtnEkleGuncelleSil_EkleGuncelleTiklandiginda);
            this.btnEkleGuncelleSil.SilTiklandiginda += new System.EventHandler(this.BtnEkleGuncelleSil_SilTiklandiginda);
            this.btnEkleGuncelleSil.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            // 
            // cErrProMain
            // 
            this.cErrProMain.AzaltilacakWidth = 20;
            this.cErrProMain.ContainerControl = this;
            this.cErrProMain.Icon = ((System.Drawing.Icon)(resources.GetObject("cErrProMain.Icon")));
            // 
            // KurumEkle
            // 
            this.AcceptButton = this.btnEkleGuncelleSil.EkleGuncelleButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 447);
            this.Controls.Add(this.gboxTemel);
            this.Controls.Add(this.pboxResim);
            this.Controls.Add(this.btnEkleGuncelleSil);
            this.Controls.Add(this.gboxIletisim);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KurumEkle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kurum Ekle";
            this.Load += new System.EventHandler(this.KurumEkle_Load);
            this.gboxTemel.ResumeLayout(false);
            this.gboxTemel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).EndInit();
            this.gboxIletisim.ResumeLayout(false);
            this.gboxIletisim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cErrProMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxTemel;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.PictureBox pboxResim;
        private Components.IslemButonlari btnEkleGuncelleSil;
        private System.Windows.Forms.GroupBox gboxIletisim;
        private System.Windows.Forms.MaskedTextBox txtTelefon;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.TextBox txtEPosta;
        private System.Windows.Forms.Label lblEPosta;
        private System.Windows.Forms.Label lblTelefon;
        private Components.CustomErrorProvider cErrProMain;
        private System.Windows.Forms.MaskedTextBox txtFax;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.Label lblAdres;
        private System.Windows.Forms.Label lblKategori;
        private System.Windows.Forms.Label lblYetkili;
        private Bilesenler.NesneSec nsKategori;
        private Bilesenler.NesneSec nsYetkili;
    }
}