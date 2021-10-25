using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorusmeKayitlari.App.SingleInstancing
{
    /// <summary>
    /// Tek bir örnek uygulamasının herhangi bir yeni örneğine yanıt vermek için kullanabileceği yöntemleri sağlar.
    /// </summary>
    public interface ISingleInstanceEnforcer
    {
        /// <summary>
        /// Uygulamanın yeni bir örneğinden alınan iletileri işler.
        /// </summary>
        /// <param name="e">Olayla ilgili bilgi tutan EventArgs nesnesi.</param>
        void OnMessageReceived(MessageEventArgs e);
        /// <summary>
        /// Uygulamanın yeni bir örneğini oluşturma işlemini yapar.
        /// </summary>
        /// <param name="e">Olayla ilgili bilgi tutan EventArgs nesnesi.</param>
        void OnNewInstanceCreated(EventArgs e);
    }
}
