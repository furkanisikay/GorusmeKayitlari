namespace GorusmeKayitlari.Reminder.Formlar
{
    partial class HatirlatmaEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HatirlatmaEkle));
            this.pboxResim = new System.Windows.Forms.PictureBox();
            this.btnEkleGuncelleSil = new GorusmeKayitlari.Components.IslemButonlari();
            this.gboxHatirlatma = new System.Windows.Forms.GroupBox();
            this.txtMetin = new System.Windows.Forms.TextBox();
            this.dtpSaat = new System.Windows.Forms.DateTimePicker();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.lblMetin = new System.Windows.Forms.Label();
            this.lblTarih = new System.Windows.Forms.Label();
            this.cErrProMain = new GorusmeKayitlari.Components.CustomErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).BeginInit();
            this.gboxHatirlatma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cErrProMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pboxResim
            // 
            this.pboxResim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxResim.Location = new System.Drawing.Point(147, 0);
            this.pboxResim.Name = "pboxResim";
            this.pboxResim.Size = new System.Drawing.Size(64, 64);
            this.pboxResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pboxResim.TabIndex = 14;
            this.pboxResim.TabStop = false;
            // 
            // btnEkleGuncelleSil
            // 
            this.btnEkleGuncelleSil.Durum = GorusmeKayitlari.Core.Components.IslemButonlariDurumu.Ekle;
            this.btnEkleGuncelleSil.Location = new System.Drawing.Point(12, 263);
            this.btnEkleGuncelleSil.Name = "btnEkleGuncelleSil";
            this.btnEkleGuncelleSil.Size = new System.Drawing.Size(329, 36);
            this.btnEkleGuncelleSil.TabIndex = 15;
            this.btnEkleGuncelleSil.EkleGuncelleTiklandiginda += new System.EventHandler(this.BtnEkleGuncelleSil_EkleGuncelleTiklandiginda);
            this.btnEkleGuncelleSil.SilTiklandiginda += new System.EventHandler(this.BtnEkleGuncelleSil_SilTiklandiginda);
            // 
            // gboxHatirlatma
            // 
            this.gboxHatirlatma.Controls.Add(this.txtMetin);
            this.gboxHatirlatma.Controls.Add(this.dtpSaat);
            this.gboxHatirlatma.Controls.Add(this.dtpTarih);
            this.gboxHatirlatma.Controls.Add(this.lblMetin);
            this.gboxHatirlatma.Controls.Add(this.lblTarih);
            this.gboxHatirlatma.Location = new System.Drawing.Point(12, 70);
            this.gboxHatirlatma.Name = "gboxHatirlatma";
            this.gboxHatirlatma.Size = new System.Drawing.Size(335, 187);
            this.gboxHatirlatma.TabIndex = 16;
            this.gboxHatirlatma.TabStop = false;
            this.gboxHatirlatma.Text = "Hatırlatma Bilgileri";
            // 
            // txtMetin
            // 
            this.txtMetin.Location = new System.Drawing.Point(95, 49);
            this.txtMetin.Multiline = true;
            this.txtMetin.Name = "txtMetin";
            this.txtMetin.Size = new System.Drawing.Size(234, 132);
            this.txtMetin.TabIndex = 6;
            // 
            // dtpSaat
            // 
            this.dtpSaat.CustomFormat = "hh:mm:ss";
            this.dtpSaat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSaat.Location = new System.Drawing.Point(256, 19);
            this.dtpSaat.Name = "dtpSaat";
            this.dtpSaat.ShowUpDown = true;
            this.dtpSaat.Size = new System.Drawing.Size(73, 20);
            this.dtpSaat.TabIndex = 2;
            this.dtpSaat.Value = new System.DateTime(2018, 7, 2, 0, 0, 0, 0);
            // 
            // dtpTarih
            // 
            this.dtpTarih.CustomFormat = "dd.MM.yyyy [dddd] ";
            this.dtpTarih.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTarih.Location = new System.Drawing.Point(95, 19);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(155, 20);
            this.dtpTarih.TabIndex = 2;
            this.dtpTarih.Value = new System.DateTime(2018, 7, 2, 0, 0, 0, 0);
            // 
            // lblMetin
            // 
            this.lblMetin.AutoSize = true;
            this.lblMetin.Location = new System.Drawing.Point(6, 49);
            this.lblMetin.Name = "lblMetin";
            this.lblMetin.Size = new System.Drawing.Size(83, 13);
            this.lblMetin.TabIndex = 0;
            this.lblMetin.Text = "Hatırlatma Metni";
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.Location = new System.Drawing.Point(6, 23);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(83, 13);
            this.lblTarih.TabIndex = 0;
            this.lblTarih.Text = "Hatırlatma Tarihi";
            // 
            // cErrProMain
            // 
            this.cErrProMain.AzaltilacakWidth = 20;
            this.cErrProMain.ContainerControl = this;
            this.cErrProMain.Icon = ((System.Drawing.Icon)(resources.GetObject("cErrProMain.Icon")));
            // 
            // HatirlatmaEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 311);
            this.Controls.Add(this.gboxHatirlatma);
            this.Controls.Add(this.btnEkleGuncelleSil);
            this.Controls.Add(this.pboxResim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HatirlatmaEkle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hatırlatma Ekle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HatirlatmaEkle_FormClosed);
            this.Load += new System.EventHandler(this.HatirlatmaEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).EndInit();
            this.gboxHatirlatma.ResumeLayout(false);
            this.gboxHatirlatma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cErrProMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxResim;
        private Components.IslemButonlari btnEkleGuncelleSil;
        private System.Windows.Forms.GroupBox gboxHatirlatma;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.DateTimePicker dtpSaat;
        private System.Windows.Forms.TextBox txtMetin;
        private System.Windows.Forms.Label lblMetin;
        private Components.CustomErrorProvider cErrProMain;
    }
}