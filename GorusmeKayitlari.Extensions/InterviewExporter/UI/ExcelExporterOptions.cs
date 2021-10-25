using System;
using System.Windows.Forms;
using GorusmeKayitlari.Core.MsgBox;

namespace GorusmeKayitlari.Extensions.InterviewExporter.UI
{
    public partial class ExcelExporterOptions : UserControl
    {
        public ExcelExporterOptions()
        {
            InitializeComponent();
            this.Text = "Excel Aktarma Ayarları";
        }

        private void btnExpChange_Click(object sender, EventArgs e)
        {
            using (VarsayilanExcelTema tForm = new VarsayilanExcelTema())
            {
                try { tForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Core.Extensions.Logger.Log(ex); MsgBox.Hata(this, "Varsayılan Excel Dışarı Aktarım Tema Ayarları Penceresi Açılırken bir hata oluştu."); }
            }
        }
    }
}
