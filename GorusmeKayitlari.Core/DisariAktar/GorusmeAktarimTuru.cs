using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorusmeKayitlari.Core.DisariAktar
{
    public enum GorusmeAktarimTuru { None, Excel, Html, Pdf }
    class GorusmeAktarimTuruAraclari
    {
        public static GorusmeAktarimTuru Parse(string aktarimturuyazisi)
        {
            switch (aktarimturuyazisi.ToLower().Trim())
            {
                case "":
                    return GorusmeAktarimTuru.None;
                case "excel":
                    return GorusmeAktarimTuru.Excel;
                case "pdf":
                    return GorusmeAktarimTuru.Pdf;
                case "html":
                    return GorusmeAktarimTuru.Html;
                default:
                    return GorusmeAktarimTuru.None;
            }
        }
        public static string ToString(GorusmeAktarimTuru Tur)
        {
            switch (Tur)
            {
                case GorusmeAktarimTuru.None:
                    return "";
                case GorusmeAktarimTuru.Excel:
                    return "Excel";
                case GorusmeAktarimTuru.Html:
                    return "Html";
                case GorusmeAktarimTuru.Pdf:
                    return "Pdf";
                default:
                    return "";
            }
        }
    }
}
