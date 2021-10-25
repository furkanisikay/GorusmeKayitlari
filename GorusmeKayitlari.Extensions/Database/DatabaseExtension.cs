using GorusmeKayitlari.Core.Extension;

namespace GorusmeKayitlari.Extensions.Database
{
    public class DatabaseExtension : IExtension
    {
        public string Name
        {
            get
            {
                return "Veritabanı";
            }
        }

        public IUIExtension UIExtension
        {
            get
            {
                return new DatabaseUIExtension();
            }
        }
    }
}
