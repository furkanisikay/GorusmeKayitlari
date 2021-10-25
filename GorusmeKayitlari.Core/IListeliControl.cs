using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorusmeKayitlari.Core
{
    public interface IListeliControl
    {
        /// <summary>
        /// Nesne Listesini Temizlemek için kullanılır.
        /// </summary>
        void ListeyiTemizle();
        /// <summary>
        /// T türündeki nesneyi nesne listesine ekler.
        /// </summary>
        /// <typeparam name="T">Nesnelerin türü</typeparam>
        /// <param name="nesne">Listeye eklenecek nesne.</param>
        void ListeyeEkle<T>(T nesne);
        /// <summary>
        /// List<T> türündeki nesneyi nesne listesine ekler.
        /// </summary>
        /// <typeparam name="T">Nesnelerin türü</typeparam>
        /// <param name="nesne"Listeye eklenecek nesne listesi.></param>
        void ListeyeEkle<T>(List<T> nesne);
        /// <summary>
        /// Nesnelerin listesini yükler.
        /// </summary>
        void ListeyiYukle();
        /// <summary>
        /// Listeye eklemek için boş nesne oluşturur.
        /// </summary>
        /// <typeparam name="T">nesnenin türü</typeparam>
        /// <param name="ad">nesnenin görünen adı.</param>
        /// <returns></returns>
        object BosNesneOlustur(string ad);
        /// <summary>
        /// Listenin boş olup olmadığını denetleyen fonksiyon.
        /// </summary>
        /// <returns>bool türünde listenin boş olma durumu.</returns>
        bool _ListeBosDegilse();
    }
}
