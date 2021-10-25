namespace GorusmeKayitlari.Components.ExporterForms
{
    partial class ExceleAktar
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
            this.gBoxIcerik = new System.Windows.Forms.GroupBox();
            this.chckYazmaSifresi = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIcerikTemasi = new System.Windows.Forms.TextBox();
            this.txtYazmaSifresi = new System.Windows.Forms.TextBox();
            this.chckAcmaSifresi = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAcmaSifresi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTemaDegistir = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnGozat = new System.Windows.Forms.Button();
            this.pBoxResim = new System.Windows.Forms.PictureBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.yukleniyor1 = new GorusmeKayitlari.Components.Yukleniyor();
            this.gBoxIcerik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxResim)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxIcerik
            // 
            this.gBoxIcerik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxIcerik.Controls.Add(this.chckYazmaSifresi);
            this.gBoxIcerik.Controls.Add(this.label4);
            this.gBoxIcerik.Controls.Add(this.label3);
            this.gBoxIcerik.Controls.Add(this.txtIcerikTemasi);
            this.gBoxIcerik.Controls.Add(this.txtYazmaSifresi);
            this.gBoxIcerik.Controls.Add(this.chckAcmaSifresi);
            this.gBoxIcerik.Controls.Add(this.label2);
            this.gBoxIcerik.Controls.Add(this.txtAcmaSifresi);
            this.gBoxIcerik.Controls.Add(this.label1);
            this.gBoxIcerik.Controls.Add(this.btnTemaDegistir);
            this.gBoxIcerik.Controls.Add(this.txtPath);
            this.gBoxIcerik.Controls.Add(this.btnGozat);
            this.gBoxIcerik.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gBoxIcerik.Location = new System.Drawing.Point(12, 93);
            this.gBoxIcerik.Name = "gBoxIcerik";
            this.gBoxIcerik.Size = new System.Drawing.Size(446, 134);
            this.gBoxIcerik.TabIndex = 1;
            this.gBoxIcerik.TabStop = false;
            // 
            // chckYazmaSifresi
            // 
            this.chckYazmaSifresi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chckYazmaSifresi.AutoSize = true;
            this.chckYazmaSifresi.Location = new System.Drawing.Point(365, 77);
            this.chckYazmaSifresi.Name = "chckYazmaSifresi";
            this.chckYazmaSifresi.Size = new System.Drawing.Size(60, 19);
            this.chckYazmaSifresi.TabIndex = 8;
            this.chckYazmaSifresi.Text = "Göster";
            this.ttMain.SetToolTip(this.chckYazmaSifresi, "Dosya Yazma Şifresini Görünür Yapar.");
            this.chckYazmaSifresi.UseVisualStyleBackColor = true;
            this.chckYazmaSifresi.CheckedChanged += new System.EventHandler(this.chckYazmaSifresi_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Dosya İçerik Teması";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dosya Yazma Şifresi";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIcerikTemasi
            // 
            this.txtIcerikTemasi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIcerikTemasi.Location = new System.Drawing.Point(123, 99);
            this.txtIcerikTemasi.MaxLength = 15;
            this.txtIcerikTemasi.Name = "txtIcerikTemasi";
            this.txtIcerikTemasi.ReadOnly = true;
            this.txtIcerikTemasi.Size = new System.Drawing.Size(236, 23);
            this.txtIcerikTemasi.TabIndex = 7;
            this.txtIcerikTemasi.Text = "(Varsayılan)";
            this.ttMain.SetToolTip(this.txtIcerikTemasi, "Dosyanın Excele Aktarılırken Uygulanacağı Tema");
            // 
            // txtYazmaSifresi
            // 
            this.txtYazmaSifresi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYazmaSifresi.Location = new System.Drawing.Point(123, 73);
            this.txtYazmaSifresi.MaxLength = 15;
            this.txtYazmaSifresi.Name = "txtYazmaSifresi";
            this.txtYazmaSifresi.Size = new System.Drawing.Size(236, 23);
            this.txtYazmaSifresi.TabIndex = 7;
            this.ttMain.SetToolTip(this.txtYazmaSifresi, "Dosyanın İçeriği Değiştirileceğinde Sorulacak Şifre.(isteğe bağlı)");
            this.txtYazmaSifresi.UseSystemPasswordChar = true;
            // 
            // chckAcmaSifresi
            // 
            this.chckAcmaSifresi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chckAcmaSifresi.AutoSize = true;
            this.chckAcmaSifresi.Location = new System.Drawing.Point(365, 51);
            this.chckAcmaSifresi.Name = "chckAcmaSifresi";
            this.chckAcmaSifresi.Size = new System.Drawing.Size(60, 19);
            this.chckAcmaSifresi.TabIndex = 5;
            this.chckAcmaSifresi.Text = "Göster";
            this.ttMain.SetToolTip(this.chckAcmaSifresi, "Dosya Açma Şifresini Görünür Yapar.");
            this.chckAcmaSifresi.UseVisualStyleBackColor = true;
            this.chckAcmaSifresi.CheckedChanged += new System.EventHandler(this.chckAcmaSifresi_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dosya Açma Şifresi";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAcmaSifresi
            // 
            this.txtAcmaSifresi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcmaSifresi.Location = new System.Drawing.Point(123, 47);
            this.txtAcmaSifresi.MaxLength = 15;
            this.txtAcmaSifresi.Name = "txtAcmaSifresi";
            this.txtAcmaSifresi.Size = new System.Drawing.Size(236, 23);
            this.txtAcmaSifresi.TabIndex = 4;
            this.ttMain.SetToolTip(this.txtAcmaSifresi, "Dosyanın Açılışında Sorulacak Şifre.(isteğe bağlı)");
            this.txtAcmaSifresi.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dosya Yolu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTemaDegistir
            // 
            this.btnTemaDegistir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemaDegistir.Location = new System.Drawing.Point(365, 97);
            this.btnTemaDegistir.Name = "btnTemaDegistir";
            this.btnTemaDegistir.Size = new System.Drawing.Size(75, 23);
            this.btnTemaDegistir.TabIndex = 0;
            this.btnTemaDegistir.Text = "Değistir";
            this.ttMain.SetToolTip(this.btnTemaDegistir, "Dosya İçeriğinin Temasını Değiştirmek için Tıklayın.");
            this.btnTemaDegistir.UseVisualStyleBackColor = true;
            this.btnTemaDegistir.Click += new System.EventHandler(this.btnTemaDegistir_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(123, 21);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(236, 23);
            this.txtPath.TabIndex = 1;
            this.ttMain.SetToolTip(this.txtPath, "Dosyanın Kaydedileceği Dizin.");
            // 
            // btnGozat
            // 
            this.btnGozat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGozat.Location = new System.Drawing.Point(365, 19);
            this.btnGozat.Name = "btnGozat";
            this.btnGozat.Size = new System.Drawing.Size(75, 23);
            this.btnGozat.TabIndex = 0;
            this.btnGozat.Text = "Gözat";
            this.ttMain.SetToolTip(this.btnGozat, "Excel Dosyasının Kaydedileceği Dizini Seçmek İçin Tıklayın.");
            this.btnGozat.UseVisualStyleBackColor = true;
            this.btnGozat.Click += new System.EventHandler(this.btnGozat_Click);
            // 
            // pBoxResim
            // 
            this.pBoxResim.Image = global::GorusmeKayitlari.Resources.DigerResimler.excelAktar;
            this.pBoxResim.Location = new System.Drawing.Point(185, 0);
            this.pBoxResim.Name = "pBoxResim";
            this.pBoxResim.Size = new System.Drawing.Size(100, 87);
            this.pBoxResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxResim.TabIndex = 2;
            this.pBoxResim.TabStop = false;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnKaydet.Location = new System.Drawing.Point(12, 238);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(440, 42);
            this.btnKaydet.TabIndex = 3;
            this.btnKaydet.Text = "Kaydet";
            this.ttMain.SetToolTip(this.btnKaydet, "Görüşme Kayıtlarını Aktarma İşlemini Başlatmak İçin Tıklayın.");
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // ttMain
            // 
            this.ttMain.IsBalloon = true;
            this.ttMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttMain.ToolTipTitle = "Bilgi";
            // 
            // yukleniyor1
            // 
            this.yukleniyor1.Location = new System.Drawing.Point(464, 0);
            this.yukleniyor1.Name = "yukleniyor1";
            this.yukleniyor1.Size = new System.Drawing.Size(446, 280);
            this.yukleniyor1.TabIndex = 4;
            this.yukleniyor1.Visible = false;
            this.yukleniyor1.Yazi = "Görüşmeler Aktarılıyor...";
            this.yukleniyor1.YaziFontu = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yukleniyor1.YaziGoster = true;
            // 
            // ExceleAktar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 292);
            this.Controls.Add(this.yukleniyor1);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.pBoxResim);
            this.Controls.Add(this.gBoxIcerik);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceleAktar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel\'e Aktar";
            this.gBoxIcerik.ResumeLayout(false);
            this.gBoxIcerik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxResim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gBoxIcerik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnGozat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAcmaSifresi;
        private System.Windows.Forms.CheckBox chckAcmaSifresi;
        private System.Windows.Forms.CheckBox chckYazmaSifresi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYazmaSifresi;
        private System.Windows.Forms.TextBox txtIcerikTemasi;
        private System.Windows.Forms.Button btnTemaDegistir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pBoxResim;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.ToolTip ttMain;
        private Components.Yukleniyor yukleniyor1;
    }
}