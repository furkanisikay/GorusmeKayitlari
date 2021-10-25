using System;
using System.Net;
using System.Xml;

namespace GorusmeKayitlari.Updater.Classes
{
    /// <summary>
    /// Güncelleme bilgilerini içerir.
    /// </summary>
    internal class AppUpdaterXML
    {
        private Version version;
        private Uri uri;
        private Uri statisticUrl;
        private string fileName;
        private string md5;
        private string description;
        private string launchArgs;
        /// <summary>
        /// Güncelleme Versiyonu #
        /// </summary>
        internal Version Version { get { return this.version; } }
        /// <summary>
        /// Güncelleme dosyasının adresi.
        /// </summary>
        internal Uri Uri { get { return this.uri; } }
        /// <summary>
        /// İstatistik için HttpWebRequest gönderilecek url.
        /// </summary>
        internal Uri StatisticsUri { get { return this.statisticUrl; } }
        /// <summary>
        /// Yerel bilgisayarda kullanılacak güncelleme dosyasının adı.
        /// </summary>
        internal string FileName { get { return this.fileName; } }
        /// <summary>
        /// Güncelleme dosyasının MD5'i.
        /// </summary>
        internal string MD5 { get { return this.md5; } }
        /// <summary>
        /// Güncelleme açıklaması.
        /// </summary>
        internal string Description { get { return this.description; } }
        /// <summary>
        /// Güncellenmiş uygulamanın ilk çalıştırılma parametreleri.
        /// </summary>
        internal string LaunchArgs { get { return this.launchArgs; } }
        /// <summary>
        /// Yeni bir AppUpdaterXML nesnesi oluşturur.
        /// </summary>
        internal AppUpdaterXML(Version version, Uri uri, Uri statisticUrl, string fileName, string md5, string description, string launchArgs)
        {
            this.version = version;
            this.uri = uri;
            this.statisticUrl = statisticUrl;
            this.fileName = fileName;
            this.md5 = md5;
            this.description = description;
            this.launchArgs = launchArgs;
        }
        /// <summary>
        /// Güncellemenin sürümünün eski sürümden yeni olup olmadığını kontrol eder
        /// </summary>
        /// <param name="version">Uygulamanın geçerli versiyonu.</param>
        /// <returns>Güncellemenin sürümü # daha yeni.</returns>
        internal bool IsNewerThan(Version version)
        {
            return this.version > version;
        }
        /// <summary>
        /// Dosyanın var olduğundan emin olmak için Uri'yi denetler.
        /// </summary>
        /// <param name="location">update.xml'nin Uri'si.</param>
        /// <returns>Dosya varsa</returns>
        internal static bool ExistsOnServer(Uri location)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(location.AbsoluteUri);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                resp.Close();
                return resp.StatusCode == HttpStatusCode.OK;
            }
            catch { return false; }
        }
        /// <summary>
        /// update.xml'yi AppUpdaterXML'ne dönüştürür.
        /// </summary>
        /// <param name="location">update.xml'nin sunucudaki Uri'si</param>
        /// <param name="appID">Uygulama ID'i</param>
        /// <returns>Verileriyle birlikte AppUpdaterXML nesnesi veya hata durumunda null</returns>
        internal static AppUpdaterXML Parse(Uri location, string appID)
        {
            Version version = null;
            string url = string.Empty, statisticUrl = string.Empty, fileName = string.Empty, md5 = string.Empty, description = string.Empty, launchArgs = string.Empty;
            try
            {
                //Dosyayı yükler.
                XmlDocument doc = new XmlDocument();
                doc.Load(location.AbsoluteUri);

                //appId'in düğümünü güncelleme bilgisi ile alır.
                //Bu, tüm programın güncelleme düğümlerini tek bir dosyada saklamanıza izin verir.
                XmlNode node = doc.DocumentElement.SelectSingleNode("//update[@appId='" + appID + "']");

                //Düğüm yoksa, güncelleme yoktur.
                if (node == null) { return null; }

                //Verileri dönüştürür.
                version = Version.Parse(node["version"].InnerText);
                url = node["url"].InnerText;
                statisticUrl = node["statisticUrl"].InnerText;
                fileName = node["fileName"].InnerText;
                md5 = node["md5"].InnerText;
                description = node["description"].InnerText;
                launchArgs = node["launchArgs"].InnerText;
                return new AppUpdaterXML(version, new Uri(url), new Uri(statisticUrl), fileName, md5, description, launchArgs);
            }
            catch { return null; }
        }
    }
}
