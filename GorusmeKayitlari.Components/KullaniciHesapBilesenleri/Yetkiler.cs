using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.MsgBox;
using GorusmeKayitlari.Core.Extensions;

namespace GorusmeKayitlari.Components.KullaniciHesapBilesenleri
{
    public partial class Yetkiler : UserControl
    {
        public Yetkiler()
        {
            InitializeComponent();
        }
        private const string _YetkiYok = "(yok)";
        public List<NesneYetkileri> NesneYetkileri => GetNesneYetkileri();
        public List<DigerYetkiler> DigerYetkiler => GetDigerYetkiler();
        public override string Text { get => GetText(); set => SetText(value); }
        public void YetkileriTemizle()
        {
            Delegates.Tag.Set(txtYetkiler,null);
            SetText(_YetkiYok);
        }

        private List<object> _ListeleriGetir()
        {
            object tag = null;
            Optimizasyon.Delagate(txtYetkiler, () => { tag = txtYetkiler.Tag; });
            List<object> listeler = new List<object>(new object[] { new List<NesneYetkileri>(), new List<DigerYetkiler>() });
            if (tag != null && (tag as List<object>) != null)
            {
                listeler = tag as List<object>;
                List<NesneYetkileri> nesneyetkilistesi = new List<NesneYetkileri>();
                List<DigerYetkiler> digeryetkilistesi = new List<DigerYetkiler>();
                foreach (object obj in listeler)
                {
                    if (obj is List<NesneYetkileri>)
                    {
                        nesneyetkilistesi = obj as List<NesneYetkileri>;
                    }
                    else if (obj is List<DigerYetkiler>)
                    {
                        digeryetkilistesi = obj as List<DigerYetkiler>;
                    }
                }
                listeler = new List<object>(new object[] { nesneyetkilistesi, digeryetkilistesi });
            }
            return listeler;
        }

        private bool _Listeleri_Getir(out List<NesneYetkileri> nesneler, out List<DigerYetkiler> digerYetkiler)
        {
            List<object> yetkiler = _ListeleriGetir();
            List<NesneYetkileri> nesneyetkilistesi = new List<NesneYetkileri>();
            List<DigerYetkiler> digeryetkilistesi = new List<DigerYetkiler>();
            if (yetkiler != null)
            {
                foreach (object obj in yetkiler)
                {
                    if (obj is List<NesneYetkileri>)
                    {
                        nesneyetkilistesi = obj as List<NesneYetkileri>;
                    }
                    else if (obj is List<DigerYetkiler>)
                    {
                        digeryetkilistesi = obj as List<DigerYetkiler>;
                    }
                }
            }
            nesneler = nesneyetkilistesi;
            digerYetkiler = digeryetkilistesi;
            return yetkiler != null;
        }

        private void _TagYetkiEkle<T>(T yetki)
        {
            if (typeof(T).IsEnum)
            {
                if (_Listeleri_Getir(out List<NesneYetkileri> nesneyetkilistesi, out List<DigerYetkiler> digeryetkilistesi))
                {
                    if (yetki is NesneYetkileri)
                    {
                        nesneyetkilistesi.Add(yetki.ToString().ToNesneYetkileri());
                    }
                    else if (yetki is DigerYetkiler)
                    {
                        digeryetkilistesi.Add(yetki.ToString().ToDigerYetkiler());
                    }
                    List<object> yenilisteler = new List<object>(new object[] { nesneyetkilistesi, digeryetkilistesi });
                    Optimizasyon.Delagate(txtYetkiler, () => { txtYetkiler.Tag = yenilisteler; });
                }
            }
        }

        private string GetTextFromTag()
        {
            StringBuilder sb = new StringBuilder();
            if (_Listeleri_Getir(out List<NesneYetkileri> nesneyetkilistesi, out List<DigerYetkiler> digeryetkilistesi))
            {
                if (nesneyetkilistesi.Count == 0 && digeryetkilistesi.Count == 0)
                {
                    return _YetkiYok;
                }
                foreach (NesneYetkileri nyetki in nesneyetkilistesi)
                {
                    string yetkitext = nyetki.ToCustomString();
                    if (!string.IsNullOrEmpty(yetkitext))
                    {
                        sb.Append(yetkitext);
                        sb.Append(", ");
                    }
                }
                foreach (DigerYetkiler dyetki in digeryetkilistesi)
                {
                    string yetkitext = dyetki.ToCustomString();
                    if (!string.IsNullOrEmpty(yetkitext))
                    {
                        sb.Append(yetkitext);
                        sb.Append(", ");
                    }
                }
                sb.Remove(sb.Length - 2, 2);
            }
            return sb.ToString();
        }

        private void _YetkiEkle<T>(List<T> yetkiler)
        {
            if (yetkiler != null)
            {
                if (yetkiler.Count != 0)
                {
                    foreach (T yetki in yetkiler)
                    {
                        string yetkitext = DigerFonksiyonlar._YetkiToString(yetki);
                        if (!string.IsNullOrEmpty(yetkitext))
                        {
                            _TagYetkiEkle(yetki);
                        }
                    }
                    SetText(GetTextFromTag());
                }
            }
        }
        public void YetkiEkle<T>(List<T> yetkiler)
        {
            //Optimizasyon.ArkaplandaCalistir(() =>
            //{
            _YetkiEkle(yetkiler);
            //});
        }
        public void SetText(string yazi)
        {
            Delegates.Text.Set(txtYetkiler, yazi);
        }
        public string GetText()
        {
            return Delegates.Text.Get(txtYetkiler);
        }
        public bool IsClear()
        {
            return (GetText() == _YetkiYok);
        }

        public List<NesneYetkileri> GetNesneYetkileri()
        {
            _Listeleri_Getir(out List<NesneYetkileri> nesneyetkilistesi, out List<DigerYetkiler> digeryetkilistesi);
            return nesneyetkilistesi;
        }
        public List<DigerYetkiler> GetDigerYetkiler()
        {
            _Listeleri_Getir(out List<NesneYetkileri> nesneyetkilistesi, out List<DigerYetkiler> digeryetkilistesi);
            return digeryetkilistesi;
        }

        private void BtnSec_Click(object sender, EventArgs e)
        {
            using (YetkiSec frmYetkiSec = new YetkiSec())
            {
                try
                {
                    frmYetkiSec.SetYetkiler(GetNesneYetkileri());
                    frmYetkiSec.SetYetkiler(GetDigerYetkiler());
                    frmYetkiSec.ShowDialog();
                    if (!frmYetkiSec.IptalEdildi)
                    {
                        YetkileriTemizle();
                        _YetkiEkle(frmYetkiSec.GetYetkiler<NesneYetkileri>());
                        _YetkiEkle(frmYetkiSec.GetYetkiler<DigerYetkiler>());
                    }
                }
                catch (Exception ex) { Logger.Log(ex); MsgBox.Hata(this, "Yetki Seçme Penceresi Görünlülenirken bir hata oluştu!"); throw; }
            }
        }
    }
}
