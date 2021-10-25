using GorusmeKayitlari.Core.DisariAktar.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorusmeKayitlari.Extensions.InterviewExporter.UI
{
    public partial class VarsayilanExcelTema : Form
    {
        public VarsayilanExcelTema()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            ExcelIcerikTemaConverter._ExcelIcerikTemaToXML(Application.StartupPath + "\\ExcelDefaultTema.gk.xml", "(Varsayılan)", excelTema1._GetThisTheme());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
