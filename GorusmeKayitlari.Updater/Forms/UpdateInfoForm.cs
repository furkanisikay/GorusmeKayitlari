using GorusmeKayitlari.Updater.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorusmeKayitlari.Updater.Forms
{
    /// <summary>
    /// Güncelleme ile ilgili ayrıntıları göstermek için.
    /// </summary>
    internal partial class UpdateInfoForm : Form
    {
        /// <summary>
        /// Yeni bir UpdateInfoForm oluşturur.
        /// </summary>
        internal UpdateInfoForm(IUpdatable applicationInfo, AppUpdaterXML updateInfo)
        {
            InitializeComponent();

            //Simge null değilse simgeyi ayarla.
            if (applicationInfo.ApplicationIcon != null)
            {
                this.Icon = applicationInfo.ApplicationIcon;
            }

            //Formu Doldur.
            this.Text = applicationInfo.ApplicationName + " - Güncelleme Bilgisi";
            this.lblVersions.Text = string.Format("Geçerli Versiyon: {0}\nGüncel Versiyon: {1}", applicationInfo.ApplicationAssembly.GetName().Version.ToString(), updateInfo.Version.ToString());
            this.txtDecription.Text = updateInfo.Description;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDecription_KeyDown(object sender, KeyEventArgs e)
        {
            //Sadece Control-C'nin metni kopyalamasına izin ver
            if (!(e.Control && e.KeyCode == Keys.C))
            { e.SuppressKeyPress = true; }
        }
    }
}
