using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GorusmeKayitlari.Core.Extensions
{
    public class Logger
    {
        public static void Log(Exception ex)
        {
            string LoggerPath = Regedit.Ayar_Oku("Logger-Path", Application.StartupPath, Regedit.rkMain, false);
            if (!Directory.Exists(LoggerPath))
            {
                Directory.CreateDirectory(LoggerPath);
            }
            XDocument xml = XDocument.Parse("<logs></logs>");
            try { if (File.Exists(LoggerPath + "\\log.gklog.xml")) { xml = XDocument.Load(LoggerPath + "\\log.gklog.xml"); } }
            catch { xml = XDocument.Parse("<logs></logs>"); }
            try
            {
                DateTime time = DateTime.Now;
                StackTrace st = new StackTrace(ex, true);
                System.Collections.Generic.List<object> contentList = new System.Collections.Generic.List<object>();
                for (int i = 0; i < st.FrameCount; i++)
                {
                    StackFrame frame = st.GetFrame(i);
                    contentList.Add(
                        new XElement("frame" + i.ToString()
                        , new XElement("file", DigerFonksiyonlar.EmptyToCizgi(frame.GetFileName()))
                        , new XElement("methodname", frame.GetMethod().Name)
                        , new XElement("line", DigerFonksiyonlar.EmptyToCizgi(frame.GetFileLineNumber().ToString()))
                        , new XElement("column", frame.GetFileColumnNumber().ToString())));
                    //contentList.Add(
                    //    new XElement("frame" + i.ToString()
                    //    , new XElement("message", Crypt.Sifrele_(ex.Message))
                    //    , new XElement("file", Crypt.Sifrele_(DigerFonksiyonlar.EmptyToCizgi(frame.GetFileName())))
                    //    , new XElement("methodname", Crypt.Sifrele_(frame.GetMethod().Name))
                    //    , new XElement("line", Crypt.Sifrele_(DigerFonksiyonlar.EmptyToCizgi(frame.GetFileLineNumber().ToString())))
                    //    , new XElement("column", Crypt.Sifrele_(frame.GetFileColumnNumber().ToString()))));
                }
                xml.Element("logs").Add(
                    new XElement("log"
                    , new XElement("date", time.ToShortDateString() + " " + time.ToLongTimeString())
                    , new XElement("message", ex.Message)
                    , new XElement("frames", contentList.ToArray())));
                xml.Save(LoggerPath + "\\log.gklog.xml");
            }
            catch { }
        }
        public static void LogforShow(Exception ex)
        {
            string LoggerPath = Regedit.Ayar_Oku("Logger-Path", Application.StartupPath, Regedit.rkMain, false);
            if (!Directory.Exists(LoggerPath))
            {
                Directory.CreateDirectory(LoggerPath);
            }
            XDocument xml = XDocument.Parse("<logs></logs>");
            try { if (File.Exists(LoggerPath + "\\logforshow.gklog.xml")) { xml = XDocument.Load(LoggerPath + "\\logforshow.gklog.xml"); } }
            catch { xml = XDocument.Parse("<logs></logs>"); }
            try
            {
                DateTime time = DateTime.Now;
                StackTrace st = new StackTrace(ex, true);
                System.Collections.Generic.List<object> contentList = new System.Collections.Generic.List<object>();
                for (int i = 0; i < st.FrameCount; i++)
                {
                    StackFrame frame = st.GetFrame(i);
                    contentList.Add(
                        new XElement("frame" + i.ToString()
                        , new XElement("file", DigerFonksiyonlar.EmptyToCizgi(frame.GetFileName()))
                        , new XElement("methodname", frame.GetMethod().Name)
                        , new XElement("line", DigerFonksiyonlar.EmptyToCizgi(frame.GetFileLineNumber().ToString()))
                        , new XElement("column", frame.GetFileColumnNumber().ToString())));
                    //contentList.Add(
                    //    new XElement("frame" + i.ToString()
                    //    , new XElement("message", Crypt.Sifrele_(ex.Message))
                    //    , new XElement("file", Crypt.Sifrele_(DigerFonksiyonlar.EmptyToCizgi(frame.GetFileName())))
                    //    , new XElement("methodname", Crypt.Sifrele_(frame.GetMethod().Name))
                    //    , new XElement("line", Crypt.Sifrele_(DigerFonksiyonlar.EmptyToCizgi(frame.GetFileLineNumber().ToString())))
                    //    , new XElement("column", Crypt.Sifrele_(frame.GetFileColumnNumber().ToString()))));
                }
                xml.Element("logs").Add(
                    new XElement("log"
                    , new XElement("date", time.ToShortDateString() + " " + time.ToLongTimeString())
                    , new XElement("message", ex.Message)
                    , new XElement("frames", contentList.ToArray())));
                xml.Save(LoggerPath + "\\logforshow.gklog.xml");
            }
            catch { }
        }
    }
}
