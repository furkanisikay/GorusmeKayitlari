namespace GorusmeKayitlari.Components.ExcelBilesenleri
{
    partial class FontKutusu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontKutusu));
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.nudYukseklik = new System.Windows.Forms.NumericUpDown();
            this.nudGenislik = new System.Windows.Forms.NumericUpDown();
            this.cmbVerticalAlign = new System.Windows.Forms.ComboBox();
            this.cmbHorizontalAlign = new System.Windows.Forms.ComboBox();
            this.rkArkaplanRengi = new GorusmeKayitlari.Components.ExcelBilesenleri.RenkKutusu();
            this.rkYaziRengi = new GorusmeKayitlari.Components.ExcelBilesenleri.RenkKutusu();
            this.lblYaziTipi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudYukseklik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGenislik)).BeginInit();
            this.SuspendLayout();
            // 
            // ttMain
            // 
            this.ttMain.IsBalloon = true;
            this.ttMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttMain.ToolTipTitle = "Bilgi";
            // 
            // nudYukseklik
            // 
            this.nudYukseklik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudYukseklik.DecimalPlaces = 2;
            this.nudYukseklik.Location = new System.Drawing.Point(241, 9);
            this.nudYukseklik.Maximum = new decimal(new int[] {
            409,
            0,
            0,
            0});
            this.nudYukseklik.Name = "nudYukseklik";
            this.nudYukseklik.Size = new System.Drawing.Size(49, 20);
            this.nudYukseklik.TabIndex = 2;
            this.ttMain.SetToolTip(this.nudYukseklik, "Alan Yüksekliği(cm)");
            this.nudYukseklik.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudGenislik
            // 
            this.nudGenislik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudGenislik.DecimalPlaces = 2;
            this.nudGenislik.Location = new System.Drawing.Point(296, 8);
            this.nudGenislik.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudGenislik.Name = "nudGenislik";
            this.nudGenislik.Size = new System.Drawing.Size(49, 20);
            this.nudGenislik.TabIndex = 2;
            this.ttMain.SetToolTip(this.nudGenislik, "Alan Genişligi(cm)");
            this.nudGenislik.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbVerticalAlign
            // 
            this.cmbVerticalAlign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVerticalAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVerticalAlign.FormattingEnabled = true;
            this.cmbVerticalAlign.Items.AddRange(new object[] {
            "Alt",
            "Orta",
            "Üst"});
            this.cmbVerticalAlign.Location = new System.Drawing.Point(351, 9);
            this.cmbVerticalAlign.Name = "cmbVerticalAlign";
            this.cmbVerticalAlign.Size = new System.Drawing.Size(51, 21);
            this.cmbVerticalAlign.TabIndex = 3;
            this.ttMain.SetToolTip(this.cmbVerticalAlign, "Alanın Dikey Hizalaması.");
            // 
            // cmbHorizontalAlign
            // 
            this.cmbHorizontalAlign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbHorizontalAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHorizontalAlign.FormattingEnabled = true;
            this.cmbHorizontalAlign.Items.AddRange(new object[] {
            "Sol",
            "Orta",
            "Sağ"});
            this.cmbHorizontalAlign.Location = new System.Drawing.Point(408, 9);
            this.cmbHorizontalAlign.Name = "cmbHorizontalAlign";
            this.cmbHorizontalAlign.Size = new System.Drawing.Size(51, 21);
            this.cmbHorizontalAlign.TabIndex = 3;
            this.ttMain.SetToolTip(this.cmbHorizontalAlign, "Alanın Yatay Hizalaması.");
            // 
            // rkArkaplanRengi
            // 
            this.rkArkaplanRengi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rkArkaplanRengi.BackColor = System.Drawing.Color.Black;
            this.rkArkaplanRengi.Location = new System.Drawing.Point(217, 10);
            this.rkArkaplanRengi.Name = "rkArkaplanRengi";
            this.rkArkaplanRengi.SecilenRenk = System.Drawing.Color.White;
            this.rkArkaplanRengi.Size = new System.Drawing.Size(18, 18);
            this.rkArkaplanRengi.TabIndex = 0;
            this.ttMain.SetToolTip(this.rkArkaplanRengi, "Yazının Arkaplan Rengi.\r\n(Değiştirmek için Tıklayın)");
            this.rkArkaplanRengi.RenkDegistiginde += new System.EventHandler<System.Drawing.Color>(this.rkArkaplanRengi_RenkDegistiginde);
            // 
            // rkYaziRengi
            // 
            this.rkYaziRengi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rkYaziRengi.BackColor = System.Drawing.Color.White;
            this.rkYaziRengi.Location = new System.Drawing.Point(193, 10);
            this.rkYaziRengi.Name = "rkYaziRengi";
            this.rkYaziRengi.SecilenRenk = System.Drawing.Color.Black;
            this.rkYaziRengi.Size = new System.Drawing.Size(18, 18);
            this.rkYaziRengi.TabIndex = 0;
            this.ttMain.SetToolTip(this.rkYaziRengi, "Yazının Kendi Rengi.\r\n(Değiştirmek için Tıklayın)");
            this.rkYaziRengi.RenkDegistiginde += new System.EventHandler<System.Drawing.Color>(this.rkRenk_RenkDegistiginde);
            // 
            // lblYaziTipi
            // 
            this.lblYaziTipi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblYaziTipi.BackColor = System.Drawing.Color.White;
            this.lblYaziTipi.ForeColor = System.Drawing.Color.Black;
            this.lblYaziTipi.Location = new System.Drawing.Point(4, 0);
            this.lblYaziTipi.Name = "lblYaziTipi";
            this.lblYaziTipi.Size = new System.Drawing.Size(183, 36);
            this.lblYaziTipi.TabIndex = 1;
            this.lblYaziTipi.Text = "Yazı Tipi";
            this.lblYaziTipi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttMain.SetToolTip(this.lblYaziTipi, resources.GetString("lblYaziTipi.ToolTip"));
            this.lblYaziTipi.FontChanged += new System.EventHandler(this.lblYaziTipi_FontChanged);
            this.lblYaziTipi.Click += new System.EventHandler(this.lblYaziTipi_Click);
            // 
            // FontKutusu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbHorizontalAlign);
            this.Controls.Add(this.cmbVerticalAlign);
            this.Controls.Add(this.nudGenislik);
            this.Controls.Add(this.nudYukseklik);
            this.Controls.Add(this.lblYaziTipi);
            this.Controls.Add(this.rkArkaplanRengi);
            this.Controls.Add(this.rkYaziRengi);
            this.Name = "FontKutusu";
            this.Size = new System.Drawing.Size(464, 38);
            ((System.ComponentModel.ISupportInitialize)(this.nudYukseklik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGenislik)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RenkKutusu rkYaziRengi;
        private RenkKutusu rkArkaplanRengi;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.NumericUpDown nudYukseklik;
        private System.Windows.Forms.NumericUpDown nudGenislik;
        private System.Windows.Forms.ComboBox cmbVerticalAlign;
        private System.Windows.Forms.ComboBox cmbHorizontalAlign;
        private System.Windows.Forms.Label lblYaziTipi;
    }
}
