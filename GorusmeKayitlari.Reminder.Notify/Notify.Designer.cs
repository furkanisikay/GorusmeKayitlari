namespace GorusmeKayitlari.Reminder.Notify
{
    partial class Notify
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

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notify));
            this.pboxHatirlatma = new System.Windows.Forms.PictureBox();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.btnTamam = new System.Windows.Forms.Button();
            this.lblMetin = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDahaSonra = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmsDahaSonra = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dkErteleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dkErteleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dkErteleToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dkErteleToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.saatErteleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.günErteleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.haftaErteleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayErteleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yılErteleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrKaymaEffct = new System.Windows.Forms.Timer(this.components);
            this.tmrOtoKapat = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pboxHatirlatma)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.cmsDahaSonra.SuspendLayout();
            this.SuspendLayout();
            // 
            // pboxHatirlatma
            // 
            this.pboxHatirlatma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pboxHatirlatma.Dock = System.Windows.Forms.DockStyle.Left;
            this.pboxHatirlatma.Image = ((System.Drawing.Image)(resources.GetObject("pboxHatirlatma.Image")));
            this.pboxHatirlatma.Location = new System.Drawing.Point(0, 0);
            this.pboxHatirlatma.Name = "pboxHatirlatma";
            this.pboxHatirlatma.Size = new System.Drawing.Size(71, 68);
            this.pboxHatirlatma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pboxHatirlatma.TabIndex = 0;
            this.pboxHatirlatma.TabStop = false;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblBaslik.Location = new System.Drawing.Point(77, 20);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(195, 29);
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.Text = "Hatırlatmanız var!";
            // 
            // btnTamam
            // 
            this.btnTamam.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTamam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnTamam.Location = new System.Drawing.Point(0, 0);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(261, 36);
            this.btnTamam.TabIndex = 3;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.UseVisualStyleBackColor = true;
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // lblMetin
            // 
            this.lblMetin.AutoEllipsis = true;
            this.lblMetin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMetin.Location = new System.Drawing.Point(0, 68);
            this.lblMetin.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.lblMetin.MaximumSize = new System.Drawing.Size(288, 136);
            this.lblMetin.Name = "lblMetin";
            this.lblMetin.Size = new System.Drawing.Size(288, 136);
            this.lblMetin.TabIndex = 4;
            this.lblMetin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pboxHatirlatma);
            this.panel1.Controls.Add(this.lblBaslik);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 68);
            this.panel1.TabIndex = 5;
            // 
            // btnDahaSonra
            // 
            this.btnDahaSonra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDahaSonra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnDahaSonra.Location = new System.Drawing.Point(261, 0);
            this.btnDahaSonra.Name = "btnDahaSonra";
            this.btnDahaSonra.Size = new System.Drawing.Size(30, 36);
            this.btnDahaSonra.TabIndex = 6;
            this.btnDahaSonra.Text = "<";
            this.btnDahaSonra.UseVisualStyleBackColor = true;
            this.btnDahaSonra.Click += new System.EventHandler(this.btnDahaSonra_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDahaSonra);
            this.panel2.Controls.Add(this.btnTamam);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 36);
            this.panel2.TabIndex = 7;
            // 
            // cmsDahaSonra
            // 
            this.cmsDahaSonra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dkErteleToolStripMenuItem,
            this.dkErteleToolStripMenuItem1,
            this.dkErteleToolStripMenuItem2,
            this.dkErteleToolStripMenuItem3,
            this.saatErteleToolStripMenuItem,
            this.günErteleToolStripMenuItem,
            this.haftaErteleToolStripMenuItem,
            this.ayErteleToolStripMenuItem,
            this.yılErteleToolStripMenuItem});
            this.cmsDahaSonra.Name = "cmsDahaSonra";
            this.cmsDahaSonra.Size = new System.Drawing.Size(143, 202);
            // 
            // dkErteleToolStripMenuItem
            // 
            this.dkErteleToolStripMenuItem.Name = "dkErteleToolStripMenuItem";
            this.dkErteleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.dkErteleToolStripMenuItem.Tag = "300";
            this.dkErteleToolStripMenuItem.Text = "5 dk ertele";
            this.dkErteleToolStripMenuItem.ToolTipText = "Hatırlatmayı 5 dk erteler.";
            this.dkErteleToolStripMenuItem.Click += new System.EventHandler(this.cmsDahaSonra_ItemClicked);
            // 
            // dkErteleToolStripMenuItem1
            // 
            this.dkErteleToolStripMenuItem1.Name = "dkErteleToolStripMenuItem1";
            this.dkErteleToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.dkErteleToolStripMenuItem1.Tag = "600";
            this.dkErteleToolStripMenuItem1.Text = "10 dk ertele";
            this.dkErteleToolStripMenuItem1.ToolTipText = "Hatırlatmayı 10 dk erteler.";
            this.dkErteleToolStripMenuItem1.Click += new System.EventHandler(this.cmsDahaSonra_ItemClicked);
            // 
            // dkErteleToolStripMenuItem2
            // 
            this.dkErteleToolStripMenuItem2.Name = "dkErteleToolStripMenuItem2";
            this.dkErteleToolStripMenuItem2.Size = new System.Drawing.Size(142, 22);
            this.dkErteleToolStripMenuItem2.Tag = "900";
            this.dkErteleToolStripMenuItem2.Text = "15 dk ertele";
            this.dkErteleToolStripMenuItem2.ToolTipText = "Hatırlatmayı 15 dk erteler.";
            this.dkErteleToolStripMenuItem2.Click += new System.EventHandler(this.cmsDahaSonra_ItemClicked);
            // 
            // dkErteleToolStripMenuItem3
            // 
            this.dkErteleToolStripMenuItem3.Name = "dkErteleToolStripMenuItem3";
            this.dkErteleToolStripMenuItem3.Size = new System.Drawing.Size(142, 22);
            this.dkErteleToolStripMenuItem3.Tag = "1800";
            this.dkErteleToolStripMenuItem3.Text = "30 dk ertele";
            this.dkErteleToolStripMenuItem3.ToolTipText = "Hatırlatmayı 30 dk erteler.";
            this.dkErteleToolStripMenuItem3.Click += new System.EventHandler(this.cmsDahaSonra_ItemClicked);
            // 
            // saatErteleToolStripMenuItem
            // 
            this.saatErteleToolStripMenuItem.Name = "saatErteleToolStripMenuItem";
            this.saatErteleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.saatErteleToolStripMenuItem.Tag = "3600";
            this.saatErteleToolStripMenuItem.Text = "1 saat ertele";
            this.saatErteleToolStripMenuItem.ToolTipText = "Hatırlatmayı 1 saat erteler.";
            this.saatErteleToolStripMenuItem.Click += new System.EventHandler(this.cmsDahaSonra_ItemClicked);
            // 
            // günErteleToolStripMenuItem
            // 
            this.günErteleToolStripMenuItem.Name = "günErteleToolStripMenuItem";
            this.günErteleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.günErteleToolStripMenuItem.Tag = "86400";
            this.günErteleToolStripMenuItem.Text = "1 gün ertele";
            this.günErteleToolStripMenuItem.ToolTipText = "Hatırlatmayı 1 gün erteler.";
            this.günErteleToolStripMenuItem.Click += new System.EventHandler(this.cmsDahaSonra_ItemClicked);
            // 
            // haftaErteleToolStripMenuItem
            // 
            this.haftaErteleToolStripMenuItem.Name = "haftaErteleToolStripMenuItem";
            this.haftaErteleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.haftaErteleToolStripMenuItem.Tag = "604800";
            this.haftaErteleToolStripMenuItem.Text = "1 hafta ertele";
            this.haftaErteleToolStripMenuItem.ToolTipText = "Hatırlatmayı 1 hafta erteler.";
            this.haftaErteleToolStripMenuItem.Click += new System.EventHandler(this.cmsDahaSonra_ItemClicked);
            // 
            // ayErteleToolStripMenuItem
            // 
            this.ayErteleToolStripMenuItem.Name = "ayErteleToolStripMenuItem";
            this.ayErteleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.ayErteleToolStripMenuItem.Tag = "2592000";
            this.ayErteleToolStripMenuItem.Text = "1 ay ertele";
            this.ayErteleToolStripMenuItem.ToolTipText = "Hatırlatmayı 30 gün erteler.";
            this.ayErteleToolStripMenuItem.Click += new System.EventHandler(this.cmsDahaSonra_ItemClicked);
            // 
            // yılErteleToolStripMenuItem
            // 
            this.yılErteleToolStripMenuItem.Name = "yılErteleToolStripMenuItem";
            this.yılErteleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.yılErteleToolStripMenuItem.Tag = "31536000";
            this.yılErteleToolStripMenuItem.Text = "1 yıl ertele";
            this.yılErteleToolStripMenuItem.ToolTipText = "Hatırlatmayı 365 gün erteler.";
            this.yılErteleToolStripMenuItem.Click += new System.EventHandler(this.cmsDahaSonra_ItemClicked);
            // 
            // tmrKaymaEffct
            // 
            this.tmrKaymaEffct.Interval = 5;
            this.tmrKaymaEffct.Tick += new System.EventHandler(this.tmrKaymaEffct_Tick);
            // 
            // tmrOtoKapat
            // 
            this.tmrOtoKapat.Interval = 1000;
            this.tmrOtoKapat.Tick += new System.EventHandler(this.tmrOtoKapat_Tick);
            // 
            // Notify
            // 
            this.AcceptButton = this.btnTamam;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 235);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblMetin);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Notify";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Hatırlatma";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Notify_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pboxHatirlatma)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.cmsDahaSonra.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxHatirlatma;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Button btnTamam;
        private System.Windows.Forms.Label lblMetin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDahaSonra;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip cmsDahaSonra;
        private System.Windows.Forms.ToolStripMenuItem dkErteleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dkErteleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dkErteleToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem dkErteleToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem saatErteleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem günErteleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem haftaErteleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayErteleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yılErteleToolStripMenuItem;
        private System.Windows.Forms.Timer tmrKaymaEffct;
        private System.Windows.Forms.Timer tmrOtoKapat;
    }
}

