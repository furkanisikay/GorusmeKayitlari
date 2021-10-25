using GorusmeKayitlari.Core.Components;

namespace GorusmeKayitlari.App.Formlar
{
    partial class KullaniciEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciEkle));
            this.gboxTemel = new System.Windows.Forms.GroupBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pboxResim = new System.Windows.Forms.PictureBox();
            this.gboxIletisim = new System.Windows.Forms.GroupBox();
            this.txtTelefon = new System.Windows.Forms.MaskedTextBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEPosta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.gboxTemel.Controls.Add(this.txtSoyad);
            this.gboxTemel.Controls.Add(this.label1);
            this.gboxTemel.Controls.Add(this.txtAd);
            this.gboxTemel.Controls.Add(this.label2);
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
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Soyad";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ad";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.gboxIletisim.Controls.Add(this.txtTelefon);
            this.gboxIletisim.Controls.Add(this.txtAciklama);
            this.gboxIletisim.Controls.Add(this.label6);
            this.gboxIletisim.Controls.Add(this.txtEPosta);
            this.gboxIletisim.Controls.Add(this.label3);
            this.gboxIletisim.Controls.Add(this.label4);
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
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Açıklama";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "E-Posta";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Telefon";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // KullaniciEkle
            // 
            this.AcceptButton = this.btnEkleGuncelleSil.EkleGuncelleButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 361);
            this.Controls.Add(this.gboxTemel);
            this.Controls.Add(this.pboxResim);
            this.Controls.Add(this.btnEkleGuncelleSil);
            this.Controls.Add(this.gboxIletisim);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KullaniciEkle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanici Ekle";
            this.Load += new System.EventHandler(this.KullaniciEkle_Load);
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
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pboxResim;
        private Components.IslemButonlari btnEkleGuncelleSil;
        private System.Windows.Forms.GroupBox gboxIletisim;
        private System.Windows.Forms.MaskedTextBox txtTelefon;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEPosta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Components.CustomErrorProvider cErrProMain;
    }
}