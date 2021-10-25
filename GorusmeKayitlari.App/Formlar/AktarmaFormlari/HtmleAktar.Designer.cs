namespace GorusmeKayitlari.Components.ExporterForms
{
    partial class HtmleAktar
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
            this.label1 = new System.Windows.Forms.Label();
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
            this.btnKaydet.Location = new System.Drawing.Point(12, 189);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(441, 42);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "Kaydet";
            this.ttMain.SetToolTip(this.btnKaydet, "Görüşme Kayıtlarını Aktarma İşlemini Başlatmak İçin Tıklayın.");
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // pBoxResim
            // 
            this.pBoxResim.Image = global::GorusmeKayitlari.Resources.DigerResimler.htmlAktar;
            this.pBoxResim.Location = new System.Drawing.Point(182, 0);
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
            this.gBoxIcerik.Controls.Add(this.label1);
            this.gBoxIcerik.Controls.Add(this.txtPath);
            this.gBoxIcerik.Controls.Add(this.btnGozat);
            this.gBoxIcerik.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gBoxIcerik.Location = new System.Drawing.Point(12, 93);
            this.gBoxIcerik.Name = "gBoxIcerik";
            this.gBoxIcerik.Size = new System.Drawing.Size(441, 55);
            this.gBoxIcerik.TabIndex = 4;
            this.gBoxIcerik.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dosya Yolu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(93, 21);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(261, 23);
            this.txtPath.TabIndex = 1;
            this.ttMain.SetToolTip(this.txtPath, "Dosyanın Kaydedileceği Dizin.");
            // 
            // btnGozat
            // 
            this.btnGozat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGozat.Location = new System.Drawing.Point(360, 21);
            this.btnGozat.Name = "btnGozat";
            this.btnGozat.Size = new System.Drawing.Size(75, 23);
            this.btnGozat.TabIndex = 0;
            this.btnGozat.Text = "Gözat";
            this.ttMain.SetToolTip(this.btnGozat, "HTML Dosyasının Kaydedileceği Dizini Seçmek İçin Tıklayın.\r\n");
            this.btnGozat.UseVisualStyleBackColor = true;
            this.btnGozat.Click += new System.EventHandler(this.btnGozat_Click);
            // 
            // yukleniyor1
            // 
            this.yukleniyor1.Location = new System.Drawing.Point(459, 0);
            this.yukleniyor1.Name = "yukleniyor1";
            this.yukleniyor1.Size = new System.Drawing.Size(441, 231);
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
            // HtmleAktar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 243);
            this.Controls.Add(this.yukleniyor1);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.pBoxResim);
            this.Controls.Add(this.gBoxIcerik);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HtmleAktar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Html\'e Aktar";
            ((System.ComponentModel.ISupportInitialize)(this.pBoxResim)).EndInit();
            this.gBoxIcerik.ResumeLayout(false);
            this.gBoxIcerik.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.PictureBox pBoxResim;
        private System.Windows.Forms.GroupBox gBoxIcerik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnGozat;
        private Components.Yukleniyor yukleniyor1;
        private System.Windows.Forms.ToolTip ttMain;
    }
}