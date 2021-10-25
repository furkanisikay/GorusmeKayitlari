namespace GorusmeKayitlari.Components.KullaniciHesapBilesenleri
{
    partial class YetkiSec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YetkiSec));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.onaylaIptal1 = new GorusmeKayitlari.Components.OnaylaIptal();
            this.cmsYetkiler = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnTumunuSec = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSecilenleriTemizle = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsYetkiler.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.ContextMenuStrip = this.cmsYetkiler;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(269, 332);
            this.treeView1.TabIndex = 0;
            // 
            // onaylaIptal1
            // 
            this.onaylaIptal1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.onaylaIptal1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.onaylaIptal1.Location = new System.Drawing.Point(0, 332);
            this.onaylaIptal1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.onaylaIptal1.Name = "onaylaIptal1";
            this.onaylaIptal1.Size = new System.Drawing.Size(269, 35);
            this.onaylaIptal1.TabIndex = 1;
            this.onaylaIptal1.Onaylandiginde += new System.EventHandler(this.OnaylaIptal1_Onaylandiginde);
            this.onaylaIptal1.IptalEdildiginde += new System.EventHandler(this.OnaylaIptal1_IptalEdildiginde);
            // 
            // cmsYetkiler
            // 
            this.cmsYetkiler.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTumunuSec,
            this.btnSecilenleriTemizle});
            this.cmsYetkiler.Name = "cmsYetkiler";
            this.cmsYetkiler.Size = new System.Drawing.Size(171, 48);
            // 
            // btnTumunuSec
            // 
            this.btnTumunuSec.Image = ((System.Drawing.Image)(resources.GetObject("btnTumunuSec.Image")));
            this.btnTumunuSec.Name = "btnTumunuSec";
            this.btnTumunuSec.Size = new System.Drawing.Size(170, 22);
            this.btnTumunuSec.Text = "Tümünü Seç";
            this.btnTumunuSec.Click += new System.EventHandler(this.BtnTumunuSec_Click);
            // 
            // btnSecilenleriTemizle
            // 
            this.btnSecilenleriTemizle.Image = ((System.Drawing.Image)(resources.GetObject("btnSecilenleriTemizle.Image")));
            this.btnSecilenleriTemizle.Name = "btnSecilenleriTemizle";
            this.btnSecilenleriTemizle.Size = new System.Drawing.Size(170, 22);
            this.btnSecilenleriTemizle.Text = "Seçilenleri Temizle";
            this.btnSecilenleriTemizle.Click += new System.EventHandler(this.btnSecilenleriTemizle_Click);
            // 
            // YetkiSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 367);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.onaylaIptal1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "YetkiSec";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yetki Seçin";
            this.Load += new System.EventHandler(this.YetkiSec_Load);
            this.cmsYetkiler.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private OnaylaIptal onaylaIptal1;
        private System.Windows.Forms.ContextMenuStrip cmsYetkiler;
        private System.Windows.Forms.ToolStripMenuItem btnTumunuSec;
        private System.Windows.Forms.ToolStripMenuItem btnSecilenleriTemizle;
    }
}