using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.DisariAktar;
using GorusmeKayitlari.Core.DisariAktar.Excel;
using GorusmeKayitlari.Core.Extensions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Excel;

namespace GorusmeKayitlari.Core.DB.Methods
{
    public static class Gorusmeler
    {
        public const string DBTableName = "Gorusmeler";
        //public static ConnectionManager manager = new ConnectionManager(Tools.BaglYazisiniGetir(Regedit.rkMain));
        #region ### TumunuGetir Fonksiyonları ###
        /// <summary>
        /// Veritabanındaki tüm görüşmeleri liste şeklinde döndürür.
        /// </summary>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>Liste(List<Gorusme>) şeklinde tüm görüşmeleri döndürür.</returns>
        public async static Task<List<Gorusme>> TumunuGetir(ConnectionManager manager)
        {
            List<Gorusme> gorusmeler = new List<Gorusme>();
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName, manager?.baglanti))
                {
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        while (await okuyucu?.ReadAsync())
                        {
                            Gorusme gorusme = ReaderToGorusme(okuyucu);
                            if (gorusme != null)
                            {
                                gorusmeler.Add(gorusme);
                            }
                        }
                    }
                }
                if (gorusmeler?.Count != 0)
                {
                    List<Gorusme> tmpGorusmeler = new List<Gorusme>();
                    foreach (Gorusme gorusme in gorusmeler)
                    {
                        Gorusme _gorusme = await GorusmeIceriginiYukle(gorusme, manager);
                        if(_gorusme != null)
                        {
                            tmpGorusmeler.Add(_gorusme);
                        }
                    }
                    gorusmeler = tmpGorusmeler;
                }
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                gorusmeler = null;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                gorusmeler = null;
                throw;
            }
            return gorusmeler;
        }
        /// <summary>
        /// Veritabanındaki tüm görüşmeleri belirtilen IIdliNesne classlı bir nesnenin
        /// idsine göre liste şeklinde döndürür.
        /// </summary>
        /// <param name="Id">Görüşmelerin IIdliNesne classlı bir nesne'si.(IIdliNesne classlı bir nesnede sadece Id olması yeterli)</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>Liste(List<Gorusme>) şeklinde tüm görüşmeleri döndürür.</returns>
        /// <example>await TumunuGetir(new Kurum(1), manager);</example>
        /// <example>await TumunuGetir(new Yetkili(1), manager);</example>
        /// <example>await TumunuGetir(new Kullanici(1), manager);</example>
        public async static Task<List<Gorusme>> TumunuGetir<T>(T nesne, ConnectionManager manager) where T : IIdliNesne
        {
            List<Gorusme> gorusmeler = new List<Gorusme>();
            try
            {
                if (nesne == null)
                {
                    return null;
                }
                string tablosatiri = string.Empty;
                if (nesne is Kurum) { tablosatiri = "GorusulenKurumId"; }
                else if (nesne is Yetkili) { tablosatiri = "GorusulenYetkiliId"; }
                else if (nesne is Kullanici) { tablosatiri = "GorusenKullaniciId"; }
                else { throw new NotSupportedException("T üzerinden belirtilen nesne desteklenmiyor [TumunuGetir]"); }
                using (OleDbCommand komut = new OleDbCommand(string.Format("SELECT * FROM {0} WHERE {1} = @id", DBTableName, tablosatiri), manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@id", ((IIdliNesne)nesne).Id);
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        while (await okuyucu?.ReadAsync())
                        {
                            Gorusme gorusme = ReaderToGorusme(okuyucu);
                            if (gorusme != null)
                            {
                                gorusmeler.Add(gorusme);
                            }
                        }
                    }
                }
                if (gorusmeler != null && gorusmeler.Count != 0)
                {
                    List<Gorusme> tmpGorusmeler = new List<Gorusme>();
                    foreach (Gorusme gorusme in gorusmeler)
                    {
                        Gorusme _gorusme = await GorusmeIceriginiYukle(gorusme, manager);
                        if (_gorusme != null)
                        {
                            tmpGorusmeler.Add(_gorusme);
                        }
                    }
                    gorusmeler = tmpGorusmeler;
                }
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                gorusmeler = null;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                gorusmeler = null;
                throw;
            }
            return gorusmeler;
        }

        /// <summary>
        /// Veritabanındaki tüm görüşmeleri belirtilen kurumlara,yetkililere,kullanıcılara ve tarihlere göre liste şeklinde döndürür.
        /// </summary>
        /// <param name="args">İçerisinde listelenece filtreleri barındırna TumunuGetirArgs türündeki nesne.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>Liste(List<Gorusme>) şeklinde tüm görüşmeleri döndürür.</returns>
        public async static Task<List<Gorusme>> TumunuGetir(TumunuGetirArgs args, ConnectionManager manager)
        {
            List<Gorusme> gorusmeler = new List<Gorusme>();
            try
            {
                if (args.KurumListesi == null || args.KurumListesi.Count == 0
                    || args.YetkiliListesi == null || args.YetkiliListesi.Count == 0
                    || args.KullaniciListesi == null || args.KullaniciListesi.Count == 0
                    || args.BaslangicTarihi == null || args.BitisTarihi == null)
                {
                    return null;
                }
                List<OleDbParameter> parametreler = new List<OleDbParameter>();//CommandGenerator'dan gelen parametreler için.
                using (OleDbCommand komut = new OleDbCommand(DigerFonksiyonlar.CommandGenerator(args.KurumListesi, args.YetkiliListesi, args.KullaniciListesi, args.BaslangicTarihi, args.BitisTarihi, out parametreler), manager?.baglanti))
                {
                    komut.Parameters.AddRange(parametreler.ToArray());//CommandGenerator'dan gelen parametreleri asıl parametrelere eklemek için.
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        while (await okuyucu?.ReadAsync())
                        {
                            Gorusme gorusme = ReaderToGorusme(okuyucu);
                            if (gorusme != null)
                            {
                                gorusmeler.Add(gorusme);
                            }
                        }
                    }
                }
                if (gorusmeler != null && gorusmeler.Count != 0)
                {
                    List<Gorusme> tmpGorusmeler = new List<Gorusme>();
                    foreach (Gorusme gorusme in gorusmeler)
                    {
                        Gorusme _gorusme = await GorusmeIceriginiYukle(gorusme, manager);
                        if (_gorusme != null)
                        {
                            tmpGorusmeler.Add(_gorusme);
                        }
                    }
                    gorusmeler = tmpGorusmeler;
                }
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                gorusmeler = null;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                gorusmeler = null;
                throw;
            }
            return gorusmeler;
        }
        #endregion

        #region ### Dışa Aktarma Fonksiyonları ###
        public static bool ExceleAktar(GorusmeAktar AktarimBilgileri)
        {
            try
            {
                if (AktarimBilgileri != null && AktarimBilgileri.Tur == GorusmeAktarimTuru.Excel)
                {
                    Microsoft.Office.Interop.Excel.Application uygulama = new Microsoft.Office.Interop.Excel.Application();
                    Workbook calismakitabi = uygulama.Workbooks.Add();
                    uygulama.Visible = false;
                    uygulama.ScreenUpdating = false;
                    uygulama.DisplayAlerts = false;
                    uygulama.AlertBeforeOverwriting = false;
                    Worksheet calismasayfa = calismakitabi.Sheets[1];
                    int sutun = 1;
                    int satir = 1;
                    foreach (ColumnHeader clm in AktarimBilgileri.lstGorusmeler.Columns)
                    {
                        ExcelAraclari._RangeEkle(calismasayfa, satir, sutun + clm.DisplayIndex, clm.Text, (AktarimBilgileri.ExcelArgs.Tema?.BaslikBloklari));
                    }
                    satir++;
                    foreach (System.Windows.Forms.ListViewItem item in AktarimBilgileri.lstGorusmeler.Items)
                    {
                        foreach (System.Windows.Forms.ListViewItem.ListViewSubItem subitem in item.SubItems)
                        {
                            ExcelBlok blok = (AktarimBilgileri.ExcelArgs.Tema != null ? (satir % 2 == 0 ? AktarimBilgileri.ExcelArgs.Tema.BirincilBlok : AktarimBilgileri.ExcelArgs.Tema.IkincilBlok) : null);
                            ExcelAraclari._RangeEkle(calismasayfa, satir, sutun, subitem.Text, blok);
                            sutun++;
                        }
                        satir++;
                        sutun = 1;
                    }
                    satir++;

                    #region ### Tarih Bölümü ###
                    Range tarih_dizi = (Range)calismasayfa.Cells[satir, sutun];
                    DateTime tarih = DateTime.Now;
                    tarih_dizi.Value2 = tarih.ToShortDateString() + " - " + tarih.ToLongTimeString();
                    tarih_dizi.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    tarih_dizi.VerticalAlignment = XlVAlign.xlVAlignCenter;
                    #endregion

                    if (File.Exists(AktarimBilgileri.ExcelArgs.DosyaAdi))
                    {
                        try { File.Delete(AktarimBilgileri.ExcelArgs.DosyaAdi); }
                        catch (Exception ex) { Logger.Log(ex); }
                    }

                    calismakitabi.SaveAs(AktarimBilgileri.ExcelArgs.DosyaAdi, AktarimBilgileri.ExcelArgs.DosyaFormati, AktarimBilgileri.ExcelArgs.DosyaAcmaSifresi, AktarimBilgileri.ExcelArgs.DosyaYazmaSifresi, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    calismakitabi.Close();
                    uygulama.Quit();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) { Logger.Log(ex); return false; }
        }
        public static bool HtmleAktar(GorusmeAktar AktarimBilgileri)
        {
            try
            {
                if (AktarimBilgileri != null && AktarimBilgileri.Tur == GorusmeAktarimTuru.Html)
                {
                    #region # html kodlarının ust kısmı ve css bölümü #
                    string ustyazi = "<html>\n<head>\n<style>\n.flat-table {\n\t\tmargin-bottom: 20px;\n\t\tborder-collapse:collapse;\n\t\tfont-family: 'Lato', Calibri, Arial, sans-serif;\n\t\tborder: none;\n                border-radius: 3px;\n               -webkit-border-radius: 3px;\n               -moz-border-radius: 3px;\n\t}\n\t.flat-table th, .flat-table td {\n\t\tbox-shadow: inset 0 -1px rgba(0,0,0,0.25), \n\t\t\tinset 0 1px rgba(0,0,0,0.25);\n\t}\n\t.flat-table th {\n\t\tfont-weight: normal;\n\t\t-webkit-font-smoothing: antialiased;\n\t\tpadding: 1em;\n\t\tcolor: rgba(0,0,0,0.45);\n\t\ttext-shadow: 0 0 1px rgba(0,0,0,0.1);\n\t\tfont-size: 1.5em;\n\t}\n\t.flat-table td {\n\t\tcolor: #f7f7f7;\n\t\tpadding: 0.7em 1em 0.7em 1.15em;\n\t\ttext-shadow: 0 0 1px rgba(255,255,255,0.1);\n\t\tfont-size: 1.4em;\n\t}\n\t.flat-table tr {\n\t\t-webkit-transition: background 0.3s, box-shadow 0.3s;\n\t\t-moz-transition: background 0.3s, box-shadow 0.3s;\n\t\ttransition: background 0.3s, box-shadow 0.3s;\n\t}\n\t.flat-table-1 {\n\t\tbackground: #336ca6;\n\t}\n\t.flat-table-1 tr:hover {\n\t\tbackground: rgba(0,0,0,0.19);\n\t}\n\t.flat-table-2 tr:hover {\n\t\tbackground: rgba(0,0,0,0.1);\n\t}\n\t.flat-table-2 {\n\t\tbackground: #f06060;\n\t}\n\t.flat-table-3 {\n\t\tbackground: #52be7f;\n\t}\n\t.flat-table-3 tr:hover {\n\t\tbackground: rgba(0,0,0,0.1);\n\t}\n</style>\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"/>\n</head>";
                    #endregion
                    string altyazi = "\n\n<body>";
                    altyazi += "\n<center>";
                    altyazi += "\n<table class=\"flat-table flat-table-1\">";
                    altyazi += "\n\t<thead>";
                    foreach (ColumnHeader clm in AktarimBilgileri.lstGorusmeler.Columns)
                    {
                        altyazi += "\n\t\t<th>" + clm.Text + "</th>";
                    }
                    altyazi += "\n\t</thead>";
                    altyazi += "\n\t<tbody>";
                    foreach (System.Windows.Forms.ListViewItem item in AktarimBilgileri.lstGorusmeler.Items)
                    {
                        altyazi += "\n\t\t<tr>";
                        foreach (System.Windows.Forms.ListViewItem.ListViewSubItem subitem in item.SubItems)
                        {
                            altyazi += "\n\t\t\t<td>" + subitem.Text + "</td>";
                        }
                        altyazi += "\n\t\t</tr>";
                    }
                    altyazi += "\n\t</tbody>";
                    altyazi += "\n</table>";
                    altyazi += "\n</center>";
                    altyazi += "\n</body>";
                    altyazi += "\n</html>";

                    System.IO.File.WriteAllText(AktarimBilgileri.HtmlArgs.DosyaAdi, string.Concat(ustyazi, altyazi));
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex) { Logger.Log(ex); return false; }
        }
        public static bool PDFeAktar(GorusmeAktar AktarimBilgileri)
        {
            try
            {
                if (AktarimBilgileri != null && AktarimBilgileri.Tur == GorusmeAktarimTuru.Pdf)
                {
                    #region PDF için Rastegele İdareten İsim Oluştur

                    string temp_ad = "";
                    string dosya_adi = "";
                    do
                    {
                        temp_ad = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                        dosya_adi = Path.GetTempPath() + "GorusmeKayitlari\\pdf\\" + temp_ad + ".pdf";
                    } while (File.Exists(dosya_adi));
                    #endregion

                    #region kullanılan dosya ve klasörleri oluştur
                    if (!Directory.Exists(Path.GetTempPath() + "GorusmeKayitlari"))
                    {
                        Directory.CreateDirectory(Path.GetTempPath() + "GorusmeKayitlari");
                        Directory.CreateDirectory(Path.GetTempPath() + "GorusmeKayitlari\\img");
                        Directory.CreateDirectory(Path.GetTempPath() + "GorusmeKayitlari\\pdf");
                    }

                    if (!string.IsNullOrEmpty(AktarimBilgileri.PdfArgs.LogoDosyaAdi) && File.Exists(AktarimBilgileri.PdfArgs.LogoDosyaAdi))
                    {
                        string logo_dosya_adi = "";
                        do
                        {
                            temp_ad = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                            logo_dosya_adi = Path.GetTempPath() + "GorusmeKayitlari\\pdf\\" + temp_ad + ".png";
                        } while (File.Exists(logo_dosya_adi));
                        File.Copy(AktarimBilgileri.PdfArgs.LogoDosyaAdi, logo_dosya_adi);
                        AktarimBilgileri.PdfArgs.LogoDosyaAdi = logo_dosya_adi;
                    }
                    #endregion

                    #region Font seç
                    BaseFont anafont = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\segoeuil.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fontArial = new iTextSharp.text.Font(anafont, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.DARK_GRAY);
                    iTextSharp.text.Font fontArialHeader = new iTextSharp.text.Font(anafont, 13, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                    iTextSharp.text.Font fontArialbold = new iTextSharp.text.Font(anafont, 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.DARK_GRAY);
                    iTextSharp.text.Font fontArialboldgeneral = new iTextSharp.text.Font(anafont, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                    #endregion

                    #region Fatura pdf oluştur
                    iTextSharp.text.Document pdfFile = new iTextSharp.text.Document();
                    PdfWriter.GetInstance(pdfFile, new FileStream(dosya_adi, FileMode.Create));
                    pdfFile.Open();
                    #endregion

                    #region Fatura oluşturan bilgileri
                    pdfFile.AddCreator(AktarimBilgileri.PdfArgs.Yazar); //Oluşturan kişinin isminin eklenmesi
                    pdfFile.AddCreationDate();//Oluşturulma tarihinin eklenmesi
                    pdfFile.AddAuthor(AktarimBilgileri.PdfArgs.Yazar); //Yazarın isiminin eklenmesi
                    pdfFile.AddHeader(AktarimBilgileri.PdfArgs.Baslik, AktarimBilgileri.PdfArgs.Yazar);
                    pdfFile.AddTitle(AktarimBilgileri.PdfArgs.Baslik); //Başlık ve title eklenmesi
                    #endregion

                    #region Fatura firma resmi ve tarihi oluştur
                    PdfPTable pdfTableHeader = new PdfPTable(AktarimBilgileri.PdfArgs.BaslikSayisi)
                    {
                        TotalWidth = 500f,
                        LockedWidth = true
                    };
                    pdfTableHeader.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    if (!string.IsNullOrEmpty(AktarimBilgileri.PdfArgs.LogoDosyaAdi) && File.Exists(AktarimBilgileri.PdfArgs.LogoDosyaAdi))
                    {
                        iTextSharp.text.Image jpgimg = iTextSharp.text.Image.GetInstance(AktarimBilgileri.PdfArgs.LogoDosyaAdi);
                        jpgimg.ScalePercent(35);
                        jpgimg.Alignment = iTextSharp.text.Image.LEFT_ALIGN;
                        PdfPCell cellheader1 = new PdfPCell(jpgimg)
                        {
                            HorizontalAlignment = PdfPCell.ALIGN_LEFT,
                            VerticalAlignment = PdfPCell.ALIGN_BOTTOM,
                            FixedHeight = 60f,
                            Border = 0
                        };
                        pdfTableHeader.AddCell(cellheader1);
                    }
                    if (!string.IsNullOrEmpty(AktarimBilgileri.PdfArgs.Baslik))
                    {
                        PdfPCell cellheader2 = new PdfPCell(new Phrase(AktarimBilgileri.PdfArgs.Baslik, fontArialHeader))
                        {
                            HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                            VerticalAlignment = PdfPCell.ALIGN_MIDDLE,
                            FixedHeight = 60f,
                            Border = 0
                        };
                        pdfTableHeader.AddCell(cellheader2);
                    }
                    if (AktarimBilgileri.PdfArgs.TarihGoster)
                    {
                        PdfPCell cellheader3 = new PdfPCell(new Phrase(DateTime.Now.ToShortDateString(), fontArial))
                        {
                            HorizontalAlignment = PdfPCell.ALIGN_RIGHT,
                            VerticalAlignment = PdfPCell.ALIGN_MIDDLE,
                            FixedHeight = 60f,
                            Border = 0
                        };
                        pdfTableHeader.AddCell(cellheader3);
                    }
                    #endregion

                    Phrase p = new Phrase("\n");

                    #region Tabloyu Oluştur
                    PdfPTable pdfTable = new PdfPTable(AktarimBilgileri.lstGorusmeler.Columns.Count)
                    {
                        TotalWidth = 500f,
                        LockedWidth = true
                    };
                    pdfTable.DefaultCell.Padding = 5;
                    pdfTable.DefaultCell.BorderColor = iTextSharp.text.BaseColor.GRAY;

                    foreach (ColumnHeader clm in AktarimBilgileri.lstGorusmeler.Columns)
                    {
                        pdfTable.AddCell(new Phrase(clm.Text, fontArialboldgeneral));
                    }

                    foreach (System.Windows.Forms.ListViewItem item in AktarimBilgileri.lstGorusmeler.Items)
                    {
                        foreach (System.Windows.Forms.ListViewItem.ListViewSubItem subitem in item.SubItems)
                        {
                            pdfTable.AddCell(new Phrase(subitem.Text, fontArial));
                        }
                    }

                    #endregion

                    #region Pdfe yaz ve dosyayı kapat
                    if (pdfFile.IsOpen() == false) pdfFile.Open();
                    pdfFile.Add(pdfTableHeader);
                    pdfFile.Add(p);
                    pdfFile.Add(pdfTable);
                    pdfFile.Close();
                    if (File.Exists(AktarimBilgileri.PdfArgs.DosyaAdi))
                    {
                        try { File.Delete(AktarimBilgileri.PdfArgs.DosyaAdi); }
                        catch (Exception ex) { Logger.Log(ex); }
                    }
                    File.Move(dosya_adi, AktarimBilgileri.PdfArgs.DosyaAdi);
                    try { Directory.Delete(Path.GetTempPath() + "GorusmeKayitlari", true); }
                    catch (Exception ex) { Logger.Log(ex); }
                    #endregion
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex) { Logger.Log(ex); return false; }
        }
        #endregion

        /// <summary>
        /// Veritabanındaki bir Görüşmeyi belirtilen Id'ye göre döndürür.
        /// </summary>
        /// <param name="Id">Görüşmenin Id'si.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>Gorusme türünde görüşme bilgileri</returns>
        public async static Task<Gorusme> Getir(int Id, ConnectionManager manager)
        {
            Gorusme gorusme = null;
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName + " WHERE id = @id", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@id", Id);
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        if (await okuyucu?.ReadAsync())
                        {
                            gorusme = ReaderToGorusme(okuyucu);
                        }
                    }
                }
                if (gorusme != null)
                {
                    Gorusme _gorusme = await GorusmeIceriginiYukle(gorusme, manager);
                    if (_gorusme != null)
                    {
                        gorusme = _gorusme;
                    }
                }
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                gorusme = null;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                gorusme = null;
                throw;
            }
            return gorusme;
        }
        /// <summary>
        /// Veritabanına yeni bir görüşme ekler.
        /// </summary>
        /// <param name="gorusme">Eklenecek görüşme bilgileri.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>bool türünde eklenme durumu</returns>
        public async static Task<bool> Ekle(Gorusme gorusme, ConnectionManager manager)
        {
            try
            {
                using (OleDbCommand komut = new OleDbCommand("INSERT INTO " + DBTableName + " (GorusulenKurumId,GorusulenYetkiliId,GorusenKullaniciId,GorusmeMetni,GorusmeTarihi) VALUES(@kurumid, @yetkiliid,@kullaniciid,@metin,@tarih)", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@kurumid", gorusme.Kurum.Id);
                    komut.Parameters.AddWithValue("@yetkiliid", gorusme.Yetkili.Id);
                    komut.Parameters.AddWithValue("@kullaniciid", gorusme.Kullanici.Id);
                    komut.Parameters.AddWithValue("@metin", gorusme.Metin);
                    komut.Parameters.AddWithValue("@tarih", DigerFonksiyonlar.GetDateWithoutMilliseconds(gorusme.Tarih));
                    int sonuc = await manager?.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (DbException ex) { Logger.Log(ex); return false; throw; }
            catch (Exception ex) { Logger.Log(ex); return false; throw; }
        }
        /// <summary>
        /// Veritabanındaki bir görüşmeyi günceller.
        /// </summary>
        /// <param name="gorusme">Güncellenecek görüşme bilgileri.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>bool türünde güncellenme durumu</returns>
        public async static Task<bool> Guncelle(Gorusme gorusme, ConnectionManager manager)
        {
            try
            {
                using (OleDbCommand komut = new OleDbCommand("UPDATE " + DBTableName + " SET GorusulenKurumId = @kurumid , GorusulenYetkiliId = @yetkiliid , GorusenKullaniciId = @kullaniciid , GorusmeMetni = @metin , GorusmeTarihi = @tarih WHERE id=@id", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@kurumid", gorusme.Kurum.Id);
                    komut.Parameters.AddWithValue("@yetkiliid", gorusme.Yetkili.Id);
                    komut.Parameters.AddWithValue("@kullaniciid", gorusme.Kullanici.Id);
                    komut.Parameters.AddWithValue("@metin", gorusme.Metin);
                    komut.Parameters.AddWithValue("@tarih", gorusme.Tarih);
                    komut.Parameters.AddWithValue("@id", gorusme.Id);
                    int sonuc = await manager?.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (DbException ex) { Logger.Log(ex); return false; throw; }
            catch (Exception ex) { Logger.Log(ex); return false; throw; }
        }
        /// <summary>
        /// Veritabanındaki bir görüşmeyi siler.
        /// </summary>
        /// <param name="Id">Silinecek görüşmenin Id'si.</param
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>bool türünde silme durumu</returns>
        public async static Task<bool> Sil(int Id, ConnectionManager manager)
        {
            try
            {
                using (OleDbCommand komut = new OleDbCommand("DELETE FROM " + DBTableName + " WHERE id=@id", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@id", Id);
                    int sonuc = await manager?.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (DbException ex) { Logger.Log(ex); return false; throw; }
            catch (Exception ex) { Logger.Log(ex); return false; throw; }
        }

        private static Gorusme ReaderToGorusme(OleDbDataReader okuyucu)
        {
            if (okuyucu != null)
            {
                int id = int.Parse(okuyucu["id"].ToString());
                int kurumId = int.Parse(okuyucu["GorusulenKurumId"].ToString());
                int yetkiliId = int.Parse(okuyucu["GorusulenYetkiliId"].ToString());
                int kullaniciId = int.Parse(okuyucu["GorusenKullaniciId"].ToString());
                DateTime tarih = DateTime.Parse(okuyucu["GorusmeTarihi"].ToString());
                string metin = okuyucu["GorusmeMetni"].ToString();
                return new Gorusme(id, new Kurum(kurumId), new Yetkili(yetkiliId), new Kullanici(kullaniciId), tarih, metin);
            }
            else { return null; }
        }

        private async static Task<Gorusme> GorusmeIceriginiYukle(Gorusme gorusme, ConnectionManager manager)
        {
            Gorusme tmpGorusme = gorusme;
            if (manager?.baglanti != null)
            {
                tmpGorusme.Kurum = await Kurumlar.Getir(gorusme.Kurum.Id, manager);
                tmpGorusme.Yetkili = await Yetkililer.Getir(gorusme.Yetkili.Id, manager);
                tmpGorusme.Kullanici = await Kullanicilar.Getir(gorusme.Kullanici.Id, manager);
            }
            return tmpGorusme;
        }
    }
}
