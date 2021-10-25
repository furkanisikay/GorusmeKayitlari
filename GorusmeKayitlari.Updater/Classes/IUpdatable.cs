using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorusmeKayitlari.Updater.Classes
{
    /// <summary>
    /// Tüm uygulamaların AppUpdater'i kullanabilmek için uygulamak zorunda olduğu arayüz.
    /// </summary>
    public interface IUpdatable
    {
        /// <summary>
        /// Uygulamanızın, güncelleme formunda görüntülenmesini istediğiniz ad.
        /// </summary>
        string ApplicationName { get; }
        /// <summary>
        /// Uygulamanızı update.xml'de tanımlamak için kullanılacak bir tanımlayıcı dizesi,
        /// update.xml dosyanız, uygulamanızla aynı olmalıdır.
        /// </summary>
        string ApplicationID { get; }
        /// <summary>
        /// Geçerli Assembly.
        /// </summary>
        Assembly ApplicationAssembly { get; }
        /// <summary>
        /// Uygulamanın sol üst tarafta görüntülenecek simgesi.
        /// </summary>
        Icon ApplicationIcon { get; }
        /// <summary>
        /// update.xml dosyasının bir sunucuda bulunduğu konum.
        /// </summary>
        Uri UpdateXmlLocation { get; }
        /// <summary>
        /// Programın Kapsayıcısı,
        /// Windows Form Uygulamaları için 'this' kullanın,
        /// Console Uygulamaları için System.Windows.Forms referan olarak ekleyin ve return null.
        /// </summary>
        Form Context { get; }
    }
}
