using GorusmeKayitlari.App.SingleInstancing;
using System;

namespace GorusmeKayitlari.Core
{/// <summary>
 /// Uygulamanın ilk örneği ile iletişim kurmak için bir proxy sağlar.
 /// </summary>
    internal class SingleInstanceProxy : MarshalByRefObject
    {
        #region Member Variables

        private ISingleInstanceEnforcer enforcer;

        #endregion

        #region Construction / Destruction

        /// <summary>
        /// Yeni bir SingleInstanceProxy nesnesini başlatır.
        /// </summary>
        /// <param name="enforcer">Uygulamanın yeni örneklerinden iletiler alacak uygulayıcı (uygulamanın ilk örneği).</param>
        /// <exception cref="System.ArgumentNullException">Uygulayıcı boş</exception>
        public SingleInstanceProxy(ISingleInstanceEnforcer enforcer)
        {
            if (enforcer == null)
                throw new ArgumentNullException("enforcer", "enforcer cannot be null.");

            this.enforcer = enforcer;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Uygulamanın yeni örneklerinden iletiler alacak uygulayıcıyı (uygulamanın ilk örneğini) alır veya ayarlar.
        /// </summary>
        public ISingleInstanceEnforcer Enforcer
        {
            get
            {
                return enforcer;
            }
        }

        #endregion

        ///
        /// Geçersiz kılma ve Windows nesnesinin çöp toplama işlemi yapmasını engellemek için NULL değerini döndürür.
        ///
        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}
