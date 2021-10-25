using System;
using System.ComponentModel;
using System.Windows.Forms;
using GorusmeKayitlari.Core;

namespace GorusmeKayitlari.Components
{
    [DefaultEvent("Onaylandiginde")]
    public partial class OnaylaIptal : UserControl
    {
        public OnaylaIptal()
        {
            InitializeComponent();
        }
        [Description("Onayla Butonuna Tıklandığında Aktifleşir."),Category("Action")]
        public event EventHandler Onaylandiginde;
        [Description("İptal Butonuna Tıklandığında Aktifleşir."), Category("Action")]
        public event EventHandler IptalEdildiginde;

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if(Onaylandiginde != null)
            {
                Optimizasyon.Delagate(btnOnayla,()=> { btnOnayla.Enabled = false; });
                Onaylandiginde(sender, e);
                Optimizasyon.Delagate(btnOnayla,()=> { btnOnayla.Enabled = true; });
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            if (IptalEdildiginde != null)
            {
                Optimizasyon.Delagate(btnIptal, () => { btnIptal.Enabled = false; });
                IptalEdildiginde(sender, e);
                Optimizasyon.Delagate(btnIptal, () => { btnIptal.Enabled = true; });
            }
        }

        private void OnaylaIptal_FontChanged(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.Font = this.Font;
            this.btnOnayla.Font = this.tableLayoutPanel1.Font;
            this.btnIptal.Font = this.tableLayoutPanel1.Font;
        }
    }
}
