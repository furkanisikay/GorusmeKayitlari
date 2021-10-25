using GorusmeKayitlari.Components;

namespace GorusmeKayitlari.App.Formlar.NesneFormlari.SecmeFormlari
{
    partial class KategoriSec
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
            this.liste1 = new GorusmeKayitlari.App.Bilesenler.Liste();
            this.btnIptalOnayla = new GorusmeKayitlari.Components.OnaylaIptal();
            this.pboxResim = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).BeginInit();
            this.SuspendLayout();
            // 
            // liste1
            // 
            this.liste1.Location = new System.Drawing.Point(12, 65);
            this.liste1.Name = "liste1";
            this.liste1.Size = new System.Drawing.Size(360, 299);
            this.liste1.TabIndex = 0;
            this.liste1.KurumSecildiginde += new System.EventHandler<System.Windows.Forms.TreeViewEventArgs>(this.liste1_KurumSecildiginde);
            // 
            // btnIptalOnayla
            // 
            this.btnIptalOnayla.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnIptalOnayla.Location = new System.Drawing.Point(12, 371);
            this.btnIptalOnayla.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnIptalOnayla.Name = "btnIptalOnayla";
            this.btnIptalOnayla.Size = new System.Drawing.Size(360, 40);
            this.btnIptalOnayla.TabIndex = 1;
            this.btnIptalOnayla.Onaylandiginde += new System.EventHandler(this.btnIptalOnayla_Onaylandiginde);
            this.btnIptalOnayla.IptalEdildiginde += new System.EventHandler(this.btnIptalOnayla_IptalEdildiginde);
            // 
            // pboxResim
            // 
            this.pboxResim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxResim.Image = global::GorusmeKayitlari.Resources.NesneResimleri.Kategori_Sec;
            this.pboxResim.Location = new System.Drawing.Point(160, 0);
            this.pboxResim.Name = "pboxResim";
            this.pboxResim.Size = new System.Drawing.Size(64, 64);
            this.pboxResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pboxResim.TabIndex = 13;
            this.pboxResim.TabStop = false;
            // 
            // KategoriSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.Controls.Add(this.pboxResim);
            this.Controls.Add(this.liste1);
            this.Controls.Add(this.btnIptalOnayla);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 450);
            this.Name = "KategoriSec";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kategori Seçin";
            this.Load += new System.EventHandler(this.KategoriSec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private OnaylaIptal btnIptalOnayla;
        private Bilesenler.Liste liste1;
        private System.Windows.Forms.PictureBox pboxResim;
    }
}