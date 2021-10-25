namespace GorusmeKayitlari.App.Formlar
{
    partial class KategoriEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KategoriEkle));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nsUstKategori = new GorusmeKayitlari.App.Bilesenler.NesneSec();
            this.txtIsim = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pboxResim = new System.Windows.Forms.PictureBox();
            this.btnEkleGuncelleSil = new GorusmeKayitlari.Components.IslemButonlari();
            this.cErrProMain = new GorusmeKayitlari.Components.CustomErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cErrProMain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.nsUstKategori);
            this.groupBox1.Controls.Add(this.txtIsim);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Temel Bilgiler";
            // 
            // nsUstKategori
            // 
            this.nsUstKategori.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nsUstKategori.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cErrProMain.SetIconAlignment(this.nsUstKategori, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.nsUstKategori.Location = new System.Drawing.Point(108, 18);
            this.nsUstKategori.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nsUstKategori.Name = "nsUstKategori";
            this.nsUstKategori.SecilenNesneId = -1;
            this.nsUstKategori.Size = new System.Drawing.Size(351, 25);
            this.nsUstKategori.TabIndex = 0;
            this.nsUstKategori.Tur = GorusmeKayitlari.Core.DB.Objects.NesneTuru.Kategori;
            this.nsUstKategori.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KategoriEkle_KeyUp);
            this.nsUstKategori.NesneSecildiginde += new System.EventHandler<int>(this.NesneSec1_NesneSecildiginde);
            // 
            // txtIsim
            // 
            this.txtIsim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIsim.Location = new System.Drawing.Point(108, 50);
            this.txtIsim.MaxLength = 255;
            this.txtIsim.Name = "txtIsim";
            this.txtIsim.Size = new System.Drawing.Size(351, 25);
            this.txtIsim.TabIndex = 1;
            this.txtIsim.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KategoriEkle_KeyUp);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "İsim";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Üst Kategori";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pboxResim
            // 
            this.pboxResim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxResim.Location = new System.Drawing.Point(213, 0);
            this.pboxResim.Name = "pboxResim";
            this.pboxResim.Size = new System.Drawing.Size(64, 64);
            this.pboxResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pboxResim.TabIndex = 2;
            this.pboxResim.TabStop = false;
            // 
            // btnEkleGuncelleSil
            // 
            this.btnEkleGuncelleSil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEkleGuncelleSil.Durum = GorusmeKayitlari.Core.Components.IslemButonlariDurumu.Ekle;
            this.btnEkleGuncelleSil.Location = new System.Drawing.Point(12, 168);
            this.btnEkleGuncelleSil.Name = "btnEkleGuncelleSil";
            this.btnEkleGuncelleSil.Size = new System.Drawing.Size(474, 43);
            this.btnEkleGuncelleSil.TabIndex = 1;
            this.btnEkleGuncelleSil.EkleGuncelleTiklandiginda += new System.EventHandler(this.BtnEkleGuncelleSil_EkleGuncelleTiklandiginda);
            this.btnEkleGuncelleSil.SilTiklandiginda += new System.EventHandler(this.BtnEkleGuncelleSil_SilTiklandiginda);
            this.btnEkleGuncelleSil.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KategoriEkle_KeyUp);
            // 
            // cErrProMain
            // 
            this.cErrProMain.AzaltilacakWidth = 20;
            this.cErrProMain.ContainerControl = this;
            this.cErrProMain.Icon = ((System.Drawing.Icon)(resources.GetObject("cErrProMain.Icon")));
            // 
            // KategoriEkle
            // 
            this.AcceptButton = this.btnEkleGuncelleSil.EkleGuncelleButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 223);
            this.Controls.Add(this.pboxResim);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEkleGuncelleSil);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 262);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(506, 262);
            this.Name = "KategoriEkle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kategori Ekle";
            this.Load += new System.EventHandler(this.KategoriEkle_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KategoriEkle_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KategoriEkle_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cErrProMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.IslemButonlari btnEkleGuncelleSil;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIsim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pboxResim;
        private Components.CustomErrorProvider cErrProMain;
        private Bilesenler.NesneSec nsUstKategori;
    }
}