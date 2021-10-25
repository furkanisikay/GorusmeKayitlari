using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.MsgBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GorusmeKayitlari.Core.DB.Methods;

namespace GorusmeKayitlari.Core
{
    public class DigerFonksiyonlar
    {

        public static DialogResult NesneAyarlandiMesajKutusu(string nesneAdi, IslemButonlariDurumu durum, bool sonuc)
        {
            return MessageBox.Show(string.Format("{0} {1}!", nesneAdi, _DurumaGoreSonucYazisi(durum, sonuc))
               , (sonuc ? MsgBoxBaslikAraclari.BaslikGetir(MsgBoxBaslik.Bilgi) : MsgBoxBaslikAraclari.BaslikGetir(MsgBoxBaslik.Hata))
               , MessageBoxButtons.OK
               , (sonuc ? MessageBoxIcon.Information : MessageBoxIcon.Error));
        }
        private static string _DurumaGoreSonucYazisi(IslemButonlariDurumu durum, bool sonuc)
        {
            return (durum == IslemButonlariDurumu.Ekle ? (sonuc ? "Eklendi" : "Eklenemedi") : (sonuc ? "Güncellendi" : "Güncellenemedi"));
        }

        public static List<ListViewItem> CollectionsToListViewItem(ListView.ListViewItemCollection itemler)
        {
            List<ListViewItem> tmpitemler = new List<ListViewItem>();
            try
            {
                foreach (ListViewItem item in itemler)
                {
                    tmpitemler.Add(item);
                }
            }
            catch (Exception ex) { Logger.Log(ex); tmpitemler = null; }
            return tmpitemler;
        }
        public static string CommandGenerator<T>(string komutbasi, List<T> nesneler, ref List<OleDbParameter> parametreler) where T : IIdliNesne
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                if (nesneler != null && nesneler.Count != 0)
                {
                    foreach (T nesne in nesneler)
                    {
                        string rand = UniqueKey.Generate(8);
                        sb.Append(string.Format("({0} = @{1}) OR ", komutbasi, rand));
                        parametreler.Add(new OleDbParameter("@" + rand, nesne.Id));
                    }
                    //fazla eklenen ' OR ' yazısını silmek için
                    sb.Remove(sb.Length - " OR ".Length, " OR ".Length);
                    return sb.ToString();
                }
                else { return string.Empty; }
            }
            catch (Exception ex) { Logger.Log(ex); return string.Empty; }
        }
        public static string CommandGenerator(List<Kurum> Kurumlar, List<Yetkili> Yetkililer, List<Kullanici> Kullanicilar, DateTime baslangicTarihi, DateTime bitisTarihi, out List<OleDbParameter> parametreler)
        {
            string comdYazisi = string.Empty;
            List<OleDbParameter> _parametreler = new List<OleDbParameter>();
            try
            {
                if (Kurumlar == null || Kurumlar.Count == 0
                        || Yetkililer == null || Yetkililer.Count == 0
                        || Kullanicilar == null || Kullanicilar.Count == 0
                        || baslangicTarihi == null || bitisTarihi == null)
                {
                    parametreler = new List<OleDbParameter>();
                    return "";
                }
                string kurumidyazisi = DigerFonksiyonlar.CommandGenerator(Gorusmeler.DBTableName + ".[GorusulenKurumId]", Kurumlar, ref _parametreler);
                string kullaniciidyazisi = DigerFonksiyonlar.CommandGenerator(Gorusmeler.DBTableName + ".[GorusenKullaniciId]", Kullanicilar, ref _parametreler);
                string yetkiliidyazisi = DigerFonksiyonlar.CommandGenerator(Gorusmeler.DBTableName + ".[GorusulenYetkiliId]", Yetkililer, ref _parametreler);
                string tarihleryazisi = "(" + Gorusmeler.DBTableName + ".[GorusmeTarihi] BETWEEN @bastarih AND @bittarih)";
                comdYazisi = string.Format("SELECT * FROM " + Gorusmeler.DBTableName + " WHERE(({0}) AND ({1}) AND ({2}) AND ({3}))", kurumidyazisi, kullaniciidyazisi, yetkiliidyazisi, tarihleryazisi);
                _parametreler.Add(new OleDbParameter("@bastarih", DigerFonksiyonlar.GetDateWithoutMilliseconds(baslangicTarihi)));
                _parametreler.Add(new OleDbParameter("@bittarih", DigerFonksiyonlar.GetDateWithoutMilliseconds(bitisTarihi)));
            }
            catch (Exception ex) { Logger.Log(ex); comdYazisi = string.Empty; _parametreler = new List<OleDbParameter>(); }
            parametreler = _parametreler;
            return comdYazisi;
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static DateTime GetDateWithoutMilliseconds(DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
        }

        public static string MillisecondsToTimeString(double milliseconds)
        {
            string zaman = string.Empty;
            try
            {
                TimeSpan span = TimeSpan.FromMilliseconds(milliseconds);
                zaman = string.Format("{0}{1}{2}{3}{4}"
                    , span.Days != 0 ? span.Days + " gün " : string.Empty
                    , span.Hours != 0 ? span.Hours + " saat " : string.Empty
                    , span.Minutes != 0 ? span.Minutes + " dk " : string.Empty
                    , span.Seconds != 0 ? span.Seconds + " sn " : string.Empty
                    , span.Milliseconds != 0 ? span.Milliseconds + " ms " : string.Empty
                    );
            }
            catch (Exception ex) { Logger.Log(ex); zaman = string.Empty; }
            return zaman;
        }
        /// <summary>
        /// Belirtilen nesnenin kendisi veya ToString() metodu, null veya Empty ise "-"(çizgi) karakterini döndürür.
        /// </summary>
        /// <typeparam name="T">Kontrol edilecek nesnenin sınıfı.</typeparam>
        /// <param name="nesne">Kontrol edilecek nesne.</param>
        /// <returns></returns>
        public static string EmptyToCizgi<T>(T nesne)
        {
            if (nesne != null && !string.IsNullOrEmpty(nesne.ToString()))
            {
                return nesne.ToString();
            }
            else { return "-"; }
        }
        public static string ColorHexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        public static bool IsDesingMode()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            //return System.ComponentModel.DesignMode;
        }

        public static void PanelOrtalama(Control ctrl, int width, int height)
        {
            float x = (Convert.ToInt32(width) - Convert.ToInt32(ctrl.Width)) / 2;
            float y = (Convert.ToInt32(height) - Convert.ToInt32(ctrl.Height)) / 2;
            Point loc = new Point(x: Convert.ToInt32(x), y: Convert.ToInt32(y));
            Delegates.Location.Set(ctrl, loc);
        }

        public static string _YetkiToString<T>(T yetki)
        {
            if (typeof(T).IsEnum)
            {
                if (yetki is NesneYetkileri)
                {
                    return NesneYetkileriTools.ToCustomString(yetki.ToString().ToNesneYetkileri());
                }
                else if (yetki is DigerYetkiler)
                {
                    return DigerYetkilerTools.ToCustomString(yetki.ToString().ToDigerYetkiler());
                }
                else { return string.Empty; }
            }
            else { return string.Empty; }
        }
        public static string YaziGizle(string yazi,char karakter)
        {
            return string.Empty.PadRight(yazi.Length, karakter);
        }
        /// <summary>
        /// Internet Olup Olmadığını Kontrol Eder!
        /// </summary>
        /// <returns>true or false</returns>
        public static bool InternetVarmi()
        {
            try
            {
                return new System.Net.NetworkInformation.Ping().Send("www.google.com", 1000).Status == System.Net.NetworkInformation.IPStatus.Success;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
