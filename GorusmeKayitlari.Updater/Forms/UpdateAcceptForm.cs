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
    /// Kullanıcının güncellemeyi kabul etmesini istemek için form
    /// </summary>
    internal partial class UpdateAcceptForm : Form
    {
        /// <summary>
        /// Programın Güncelleme Bilgileri.
        /// </summary>
        private IUpdatable applicationInfo;
        /// <summary>
        /// update.xml dosyasındaki güncelleme bilgileri.
        /// </summary>
        private AppUpdaterXML updateInfo;
        //private UpdateInfoForm updateInfoForm;

        /// <summary>
        /// Yeni bir UpdateAcceptForm oluşturur.
        /// </summary>
        internal UpdateAcceptForm(IUpdatable applicationInfo, AppUpdaterXML updateInfo)
        {
            InitializeComponent();
            this.applicationInfo = applicationInfo;
            this.updateInfo = updateInfo;
            this.Text = this.applicationInfo.ApplicationName + " - Yeni Güncelleme Var";
            this.lblNewVersion.Text = string.Format("Yeni versiyon: {0}", this.updateInfo.Version.ToString());
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            //if (updateInfoForm == null)
            //{ this.updateInfoForm = new UpdateInfoForm(this.applicationInfo, this.updateInfo); }
            //this.updateInfoForm.ShowDialog(this);
            using (UpdateInfoForm updateInfoForm = new UpdateInfoForm(this.applicationInfo, this.updateInfo))
            {
                updateInfoForm.ShowDialog(this);
            }
        }
    }
}
