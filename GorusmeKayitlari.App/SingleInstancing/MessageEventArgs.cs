using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorusmeKayitlari.App.SingleInstancing
{
    /// <summary>
    /// SingleInstancing.ISingleInstanceEnforcer.OnMessageReceived yöntemi için veri sağlar.
    /// </summary>
    [Serializable()]
    public class MessageEventArgs : EventArgs
    {
        #region Member Variables

        private object message;

        #endregion

        #region Construction / Destruction

        /// <summary>
        /// Yeni bir MessageEventArgs nesnesini başlatır.
        /// </summary>
        /// <param name="message">Uygulamanın ilk çalıştıran örneğine iletilecek ileti.</param>
        /// <exception cref="System.ArgumentNullException">Ileti boş.</exception>
        public MessageEventArgs(object message)
        {
            if (message == null)
                throw new ArgumentNullException("message", "message cannot be null.");

            this.message = message;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Uygulamanın ilk örneğine gönderilen iletiyi alır.
        /// </summary>
        public object Message
        {
            get
            {
                return message;
            }
        }

        #endregion
    }
}
