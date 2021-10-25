namespace GorusmeKayitlari.App.Formlar.NesneFormlari
{
    partial class KurumGoster
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
            this.glGorusmeler = new GorusmeKayitlari.App.Bilesenler.GorusmeListe();
            this.btnKrmBilGstr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // glGorusmeler
            // 
            this.glGorusmeler.CmGorusmeler = null;
            this.glGorusmeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glGorusmeler.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.glGorusmeler.KurumListesi = null;
            this.glGorusmeler.Location = new System.Drawing.Point(0, 0);
            this.glGorusmeler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.glGorusmeler.MinimumSize = new System.Drawing.Size(953, 369);
            this.glGorusmeler.Name = "glGorusmeler";
            this.glGorusmeler.Size = new System.Drawing.Size(953, 432);
            this.glGorusmeler.TabIndex = 0;
            this.glGorusmeler.EkleTiklandiginda += new System.EventHandler(this.GlGorusmeler_EkleTiklandiginda);
            this.glGorusmeler.DuzenleTiklandiginda += new System.EventHandler<GorusmeKayitlari.Core.DB.Objects.Gorusme>(this.GlGorusmeler_DuzenleTiklandiginda);
            this.glGorusmeler.SilTiklandiginda += new System.EventHandler<System.Collections.Generic.List<GorusmeKayitlari.Core.DB.Objects.Gorusme>>(this.GlGorusmeler_SilTiklandiginda);
            this.glGorusmeler.GizleTiklandiginda += new System.EventHandler<System.Collections.Generic.List<GorusmeKayitlari.Core.DB.Objects.Gorusme>>(this.GlGorusmeler_GizleTiklandiginda);
            // 
            // btnKrmBilGstr
            // 
            this.btnKrmBilGstr.Location = new System.Drawing.Point(781, 12);
            this.btnKrmBilGstr.Name = "btnKrmBilGstr";
            this.btnKrmBilGstr.Size = new System.Drawing.Size(155, 27);
            this.btnKrmBilGstr.TabIndex = 1;
            this.btnKrmBilGstr.Text = "Kurum Bilgilerini Göster";
            this.btnKrmBilGstr.UseVisualStyleBackColor = true;
            this.btnKrmBilGstr.Visible = false;
            this.btnKrmBilGstr.Click += new System.EventHandler(this.btnKrmBilGstr_Click);
            // 
            // KurumGoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 432);
            this.Controls.Add(this.btnKrmBilGstr);
            this.Controls.Add(this.glGorusmeler);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MinimumSize = new System.Drawing.Size(964, 386);
            this.Name = "KurumGoster";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kurum Göster";
            this.Load += new System.EventHandler(this.KurumGoster_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Bilesenler.GorusmeListe glGorusmeler;
        private System.Windows.Forms.Button btnKrmBilGstr;
    }
}