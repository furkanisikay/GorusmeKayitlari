namespace GorusmeKayitlari.App.Formlar
{
    partial class NesneSec
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Deneme",
            "Nesne",
            "+905400000000",
            "deneme@ornek.com",
            "..."}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NesneSec));
            this.lstNesneler = new System.Windows.Forms.ListView();
            this.clmAd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSoyad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTelefon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEposta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAciklama = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsNesneler = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsNesneler_Arama = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNesneler_YenidenYukle = new System.Windows.Forms.ToolStripMenuItem();
            this.pboxResim = new System.Windows.Forms.PictureBox();
            this.gboxAra = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chckBKHDuyarlı = new System.Windows.Forms.CheckBox();
            this.lblArananDeger = new System.Windows.Forms.Label();
            this.lblAranacakBolum = new System.Windows.Forms.Label();
            this.txtBul = new System.Windows.Forms.TextBox();
            this.cmbBul = new System.Windows.Forms.ComboBox();
            this.btnBul = new System.Windows.Forms.Button();
            this.ttBul = new System.Windows.Forms.ToolTip(this.components);
            this.btnOnaylaIptal = new GorusmeKayitlari.Components.OnaylaIptal();
            this.pboxBul = new System.Windows.Forms.PictureBox();
            this.cmsNesneler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).BeginInit();
            this.gboxAra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBul)).BeginInit();
            this.SuspendLayout();
            // 
            // lstNesneler
            // 
            this.lstNesneler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstNesneler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmAd,
            this.clmSoyad,
            this.clmTelefon,
            this.clmEposta,
            this.clmAciklama});
            this.lstNesneler.ContextMenuStrip = this.cmsNesneler;
            this.lstNesneler.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lstNesneler.Location = new System.Drawing.Point(12, 70);
            this.lstNesneler.Name = "lstNesneler";
            this.lstNesneler.Size = new System.Drawing.Size(532, 270);
            this.lstNesneler.TabIndex = 0;
            this.lstNesneler.UseCompatibleStateImageBehavior = false;
            this.lstNesneler.View = System.Windows.Forms.View.Details;
            this.lstNesneler.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LstNesneler_MouseDoubleClick);
            // 
            // clmAd
            // 
            this.clmAd.Text = "Ad";
            this.clmAd.Width = 106;
            // 
            // clmSoyad
            // 
            this.clmSoyad.Text = "Soyad";
            this.clmSoyad.Width = 105;
            // 
            // clmTelefon
            // 
            this.clmTelefon.Text = "Telefon";
            this.clmTelefon.Width = 109;
            // 
            // clmEposta
            // 
            this.clmEposta.Text = "E-Posta";
            this.clmEposta.Width = 124;
            // 
            // clmAciklama
            // 
            this.clmAciklama.Text = "Açıklama";
            this.clmAciklama.Width = 84;
            // 
            // cmsNesneler
            // 
            this.cmsNesneler.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsNesneler_Arama,
            this.cmsNesneler_YenidenYukle});
            this.cmsNesneler.Name = "cmsNesneler";
            this.cmsNesneler.Size = new System.Drawing.Size(99, 48);
            // 
            // cmsNesneler_Arama
            // 
            this.cmsNesneler_Arama.Image = ((System.Drawing.Image)(resources.GetObject("cmsNesneler_Arama.Image")));
            this.cmsNesneler_Arama.Name = "cmsNesneler_Arama";
            this.cmsNesneler_Arama.ShortcutKeyDisplayString = "(CTRL + F)";
            this.cmsNesneler_Arama.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.cmsNesneler_Arama.ShowShortcutKeys = false;
            this.cmsNesneler_Arama.Size = new System.Drawing.Size(98, 22);
            this.cmsNesneler_Arama.Text = "Bul";
            this.cmsNesneler_Arama.ToolTipText = "Arama Menüsünü Gösterir. (CTRL + F)";
            this.cmsNesneler_Arama.Click += new System.EventHandler(this.CmsNesneler_Arama_Click);
            // 
            // cmsNesneler_YenidenYukle
            // 
            this.cmsNesneler_YenidenYukle.Image = ((System.Drawing.Image)(resources.GetObject("cmsNesneler_YenidenYukle.Image")));
            this.cmsNesneler_YenidenYukle.Name = "cmsNesneler_YenidenYukle";
            this.cmsNesneler_YenidenYukle.ShortcutKeyDisplayString = "";
            this.cmsNesneler_YenidenYukle.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.cmsNesneler_YenidenYukle.ShowShortcutKeys = false;
            this.cmsNesneler_YenidenYukle.Size = new System.Drawing.Size(98, 22);
            this.cmsNesneler_YenidenYukle.Text = "Yenile";
            this.cmsNesneler_YenidenYukle.ToolTipText = "Listeyi Tekrar Yükler. (F5)";
            this.cmsNesneler_YenidenYukle.Click += new System.EventHandler(this.CmsNesneler_YenidenYukle_Click);
            // 
            // pboxResim
            // 
            this.pboxResim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxResim.Location = new System.Drawing.Point(246, 0);
            this.pboxResim.Name = "pboxResim";
            this.pboxResim.Size = new System.Drawing.Size(64, 64);
            this.pboxResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pboxResim.TabIndex = 13;
            this.pboxResim.TabStop = false;
            // 
            // gboxAra
            // 
            this.gboxAra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxAra.Controls.Add(this.checkBox1);
            this.gboxAra.Controls.Add(this.chckBKHDuyarlı);
            this.gboxAra.Controls.Add(this.lblArananDeger);
            this.gboxAra.Controls.Add(this.lblAranacakBolum);
            this.gboxAra.Controls.Add(this.txtBul);
            this.gboxAra.Controls.Add(this.cmbBul);
            this.gboxAra.Controls.Add(this.btnBul);
            this.gboxAra.Enabled = false;
            this.gboxAra.Location = new System.Drawing.Point(12, 277);
            this.gboxAra.Name = "gboxAra";
            this.gboxAra.Size = new System.Drawing.Size(532, 65);
            this.gboxAra.TabIndex = 14;
            this.gboxAra.TabStop = false;
            this.gboxAra.Text = "Ara && Bul";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(180, 44);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(135, 17);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "Tam Sözcük Eşleşmesi";
            this.ttBul.SetToolTip(this.checkBox1, "Aranan Sözcük ile Bulunan Sözcüğün Tam Eşleşmesi için kullanır.");
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chckBKHDuyarlı
            // 
            this.chckBKHDuyarlı.AutoSize = true;
            this.chckBKHDuyarlı.Location = new System.Drawing.Point(9, 44);
            this.chckBKHDuyarlı.Name = "chckBKHDuyarlı";
            this.chckBKHDuyarlı.Size = new System.Drawing.Size(148, 17);
            this.chckBKHDuyarlı.TabIndex = 21;
            this.chckBKHDuyarlı.Text = "Büyük,Küçük Harf Duyarlı";
            this.ttBul.SetToolTip(this.chckBKHDuyarlı, "Aranan Sözcük ile Bulunan Sözcüğün Harflerinin Büyüklüğünün Eşleşmesi için kullan" +
        "ır.");
            this.chckBKHDuyarlı.UseVisualStyleBackColor = true;
            // 
            // lblArananDeger
            // 
            this.lblArananDeger.AutoSize = true;
            this.lblArananDeger.Location = new System.Drawing.Point(231, 20);
            this.lblArananDeger.Name = "lblArananDeger";
            this.lblArananDeger.Size = new System.Drawing.Size(73, 13);
            this.lblArananDeger.TabIndex = 20;
            this.lblArananDeger.Text = "Aranan Değer";
            // 
            // lblAranacakBolum
            // 
            this.lblAranacakBolum.AutoSize = true;
            this.lblAranacakBolum.Location = new System.Drawing.Point(6, 20);
            this.lblAranacakBolum.Name = "lblAranacakBolum";
            this.lblAranacakBolum.Size = new System.Drawing.Size(85, 13);
            this.lblAranacakBolum.TabIndex = 20;
            this.lblAranacakBolum.Text = "Aranacak Bölüm";
            // 
            // txtBul
            // 
            this.txtBul.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBul.Location = new System.Drawing.Point(310, 17);
            this.txtBul.Name = "txtBul";
            this.txtBul.Size = new System.Drawing.Size(150, 20);
            this.txtBul.TabIndex = 19;
            this.ttBul.SetToolTip(this.txtBul, "Seçilen Bölümdeki Aranan Değer/Sözcük(ler).");
            // 
            // cmbBul
            // 
            this.cmbBul.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBul.FormattingEnabled = true;
            this.cmbBul.Location = new System.Drawing.Point(97, 17);
            this.cmbBul.Name = "cmbBul";
            this.cmbBul.Size = new System.Drawing.Size(121, 21);
            this.cmbBul.TabIndex = 18;
            this.ttBul.SetToolTip(this.cmbBul, "Sözcüklerin Aranacağı Bölüm/Sütun.");
            // 
            // btnBul
            // 
            this.btnBul.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBul.Location = new System.Drawing.Point(466, 13);
            this.btnBul.Name = "btnBul";
            this.btnBul.Size = new System.Drawing.Size(60, 27);
            this.btnBul.TabIndex = 17;
            this.btnBul.Text = "Bul";
            this.ttBul.SetToolTip(this.btnBul, "Seçilen Bölümden Belirtilen Sözcük(ler) ile Arama Yapar.");
            this.btnBul.UseVisualStyleBackColor = true;
            this.btnBul.Click += new System.EventHandler(this.BtnBul_Click);
            // 
            // ttBul
            // 
            this.ttBul.IsBalloon = true;
            this.ttBul.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttBul.ToolTipTitle = "Bilgi";
            // 
            // btnOnaylaIptal
            // 
            this.btnOnaylaIptal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOnaylaIptal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnOnaylaIptal.Location = new System.Drawing.Point(12, 347);
            this.btnOnaylaIptal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOnaylaIptal.Name = "btnOnaylaIptal";
            this.btnOnaylaIptal.Size = new System.Drawing.Size(532, 44);
            this.btnOnaylaIptal.TabIndex = 1;
            this.btnOnaylaIptal.Onaylandiginde += new System.EventHandler(this.OnaylaIptal1_Onaylandiginde);
            this.btnOnaylaIptal.IptalEdildiginde += new System.EventHandler(this.OnaylaIptal1_IptalEdildiginde);
            // 
            // pboxBul
            // 
            this.pboxBul.Image = GorusmeKayitlari.Resources.DigerResimler.Buyutec;
            this.pboxBul.Location = new System.Drawing.Point(512, 32);
            this.pboxBul.Name = "pboxBul";
            this.pboxBul.Size = new System.Drawing.Size(32, 32);
            this.pboxBul.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxBul.TabIndex = 15;
            this.pboxBul.TabStop = false;
            this.ttBul.SetToolTip(this.pboxBul, "Ara-Bul");
            this.pboxBul.Click += new System.EventHandler(this.pboxBul_Click);
            // 
            // NesneSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 404);
            this.Controls.Add(this.pboxBul);
            this.Controls.Add(this.lstNesneler);
            this.Controls.Add(this.gboxAra);
            this.Controls.Add(this.pboxResim);
            this.Controls.Add(this.btnOnaylaIptal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(572, 364);
            this.Name = "NesneSec";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nesne Sec";
            this.Load += new System.EventHandler(this.NesneSec_Load);
            this.cmsNesneler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).EndInit();
            this.gboxAra.ResumeLayout(false);
            this.gboxAra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBul)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Components.OnaylaIptal btnOnaylaIptal;
        private System.Windows.Forms.ListView lstNesneler;
        private System.Windows.Forms.ColumnHeader clmAd;
        private System.Windows.Forms.ColumnHeader clmSoyad;
        private System.Windows.Forms.ColumnHeader clmTelefon;
        private System.Windows.Forms.ColumnHeader clmEposta;
        private System.Windows.Forms.ColumnHeader clmAciklama;
        private System.Windows.Forms.PictureBox pboxResim;
        private System.Windows.Forms.ContextMenuStrip cmsNesneler;
        private System.Windows.Forms.GroupBox gboxAra;
        private System.Windows.Forms.Label lblArananDeger;
        private System.Windows.Forms.Label lblAranacakBolum;
        private System.Windows.Forms.TextBox txtBul;
        private System.Windows.Forms.ComboBox cmbBul;
        private System.Windows.Forms.Button btnBul;
        private System.Windows.Forms.ToolStripMenuItem cmsNesneler_YenidenYukle;
        private System.Windows.Forms.CheckBox chckBKHDuyarlı;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolTip ttBul;
        private System.Windows.Forms.ToolStripMenuItem cmsNesneler_Arama;
        private System.Windows.Forms.PictureBox pboxBul;
    }
}