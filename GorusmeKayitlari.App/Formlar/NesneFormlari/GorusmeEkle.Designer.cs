namespace GorusmeKayitlari.App.Formlar.NesneFormlari
{
    partial class GorusmeEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GorusmeEkle));
            this.gboxTemel = new System.Windows.Forms.GroupBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.nsYetkili = new GorusmeKayitlari.App.Bilesenler.NesneSec();
            this.nsKurum = new GorusmeKayitlari.App.Bilesenler.NesneSec();
            this.label1 = new System.Windows.Forms.Label();
            this.nsKullanici = new GorusmeKayitlari.App.Bilesenler.NesneSec();
            this.lblKullanici = new System.Windows.Forms.Label();
            this.lblYetkili = new System.Windows.Forms.Label();
            this.txtMetin = new System.Windows.Forms.TextBox();
            this.lblTarih = new System.Windows.Forms.Label();
            this.lblMetin = new System.Windows.Forms.Label();
            this.pboxResim = new System.Windows.Forms.PictureBox();
            this.btnEkleGuncelleSil = new GorusmeKayitlari.Components.IslemButonlari();
            this.cErrProMain = new GorusmeKayitlari.Components.CustomErrorProvider(this.components);
            this.gboxTemel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cErrProMain)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxTemel
            // 
            this.gboxTemel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxTemel.Controls.Add(this.dtpTarih);
            this.gboxTemel.Controls.Add(this.nsYetkili);
            this.gboxTemel.Controls.Add(this.nsKurum);
            this.gboxTemel.Controls.Add(this.label1);
            this.gboxTemel.Controls.Add(this.nsKullanici);
            this.gboxTemel.Controls.Add(this.lblKullanici);
            this.gboxTemel.Controls.Add(this.lblYetkili);
            this.gboxTemel.Controls.Add(this.txtMetin);
            this.gboxTemel.Controls.Add(this.lblTarih);
            this.gboxTemel.Controls.Add(this.lblMetin);
            this.gboxTemel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gboxTemel.Location = new System.Drawing.Point(12, 70);
            this.gboxTemel.Name = "gboxTemel";
            this.gboxTemel.Size = new System.Drawing.Size(361, 212);
            this.gboxTemel.TabIndex = 0;
            this.gboxTemel.TabStop = false;
            this.gboxTemel.Text = "Temel Bilgiler";
            // 
            // dtpTarih
            // 
            this.dtpTarih.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTarih.Location = new System.Drawing.Point(88, 120);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(267, 25);
            this.dtpTarih.TabIndex = 3;
            this.dtpTarih.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            // 
            // nsYetkili
            // 
            this.nsYetkili.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nsYetkili.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cErrProMain.SetIconAlignment(this.nsYetkili, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.nsYetkili.Location = new System.Drawing.Point(88, 55);
            this.nsYetkili.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nsYetkili.Name = "nsYetkili";
            this.nsYetkili.SecilenNesneId = -1;
            this.nsYetkili.Size = new System.Drawing.Size(267, 25);
            this.nsYetkili.TabIndex = 1;
            this.nsYetkili.Tur = GorusmeKayitlari.Core.DB.Objects.NesneTuru.Yetkili;
            this.nsYetkili.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            // 
            // nsKurum
            // 
            this.nsKurum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nsKurum.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cErrProMain.SetIconAlignment(this.nsKurum, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.nsKurum.Location = new System.Drawing.Point(88, 25);
            this.nsKurum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nsKurum.Name = "nsKurum";
            this.nsKurum.SecilenNesneId = -1;
            this.nsKurum.Size = new System.Drawing.Size(267, 25);
            this.nsKurum.TabIndex = 0;
            this.nsKurum.Tur = GorusmeKayitlari.Core.DB.Objects.NesneTuru.Kurum;
            this.nsKurum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            this.nsKurum.NesneSecildiginde += new System.EventHandler<int>(this.NsKurum_NesneSecildiginde);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Kurum";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nsKullanici
            // 
            this.nsKullanici.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nsKullanici.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cErrProMain.SetIconAlignment(this.nsKullanici, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.nsKullanici.Location = new System.Drawing.Point(88, 88);
            this.nsKullanici.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nsKullanici.Name = "nsKullanici";
            this.nsKullanici.SecilenNesneId = -1;
            this.nsKullanici.Size = new System.Drawing.Size(267, 25);
            this.nsKullanici.TabIndex = 2;
            this.nsKullanici.Tur = GorusmeKayitlari.Core.DB.Objects.NesneTuru.Kullanici;
            this.nsKullanici.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            // 
            // lblKullanici
            // 
            this.lblKullanici.Location = new System.Drawing.Point(16, 88);
            this.lblKullanici.Name = "lblKullanici";
            this.lblKullanici.Size = new System.Drawing.Size(66, 25);
            this.lblKullanici.TabIndex = 6;
            this.lblKullanici.Text = "Kullanıcı";
            this.lblKullanici.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblYetkili
            // 
            this.lblYetkili.Location = new System.Drawing.Point(16, 55);
            this.lblYetkili.Name = "lblYetkili";
            this.lblYetkili.Size = new System.Drawing.Size(66, 25);
            this.lblYetkili.TabIndex = 8;
            this.lblYetkili.Text = "Yetkili";
            this.lblYetkili.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMetin
            // 
            this.txtMetin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMetin.Location = new System.Drawing.Point(88, 151);
            this.txtMetin.MaxLength = 60;
            this.txtMetin.Multiline = true;
            this.txtMetin.Name = "txtMetin";
            this.txtMetin.Size = new System.Drawing.Size(267, 53);
            this.txtMetin.TabIndex = 4;
            this.txtMetin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtMetin_KeyUp);
            // 
            // lblTarih
            // 
            this.lblTarih.Location = new System.Drawing.Point(16, 120);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(66, 25);
            this.lblTarih.TabIndex = 4;
            this.lblTarih.Text = "Tarih";
            this.lblTarih.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMetin
            // 
            this.lblMetin.Location = new System.Drawing.Point(16, 151);
            this.lblMetin.Name = "lblMetin";
            this.lblMetin.Size = new System.Drawing.Size(66, 25);
            this.lblMetin.TabIndex = 4;
            this.lblMetin.Text = "Metin";
            this.lblMetin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pboxResim
            // 
            this.pboxResim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxResim.Location = new System.Drawing.Point(160, 0);
            this.pboxResim.Name = "pboxResim";
            this.pboxResim.Size = new System.Drawing.Size(64, 64);
            this.pboxResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pboxResim.TabIndex = 12;
            this.pboxResim.TabStop = false;
            // 
            // btnEkleGuncelleSil
            // 
            this.btnEkleGuncelleSil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEkleGuncelleSil.Durum = GorusmeKayitlari.Core.Components.IslemButonlariDurumu.Ekle;
            this.btnEkleGuncelleSil.Location = new System.Drawing.Point(12, 302);
            this.btnEkleGuncelleSil.Name = "btnEkleGuncelleSil";
            this.btnEkleGuncelleSil.Size = new System.Drawing.Size(361, 43);
            this.btnEkleGuncelleSil.TabIndex = 1;
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
            // GorusmeEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 351);
            this.Controls.Add(this.gboxTemel);
            this.Controls.Add(this.pboxResim);
            this.Controls.Add(this.btnEkleGuncelleSil);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(401, 362);
            this.Name = "GorusmeEkle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Görüşme Ekle";
            this.Load += new System.EventHandler(this.GorusmeEkle_Load);
            this.gboxTemel.ResumeLayout(false);
            this.gboxTemel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cErrProMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxTemel;
        private Bilesenler.NesneSec nsYetkili;
        private Components.CustomErrorProvider cErrProMain;
        private System.Windows.Forms.PictureBox pboxResim;
        private Components.IslemButonlari btnEkleGuncelleSil;
        private Bilesenler.NesneSec nsKurum;
        private System.Windows.Forms.Label label1;
        private Bilesenler.NesneSec nsKullanici;
        private System.Windows.Forms.Label lblKullanici;
        private System.Windows.Forms.Label lblYetkili;
        private System.Windows.Forms.TextBox txtMetin;
        private System.Windows.Forms.Label lblMetin;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label lblTarih;
    }
}