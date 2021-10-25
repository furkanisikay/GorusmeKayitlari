namespace GorusmeKayitlari.App.Bilesenler
{
    partial class TarihFiltreleme
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
            this.cmbTarihler = new System.Windows.Forms.ComboBox();
            this.btnFiltrele = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblile = new System.Windows.Forms.Label();
            this.lblOzelTarih = new System.Windows.Forms.Label();
            this.dtpTarih2 = new System.Windows.Forms.DateTimePicker();
            this.dtpTarih1 = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTarihler
            // 
            this.cmbTarihler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTarihler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarihler.FormattingEnabled = true;
            this.cmbTarihler.Items.AddRange(new object[] {
            "Bugün",
            "Bu Hafta",
            "Bu Ay",
            "Bu Yıl",
            "Özel"});
            this.cmbTarihler.Location = new System.Drawing.Point(0, 1);
            this.cmbTarihler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTarihler.Name = "cmbTarihler";
            this.cmbTarihler.Size = new System.Drawing.Size(113, 25);
            this.cmbTarihler.TabIndex = 5;
            this.cmbTarihler.SelectedIndexChanged += new System.EventHandler(this.CmbTarihler_SelectedIndexChanged);
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltrele.Location = new System.Drawing.Point(688, 0);
            this.btnFiltrele.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(69, 27);
            this.btnFiltrele.TabIndex = 4;
            this.btnFiltrele.Text = "Filtrele";
            this.btnFiltrele.UseVisualStyleBackColor = true;
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblile);
            this.panel1.Controls.Add(this.lblOzelTarih);
            this.panel1.Controls.Add(this.dtpTarih2);
            this.panel1.Controls.Add(this.dtpTarih1);
            this.panel1.Location = new System.Drawing.Point(119, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(563, 24);
            this.panel1.TabIndex = 6;
            // 
            // lblile
            // 
            this.lblile.AutoSize = true;
            this.lblile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblile.Location = new System.Drawing.Point(221, 2);
            this.lblile.Name = "lblile";
            this.lblile.Size = new System.Drawing.Size(15, 20);
            this.lblile.TabIndex = 3;
            this.lblile.Text = "-";
            this.lblile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblOzelTarih
            // 
            this.lblOzelTarih.Location = new System.Drawing.Point(453, 0);
            this.lblOzelTarih.Name = "lblOzelTarih";
            this.lblOzelTarih.Size = new System.Drawing.Size(107, 24);
            this.lblOzelTarih.TabIndex = 3;
            this.lblOzelTarih.Text = "Tarihleri Arası";
            this.lblOzelTarih.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTarih2
            // 
            this.dtpTarih2.Location = new System.Drawing.Point(244, 0);
            this.dtpTarih2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTarih2.Name = "dtpTarih2";
            this.dtpTarih2.Size = new System.Drawing.Size(201, 24);
            this.dtpTarih2.TabIndex = 2;
            // 
            // dtpTarih1
            // 
            this.dtpTarih1.Location = new System.Drawing.Point(0, 0);
            this.dtpTarih1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTarih1.Name = "dtpTarih1";
            this.dtpTarih1.Size = new System.Drawing.Size(212, 24);
            this.dtpTarih1.TabIndex = 2;
            // 
            // TarihFiltreleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbTarihler);
            this.Controls.Add(this.btnFiltrele);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "TarihFiltreleme";
            this.Size = new System.Drawing.Size(757, 27);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTarihler;
        private System.Windows.Forms.Button btnFiltrele;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblile;
        private System.Windows.Forms.Label lblOzelTarih;
        private System.Windows.Forms.DateTimePicker dtpTarih2;
        private System.Windows.Forms.DateTimePicker dtpTarih1;
    }
}
