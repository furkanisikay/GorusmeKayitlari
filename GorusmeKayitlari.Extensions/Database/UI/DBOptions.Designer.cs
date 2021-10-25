namespace GorusmeKayitlari.Extensions.Database.UI
{
    partial class DBOptions
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDBAd = new System.Windows.Forms.TextBox();
            this.txtDBFolder = new System.Windows.Forms.TextBox();
            this.btnGozat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Veritabanı dosyasının adı :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Veritabanı klasörü :";
            // 
            // txtDBAd
            // 
            this.txtDBAd.Location = new System.Drawing.Point(3, 61);
            this.txtDBAd.Name = "txtDBAd";
            this.txtDBAd.ReadOnly = true;
            this.txtDBAd.Size = new System.Drawing.Size(314, 20);
            this.txtDBAd.TabIndex = 2;
            // 
            // txtDBFolder
            // 
            this.txtDBFolder.Location = new System.Drawing.Point(3, 22);
            this.txtDBFolder.Name = "txtDBFolder";
            this.txtDBFolder.ReadOnly = true;
            this.txtDBFolder.Size = new System.Drawing.Size(314, 20);
            this.txtDBFolder.TabIndex = 3;
            // 
            // btnGozat
            // 
            this.btnGozat.Location = new System.Drawing.Point(3, 87);
            this.btnGozat.Name = "btnGozat";
            this.btnGozat.Size = new System.Drawing.Size(99, 26);
            this.btnGozat.TabIndex = 6;
            this.btnGozat.Text = "Gözat";
            this.btnGozat.UseVisualStyleBackColor = true;
            this.btnGozat.Click += new System.EventHandler(this.btnGozat_Click);
            // 
            // DBOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGozat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDBAd);
            this.Controls.Add(this.txtDBFolder);
            this.Name = "DBOptions";
            this.Size = new System.Drawing.Size(320, 118);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDBAd;
        private System.Windows.Forms.TextBox txtDBFolder;
        private System.Windows.Forms.Button btnGozat;
    }
}
