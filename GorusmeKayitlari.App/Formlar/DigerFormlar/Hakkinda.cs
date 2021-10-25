using GorusmeKayitlari.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorusmeKayitlari.App.Formlar.DigerFormlar
{
    public partial class Hakkinda : Form
    {
        public Hakkinda()
        {
            InitializeComponent();
        }

        private void _Gereksinimler()
        {
            Optimizasyon.Delagate(label1, () => { label1.Text = string.Format("© 2016 - {0} Görüşme Kayıtları\nTüm Hakları Saklıdır.", DateTime.Today.Year.ToString()); });
            bool Access = Gereksinimler.GetAccess();
            Delegates.Text.Set(lblAccessSonuc, "Yüklü" + (Access ? "" : " Değil"));
            Delegates.ForeColor.Set(lblAccessSonuc, (Access ? Color.Green : Color.Red));
            bool Excel = Gereksinimler.GetExcel();
            Delegates.Text.Set(lblExcelSonuc, "Yüklü" + (Excel ? "" : " Değil"));
            Delegates.ForeColor.Set(lblExcelSonuc, (Excel ? Color.Green : Color.Red));
            bool DotNET = Gereksinimler.DotNETInstalled();
            Delegates.Text.Set(lblDotNETSonuc, "Yüklü" + (DotNET ? (string.Format("({0})", Gereksinimler.Get45PlusFromRegistry())) : " Değil"));
            Delegates.ForeColor.Set(lblDotNETSonuc, (DotNET ? Color.Green : Color.Red));
        }

        private void Hakkinda_Load(object sender, EventArgs e)
        {
            new Task(() => { _Gereksinimler(); }).RunSynchronously();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
