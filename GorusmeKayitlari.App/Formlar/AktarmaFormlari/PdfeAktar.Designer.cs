namespace GorusmeKayitlari.Components.ExporterForms
{
    partial class PdfeAktar
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
            this.btnKaydet = new System.Windows.Forms.Button();
            this.pBoxResim = new System.Windows.Forms.PictureBox();
            this.gBoxIcerik = new System.Windows.Forms.GroupBox();
            this.chckLogoDosyaYolu = new System.Windows.Forms.CheckBox();
            this.chchTarihEkle = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYazar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBaslik = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLogoDosyasi = new System.Windows.Forms.TextBox();
            this.btnLogoDosyasiGozat = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnGozat = new System.Windows.Forms.Button();
            this.yukleniyor1 = new GorusmeKayitlari.Components.Yukleniyor();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxResim)).BeginInit();
            this.gBoxIcerik.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnKaydet.Location = new System.Drawing.Point(12, 268);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(496, 42);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "Kaydet";
            this.ttMain.SetToolTip(this.btnKaydet, "Görüşme Kayıtlarını Aktarma İşlemini Başlatmak İçin Tıklayın.");
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // pBoxResim
            // 
            this.pBoxResim.Image = global::GorusmeKayitlari.Resources.DigerResimler.pdfAktar;
            this.pBoxResim.Location = new System.Drawing.Point(210, 0);
            this.pBoxResim.Name = "pBoxResim";
            this.pBoxResim.Size = new System.Drawing.Size(100, 87);
            this.pBoxResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxResim.TabIndex = 5;
            this.pBoxResim.TabStop = false;
            // 
            // gBoxIcerik
            // 
            this.gBoxIcerik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxIcerik.Controls.Add(this.chckLogoDosyaYolu);
            this.gBoxIcerik.Controls.Add(this.chchTarihEkle);
            this.gBoxIcerik.Controls.Add(this.label3);
            this.gBoxIcerik.Controls.Add(this.txtYazar);
            this.gBoxIcerik.Controls.Add(this.label2);
            this.gBoxIcerik.Controls.Add(this.txtBaslik);
            this.gBoxIcerik.Controls.Add(this.label1);
            this.gBoxIcerik.Controls.Add(this.txtLogoDosyasi);
            this.gBoxIcerik.Controls.Add(this.btnLogoDosyasiGozat);
            this.gBoxIcerik.Controls.Add(this.txtPath);
            this.gBoxIcerik.Controls.Add(this.btnGozat);
            this.gBoxIcerik.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gBoxIcerik.Location = new System.Drawing.Point(12, 93);
            this.gBoxIcerik.Name = "gBoxIcerik";
            this.gBoxIcerik.Size = new System.Drawing.Size(496, 169);
            this.gBoxIcerik.TabIndex = 4;
            this.gBoxIcerik.TabStop = false;
            // 
            // chckLogoDosyaYolu
            // 
            this.chckLogoDosyaYolu.AutoSize = true;
            this.chckLogoDosyaYolu.Location = new System.Drawing.Point(32, 52);
            this.chckLogoDosyaYolu.Name = "chckLogoDosyaYolu";
            this.chckLogoDosyaYolu.Size = new System.Drawing.Size(96, 19);
            this.chckLogoDosyaYolu.TabIndex = 9;
            this.chckLogoDosyaYolu.Text = "Logo Dosyası";
            this.ttMain.SetToolTip(this.chckLogoDosyaYolu, "PDF dosyasında sol üst kısımda belirtilen logonun görüntülenmesini sağlar.");
            this.chckLogoDosyaYolu.UseVisualStyleBackColor = true;
            this.chckLogoDosyaYolu.CheckedChanged += new System.EventHandler(this.chckDosyaYolu_CheckedChanged);
            // 
            // chchTarihEkle
            // 
            this.chchTarihEkle.AutoSize = true;
            this.chchTarihEkle.Checked = true;
            this.chchTarihEkle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chchTarihEkle.Location = new System.Drawing.Point(134, 137);
            this.chchTarihEkle.Name = "chchTarihEkle";
            this.chchTarihEkle.Size = new System.Drawing.Size(76, 19);
            this.chchTarihEkle.TabIndex = 8;
            this.chchTarihEkle.Text = "Tarih Ekle";
            this.ttMain.SetToolTip(this.chchTarihEkle, "PDF dosyasının sağ üst kısmına tarih ekler.");
            this.chchTarihEkle.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(17, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dosya Yazarı";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtYazar
            // 
            this.txtYazar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYazar.Location = new System.Drawing.Point(134, 108);
            this.txtYazar.Name = "txtYazar";
            this.txtYazar.Size = new System.Drawing.Size(275, 23);
            this.txtYazar.TabIndex = 7;
            this.ttMain.SetToolTip(this.txtYazar, "PDF dosyasının özniteliklerinde görüntülenecek yazar.");
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dosya Başlığı";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBaslik
            // 
            this.txtBaslik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBaslik.Location = new System.Drawing.Point(134, 79);
            this.txtBaslik.Name = "txtBaslik";
            this.txtBaslik.Size = new System.Drawing.Size(275, 23);
            this.txtBaslik.TabIndex = 4;
            this.ttMain.SetToolTip(this.txtBaslik, "PDF dosyasının orta üst kısmında ve özniteliklerinde görüntülenecek başlık.");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dosya Yolu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLogoDosyasi
            // 
            this.txtLogoDosyasi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogoDosyasi.Enabled = false;
            this.txtLogoDosyasi.Location = new System.Drawing.Point(134, 50);
            this.txtLogoDosyasi.Name = "txtLogoDosyasi";
            this.txtLogoDosyasi.ReadOnly = true;
            this.txtLogoDosyasi.Size = new System.Drawing.Size(275, 23);
            this.txtLogoDosyasi.TabIndex = 1;
            this.ttMain.SetToolTip(this.txtLogoDosyasi, "Görüntülenecek logo dosyasının bulunduğu dizin.");
            // 
            // btnLogoDosyasiGozat
            // 
            this.btnLogoDosyasiGozat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogoDosyasiGozat.Enabled = false;
            this.btnLogoDosyasiGozat.Location = new System.Drawing.Point(415, 50);
            this.btnLogoDosyasiGozat.Name = "btnLogoDosyasiGozat";
            this.btnLogoDosyasiGozat.Size = new System.Drawing.Size(75, 23);
            this.btnLogoDosyasiGozat.TabIndex = 0;
            this.btnLogoDosyasiGozat.Text = "Gözat";
            this.ttMain.SetToolTip(this.btnLogoDosyasiGozat, "Logo dosyasının seçmek için tıklayın.");
            this.btnLogoDosyasiGozat.UseVisualStyleBackColor = true;
            this.btnLogoDosyasiGozat.Click += new System.EventHandler(this.btnLogoDosyasiGozat_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(134, 21);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(275, 23);
            this.txtPath.TabIndex = 1;
            this.ttMain.SetToolTip(this.txtPath, "Dosyanın Kaydedileceği Dizin.");
            // 
            // btnGozat
            // 
            this.btnGozat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGozat.Location = new System.Drawing.Point(415, 21);
            this.btnGozat.Name = "btnGozat";
            this.btnGozat.Size = new System.Drawing.Size(75, 23);
            this.btnGozat.TabIndex = 0;
            this.btnGozat.Text = "Gözat";
            this.ttMain.SetToolTip(this.btnGozat, "PDF Dosyasının Kaydedileceği Dizini Seçmek İçin Tıklayın.");
            this.btnGozat.UseVisualStyleBackColor = true;
            this.btnGozat.Click += new System.EventHandler(this.btnGozat_Click);
            // 
            // yukleniyor1
            // 
            this.yukleniyor1.Location = new System.Drawing.Point(514, 0);
            this.yukleniyor1.Name = "yukleniyor1";
            this.yukleniyor1.Size = new System.Drawing.Size(496, 310);
            this.yukleniyor1.TabIndex = 7;
            this.yukleniyor1.Visible = false;
            this.yukleniyor1.Yazi = "Görüşmeler Aktarılıyor...";
            this.yukleniyor1.YaziFontu = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yukleniyor1.YaziGoster = true;
            // 
            // ttMain
            // 
            this.ttMain.IsBalloon = true;
            this.ttMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttMain.ToolTipTitle = "Bilgi";
            // 
            // PdfeAktar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 322);
            this.Controls.Add(this.yukleniyor1);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.pBoxResim);
            this.Controls.Add(this.gBoxIcerik);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PdfeAktar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF\'e Aktar";
            ((System.ComponentModel.ISupportInitialize)(this.pBoxResim)).EndInit();
            this.gBoxIcerik.ResumeLayout(false);
            this.gBoxIcerik.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.PictureBox pBoxResim;
        private System.Windows.Forms.GroupBox gBoxIcerik;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYazar;
        private System.Windows.Forms.TextBox txtBaslik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnGozat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chckLogoDosyaYolu;
        private System.Windows.Forms.CheckBox chchTarihEkle;
        private System.Windows.Forms.TextBox txtLogoDosyasi;
        private System.Windows.Forms.Button btnLogoDosyasiGozat;
        private Components.Yukleniyor yukleniyor1;
        private System.Windows.Forms.ToolTip ttMain;
    }
}