using GorusmeKayitlari.Core.DisariAktar.Excel;
using GorusmeKayitlari.Core.DisariAktar.Html;
using GorusmeKayitlari.Core.DisariAktar.Pdf;
using System.Windows.Forms;

namespace GorusmeKayitlari.Core.DisariAktar
{
    public class GorusmeAktar
    {
        public GorusmeAktarimTuru Tur { get; }
        public ListView lstGorusmeler { get; set; }
        public ExcelDosyaArgs ExcelArgs { get; set; }
        public HtmlDosyaArgs HtmlArgs { get; set; }
        public PdfDosyaArgs PdfArgs { get; set; }

        public GorusmeAktar( ListView lstGorusmeler, ExcelDosyaArgs ExcelArgs)
        {
            this.Tur =  GorusmeAktarimTuru.Excel;
            this.lstGorusmeler = lstGorusmeler;
            this.ExcelArgs = ExcelArgs;
            this.HtmlArgs = null;
            this.PdfArgs = null;
        }
        public GorusmeAktar(ListView lstGorusmeler, HtmlDosyaArgs HtmlArgs)
        {
            this.Tur = GorusmeAktarimTuru.Html;
            this.lstGorusmeler = lstGorusmeler;
            this.HtmlArgs = HtmlArgs;
            this.ExcelArgs = null;
            this.PdfArgs = null;
        }
        public GorusmeAktar(ListView lstGorusmeler, PdfDosyaArgs PdfArgs)
        {
            this.Tur = GorusmeAktarimTuru.Pdf;
            this.lstGorusmeler = lstGorusmeler;
            this.PdfArgs = PdfArgs;
            this.HtmlArgs = null;
            this.ExcelArgs = null;
        }
    }
}
