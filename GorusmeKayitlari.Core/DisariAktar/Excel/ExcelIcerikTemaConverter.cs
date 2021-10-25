using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Media;
using GorusmeKayitlari.Core.Extensions;

namespace GorusmeKayitlari.Core.DisariAktar.Excel
{
    public class ExcelIcerikTemaConverter
    {
        #region Içeri Aktarma Kodları
        public static ExcelIcerikTemasi XMLToExcelIcerikTema(string path, out string temaadi)
        {
            try
            {
                XmlDocument xmlfile = new XmlDocument();
                xmlfile.Load(path);
                temaadi = xmlfile.SelectSingleNode("tema").Attributes["ad"].InnerText;
                ExcelBlok altbaslikblogu = _NodeGetir(xmlfile, "tema/bloklar/baslikbloklari");
                ExcelBlok birincilblok = _NodeGetir(xmlfile, "tema/bloklar/birincilblok");
                ExcelBlok ikincilblok = _NodeGetir(xmlfile, "tema/bloklar/ikincilblok");
                ExcelIcerikTemasi tema = new ExcelIcerikTemasi(altbaslikblogu, birincilblok, ikincilblok);
                return tema;
            }
            catch (Exception ex) { Logger.Log(ex); temaadi = string.Empty; return null; }
        }

        private static ExcelBlok _NodeGetir(XmlDocument xml, string nodepath)
        {
            Font font = new Font("Microsoft Sans Serif", 8.25f);
            XmlNode node = xml.SelectSingleNode(nodepath);
            bool bold = Convert.ToBoolean(node.SelectSingleNode("fontbold").InnerText);
            bool italic = Convert.ToBoolean(node.SelectSingleNode("fontitalic").InnerText);
            bool ustucizili = Convert.ToBoolean(node.SelectSingleNode("fontstrikeout").InnerText);
            bool alticizili = Convert.ToBoolean(node.SelectSingleNode("fontunderline").InnerText);
            Color yazirengi = ColorTranslator.FromHtml(node.SelectSingleNode("yazirengi").InnerText);
            Color arkaplanrengi = ColorTranslator.FromHtml(node.SelectSingleNode("arkaplanrengi").InnerText);
            decimal genislik = Convert.ToDecimal(node.SelectSingleNode("genislik").InnerText);
            decimal yukseklik = Convert.ToDecimal(node.SelectSingleNode("yukseklik").InnerText);
            Microsoft.Office.Interop.Excel.XlVAlign dikeyhizalama = ExcelAraclari._DikeyHizalamaDonustur(node.SelectSingleNode("dikeyhizalama").InnerText);
            Microsoft.Office.Interop.Excel.XlHAlign yatayhizalama = ExcelAraclari._YatayHizalamaDonustur(node.SelectSingleNode("yatayhizalama").InnerText);

            font = new Font(node.SelectSingleNode("fontadi").InnerText, Convert.ToSingle(node.SelectSingleNode("fontsize").InnerText));
            if (bold) { font = new Font(font.Name, font.Size, font.Style | FontStyle.Bold); }
            if (italic) { font = new Font(font.Name, font.Size, font.Style | FontStyle.Italic); }
            if (ustucizili) { font = new Font(font.Name, font.Size, font.Style | FontStyle.Strikeout); }
            if (alticizili) { font = new Font(font.Name, font.Size, font.Style | FontStyle.Underline); }

            return new ExcelBlok(font, yazirengi, arkaplanrengi, genislik, yukseklik, yatayhizalama, dikeyhizalama);
        }
        #endregion

        #region Dışarı Aktarma Kodları

        public static bool _ExcelIcerikTemaToXML(string xmlPath, string temaadi, ExcelIcerikTemasi tema)
        {
            XDocument xml = new XDocument(new XElement("tema", new XElement("bloklar")));
            xml.Save(xmlPath);
            XmlDocument xmlfile = new XmlDocument();
            xmlfile.Load(xmlPath);
            XmlNode temanode = xmlfile.SelectSingleNode("tema");
            XmlAttribute att = temanode.Attributes.Append(xmlfile.CreateAttribute("ad"));
            att.InnerText = temaadi;
            XmlNode node = xmlfile.SelectSingleNode("tema/bloklar");
            XmlNode altbasliknode = node.AppendChild(xmlfile.CreateElement("baslikbloklari"));
            _NodeAyarla(xmlfile, altbasliknode, tema.BaslikBloklari);
            XmlNode birincilnode = node.AppendChild(xmlfile.CreateElement("birincilblok"));
            _NodeAyarla(xmlfile, birincilnode, tema.BirincilBlok);
            XmlNode ikincilnode = node.AppendChild(xmlfile.CreateElement("ikincilblok"));
            _NodeAyarla(xmlfile, ikincilnode, tema.IkincilBlok);
            xmlfile.Save(xmlPath);
            return File.Exists(xmlPath);
        }
        private static XmlNode _CreateNode(XmlDocument xml, string nodename, string nodevalue)
        {
            XmlNode node = xml.CreateElement(nodename);
            node.InnerText = nodevalue;
            return node;
        }
        private static void _NodeAyarla(XmlDocument xml, XmlNode parentnode, ExcelBlok kutu)
        {
            parentnode.AppendChild(_CreateNode(xml, "fontadi", kutu.YaziTipi.Name));
            parentnode.AppendChild(_CreateNode(xml, "fontsize", kutu.YaziTipi.Size.ToString()));
            parentnode.AppendChild(_CreateNode(xml, "fontunderline", kutu.YaziTipi.Underline.ToString()));
            parentnode.AppendChild(_CreateNode(xml, "fontstrikeout", kutu.YaziTipi.Strikeout.ToString()));
            parentnode.AppendChild(_CreateNode(xml, "fontitalic", kutu.YaziTipi.Italic.ToString()));
            parentnode.AppendChild(_CreateNode(xml, "fontbold", kutu.YaziTipi.Bold.ToString()));
            parentnode.AppendChild(_CreateNode(xml, "yazirengi", DigerFonksiyonlar.ColorHexConverter(kutu.FontRengi)));
            parentnode.AppendChild(_CreateNode(xml, "arkaplanrengi", DigerFonksiyonlar.ColorHexConverter(kutu.ArkaplanRengi)));
            parentnode.AppendChild(_CreateNode(xml, "genislik", kutu.Genislik.ToString()));
            parentnode.AppendChild(_CreateNode(xml, "yukseklik", kutu.Yukseklik.ToString()));
            parentnode.AppendChild(_CreateNode(xml, "dikeyhizalama", ExcelAraclari._HizalamaDonustur(kutu.DikeyHizalama)));
            parentnode.AppendChild(_CreateNode(xml, "yatayhizalama", ExcelAraclari._HizalamaDonustur(kutu.YatayHizalama)));
        }
        #endregion
    }
}
