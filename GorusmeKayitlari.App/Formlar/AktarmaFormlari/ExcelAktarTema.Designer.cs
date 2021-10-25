namespace GorusmeKayitlari.App.AktarmaFormlari
{
    partial class ExcelAktarTema
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
            this.btnDisariAktar = new System.Windows.Forms.Button();
            this.btnIceriAktar = new System.Windows.Forms.Button();
            this.txtTemaAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGeriDon = new System.Windows.Forms.Button();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.excelTema1 = new GorusmeKayitlari.Components.ExcelBilesenleri.ExcelTema();
            this.SuspendLayout();
            // 
            // btnDisariAktar
            // 
            this.btnDisariAktar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisariAktar.Location = new System.Drawing.Point(449, 190);
            this.btnDisariAktar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDisariAktar.Name = "btnDisariAktar";
            this.btnDisariAktar.Size = new System.Drawing.Size(157, 33);
            this.btnDisariAktar.TabIndex = 11;
            this.btnDisariAktar.Text = "Temayı Dışa Aktar";
            this.ttMain.SetToolTip(this.btnDisariAktar, "Tema İçeriğini, Tema Dosyasına Kaydeder.");
            this.btnDisariAktar.UseVisualStyleBackColor = true;
            this.btnDisariAktar.Click += new System.EventHandler(this.btnDisariAktar_Click);
            // 
            // btnIceriAktar
            // 
            this.btnIceriAktar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIceriAktar.Location = new System.Drawing.Point(286, 190);
            this.btnIceriAktar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIceriAktar.Name = "btnIceriAktar";
            this.btnIceriAktar.Size = new System.Drawing.Size(157, 33);
            this.btnIceriAktar.TabIndex = 11;
            this.btnIceriAktar.Text = "Tema İçeri Aktar";
            this.ttMain.SetToolTip(this.btnIceriAktar, "Tema Dosyasından, Tema İçeriğini Yükler.");
            this.btnIceriAktar.UseVisualStyleBackColor = true;
            this.btnIceriAktar.Click += new System.EventHandler(this.btnIceriAktar_Click);
            // 
            // txtTemaAdi
            // 
            this.txtTemaAdi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemaAdi.Location = new System.Drawing.Point(126, 11);
            this.txtTemaAdi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTemaAdi.Name = "txtTemaAdi";
            this.txtTemaAdi.Size = new System.Drawing.Size(480, 22);
            this.txtTemaAdi.TabIndex = 12;
            this.ttMain.SetToolTip(this.txtTemaAdi, "Temanın, Aktarım Formunda Görneceği İsim(isteğe bağlı)");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tema Adı";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGeriDon
            // 
            this.btnGeriDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGeriDon.Location = new System.Drawing.Point(12, 190);
            this.btnGeriDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGeriDon.Name = "btnGeriDon";
            this.btnGeriDon.Size = new System.Drawing.Size(108, 33);
            this.btnGeriDon.TabIndex = 11;
            this.btnGeriDon.Text = "Geri Don";
            this.ttMain.SetToolTip(this.btnGeriDon, "Aktarım Formuna Geri Dönmek İçin Tıklayın.");
            this.btnGeriDon.UseVisualStyleBackColor = true;
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            // 
            // ttMain
            // 
            this.ttMain.IsBalloon = true;
            this.ttMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttMain.ToolTipTitle = "Bilgi";
            // 
            // excelTema1
            // 
            this.excelTema1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.excelTema1.Location = new System.Drawing.Point(9, 42);
            this.excelTema1.Margin = new System.Windows.Forms.Padding(10);
            this.excelTema1.Name = "excelTema1";
            this.excelTema1.Size = new System.Drawing.Size(600, 142);
            this.excelTema1.TabIndex = 13;
            // 
            // ExcelAktarTema
            // 
            this.AcceptButton = this.btnGeriDon;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 235);
            this.Controls.Add(this.excelTema1);
            this.Controls.Add(this.txtTemaAdi);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.btnIceriAktar);
            this.Controls.Add(this.btnDisariAktar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExcelAktarTema";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel İçerik Temasını Degiştir";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDisariAktar;
        private System.Windows.Forms.Button btnIceriAktar;
        private System.Windows.Forms.TextBox txtTemaAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGeriDon;
        private System.Windows.Forms.ToolTip ttMain;
        private Components.ExcelBilesenleri.ExcelTema excelTema1;
    }
}