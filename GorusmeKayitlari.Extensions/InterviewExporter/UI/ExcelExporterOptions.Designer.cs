namespace GorusmeKayitlari.Extensions.InterviewExporter.UI
{
    partial class ExcelExporterOptions
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
            this.btnExpChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExpChange
            // 
            this.btnExpChange.Location = new System.Drawing.Point(6, 3);
            this.btnExpChange.Name = "btnExpChange";
            this.btnExpChange.Size = new System.Drawing.Size(308, 34);
            this.btnExpChange.TabIndex = 0;
            this.btnExpChange.Text = "Excel Varsayılan Dışarı Aktarma Temasını Değiştir";
            this.btnExpChange.UseVisualStyleBackColor = true;
            this.btnExpChange.Click += new System.EventHandler(this.btnExpChange_Click);
            // 
            // ExcelExporterOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExpChange);
            this.Name = "ExcelExporterOptions";
            this.Size = new System.Drawing.Size(320, 45);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExpChange;
    }
}
