namespace GorusmeKayitlari.App.Formlar
{
    partial class YetkiliEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YetkiliEkle));
            this.pboxResim = new System.Windows.Forms.PictureBox();
            this.gboxTemel = new System.Windows.Forms.GroupBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.lblAd = new System.Windows.Forms.Label();
            this.gboxIletisim = new System.Windows.Forms.GroupBox();
            this.txtTelefon = new System.Windows.Forms.MaskedTextBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.txtEPosta = new System.Windows.Forms.TextBox();
            this.lblEPosta = new System.Windows.Forms.Label();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.btnEkleGuncelleSil = new GorusmeKayitlari.Components.IslemButonlari();
            this.cErrProMain = new GorusmeKayitlari.Components.CustomErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).BeginInit();
            this.gboxTemel.SuspendLayout();
            this.gboxIletisim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cErrProMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pboxResim
            // 
            this.pboxResim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxResim.Location = new System.Drawing.Point(160, 0);
            this.pboxResim.Name = "pboxResim";
            this.pboxResim.Size = new System.Drawing.Size(64, 64);
            this.pboxResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pboxResim.TabIndex = 5;
            this.pboxResim.TabStop = false;
            // 
            // gboxTemel
            // 
            this.gboxTemel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxTemel.Controls.Add(this.txtSoyad);
            this.gboxTemel.Controls.Add(this.lblSoyad);
            this.gboxTemel.Controls.Add(this.txtAd);
            this.gboxTemel.Controls.Add(this.lblAd);
            this.gboxTemel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gboxTemel.Location = new System.Drawing.Point(12, 70);
            this.gboxTemel.Name = "gboxTemel";
            this.gboxTemel.Size = new System.Drawing.Size(361, 89);
            this.gboxTemel.TabIndex = 0;
            this.gboxTemel.TabStop = false;
            this.gboxTemel.Text = "Temel Bilgiler";
            // 
            // txtSoyad
            // 
            this.txtSoyad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoyad.Location = new System.Drawing.Point(88, 55);
            this.txtSoyad.MaxLength = 60;
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(267, 25);
            this.txtSoyad.TabIndex = 1;
            this.txtSoyad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            // 
            // lblSoyad
            // 
            this.lblSoyad.Location = new System.Drawing.Point(16, 55);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(66, 25);
            this.lblSoyad.TabIndex = 6;
            this.lblSoyad.Text = "Soyad";
            this.lblSoyad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // gboxIletisim
            // 
            this.gboxIletisim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxIletisim.Controls.Add(this.txtTelefon);
            this.gboxIletisim.Controls.Add(this.txtAciklama);
            this.gboxIletisim.Controls.Add(this.lblAciklama);
            this.gboxIletisim.Controls.Add(this.txtEPosta);
            this.gboxIletisim.Controls.Add(this.lblEPosta);
            this.gboxIletisim.Controls.Add(this.lblTelefon);
            this.gboxIletisim.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gboxIletisim.Location = new System.Drawing.Point(12, 165);
            this.gboxIletisim.Name = "gboxIletisim";
            this.gboxIletisim.Size = new System.Drawing.Size(361, 120);
            this.gboxIletisim.TabIndex = 1;
            this.gboxIletisim.TabStop = false;
            this.gboxIletisim.Text = "İletişim Bilgileri";
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
            this.txtAciklama.Location = new System.Drawing.Point(88, 86);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(267, 25);
            this.txtAciklama.TabIndex = 2;
            this.txtAciklama.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            // 
            // lblAciklama
            // 
            this.lblAciklama.Location = new System.Drawing.Point(16, 86);
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
            this.txtEPosta.Location = new System.Drawing.Point(88, 55);
            this.txtEPosta.MaxLength = 255;
            this.txtEPosta.Name = "txtEPosta";
            this.txtEPosta.Size = new System.Drawing.Size(267, 25);
            this.txtEPosta.TabIndex = 1;
            this.txtEPosta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            // 
            // lblEPosta
            // 
            this.lblEPosta.Location = new System.Drawing.Point(16, 55);
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
            this.btnEkleGuncelleSil.Location = new System.Drawing.Point(12, 306);
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
            // YetkiliEkle
            // 
            this.AcceptButton = this.btnEkleGuncelleSil.EkleGuncelleButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 361);
            this.Controls.Add(this.gboxIletisim);
            this.Controls.Add(this.gboxTemel);
            this.Controls.Add(this.pboxResim);
            this.Controls.Add(this.btnEkleGuncelleSil);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YetkiliEkle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yetkili Ekle";
            this.Load += new System.EventHandler(this.YetkiliEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).EndInit();
            this.gboxTemel.ResumeLayout(false);
            this.gboxTemel.PerformLayout();
            this.gboxIletisim.ResumeLayout(false);
            this.gboxIletisim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cErrProMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.IslemButonlari btnEkleGuncelleSil;
        private System.Windows.Forms.PictureBox pboxResim;
        private System.Windows.Forms.GroupBox gboxTemel;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.Label lblSoyad;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.GroupBox gboxIletisim;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.TextBox txtEPosta;
        private System.Windows.Forms.Label lblEPosta;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.MaskedTextBox txtTelefon;
        private Components.CustomErrorProvider cErrProMain;
    }
}