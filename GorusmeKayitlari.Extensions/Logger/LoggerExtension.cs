using GorusmeKayitlari.Core.Extension;

namespace GorusmeKayitlari.Extensions.Logger
{
    public class LoggerExtension : IExtension
    {
        public string Name
        {
            get
            {
                return "Hata kaydedici";
            }
        }

        public IUIExtension UIExtension
        {
            get
            {
                return new LoggerUIExtension();
            }
        }
    }
}
