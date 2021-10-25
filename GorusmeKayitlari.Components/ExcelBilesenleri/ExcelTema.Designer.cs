namespace GorusmeKayitlari.Components.ExcelBilesenleri
{
    partial class ExcelTema
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
            this.gboxTema = new System.Windows.Forms.GroupBox();
            this.fkIkincilBlok = new GorusmeKayitlari.Components.ExcelBilesenleri.FontKutusu();
            this.fkBirincilBlok = new GorusmeKayitlari.Components.ExcelBilesenleri.FontKutusu();
            this.fkAltBaslik = new GorusmeKayitlari.Components.ExcelBilesenleri.FontKutusu();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.gboxTema.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxTema
            // 
            this.gboxTema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxTema.Controls.Add(this.fkIkincilBlok);
            this.gboxTema.Controls.Add(this.fkBirincilBlok);
            this.gboxTema.Controls.Add(this.fkAltBaslik);
            this.gboxTema.Controls.Add(this.label7);
            this.gboxTema.Controls.Add(this.label6);
            this.gboxTema.Controls.Add(this.label5);
            this.gboxTema.Location = new System.Drawing.Point(3, 2);
            this.gboxTema.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gboxTema.Name = "gboxTema";
            this.gboxTema.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gboxTema.Size = new System.Drawing.Size(594, 138);
            this.gboxTema.TabIndex = 14;
            this.gboxTema.TabStop = false;
            this.gboxTema.Text = "Tema Özellikleri";
            // 
            // fkIkincilBlok
            // 
            this.fkIkincilBlok.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fkIkincilBlok.BlokDikeyHizalama = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
            this.fkIkincilBlok.BlokGenisligi = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.fkIkincilBlok.BlokYatayHizalama = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            this.fkIkincilBlok.BlokYuksekligi = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.fkIkincilBlok.Location = new System.Drawing.Point(114, 96);
            this.fkIkincilBlok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fkIkincilBlok.Name = "fkIkincilBlok";
            this.fkIkincilBlok.Size = new System.Drawing.Size(474, 38);
            this.fkIkincilBlok.TabIndex = 7;
            this.fkIkincilBlok.YaziArkaplanRengi = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.fkIkincilBlok.YaziFontRengi = System.Drawing.Color.White;
            this.fkIkincilBlok.YaziFontu = new System.Drawing.Font("Segoe UI", 10F);
            // 
            // fkBirincilBlok
            // 
            this.fkBirincilBlok.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fkBirincilBlok.BlokDikeyHizalama = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
            this.fkBirincilBlok.BlokGenisligi = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.fkBirincilBlok.BlokYatayHizalama = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            this.fkBirincilBlok.BlokYuksekligi = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.fkBirincilBlok.Location = new System.Drawing.Point(114, 57);
            this.fkBirincilBlok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fkBirincilBlok.Name = "fkBirincilBlok";
            this.fkBirincilBlok.Size = new System.Drawing.Size(474, 38);
            this.fkBirincilBlok.TabIndex = 7;
            this.fkBirincilBlok.YaziArkaplanRengi = System.Drawing.Color.White;
            this.fkBirincilBlok.YaziFontRengi = System.Drawing.Color.Black;
            this.fkBirincilBlok.YaziFontu = new System.Drawing.Font("Segoe UI", 10F);
            // 
            // fkAltBaslik
            // 
            this.fkAltBaslik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fkAltBaslik.BlokDikeyHizalama = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
            this.fkAltBaslik.BlokGenisligi = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.fkAltBaslik.BlokYatayHizalama = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            this.fkAltBaslik.BlokYuksekligi = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.fkAltBaslik.Location = new System.Drawing.Point(114, 19);
            this.fkAltBaslik.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fkAltBaslik.Name = "fkAltBaslik";
            this.fkAltBaslik.Size = new System.Drawing.Size(474, 38);
            this.fkAltBaslik.TabIndex = 7;
            this.fkAltBaslik.YaziArkaplanRengi = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.fkAltBaslik.YaziFontRengi = System.Drawing.Color.White;
            this.fkAltBaslik.YaziFontu = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 38);
            this.label7.TabIndex = 6;
            this.label7.Text = "İkincil Bloklar";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 38);
            this.label6.TabIndex = 6;
            this.label6.Text = "Birincil Bloklar";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 38);
            this.label5.TabIndex = 6;
            this.label5.Text = "Başlık Blokları";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ttMain
            // 
            this.ttMain.IsBalloon = true;
            this.ttMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttMain.ToolTipTitle = "Bilgi";
            // 
            // ExcelTema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gboxTema);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "ExcelTema";
            this.Size = new System.Drawing.Size(600, 142);
            this.gboxTema.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxTema;
        private FontKutusu fkIkincilBlok;
        private FontKutusu fkBirincilBlok;
        private FontKutusu fkAltBaslik;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip ttMain;
    }
}
