using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.Extensions;

namespace GorusmeKayitlari.Core.DB.Methods
{
    public static class Yetkililer
    {
        public const string DBTableName = "Yetkililer";
        /// <summary>
        /// Veritabanındaki tüm yetkilileri Liste şeklinde döndürür.
        /// </summary>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>List<Yetkili> türünde tüm tetkililerin listesini döndürür.</returns>
        public async static Task<List<Yetkili>> TumunuGetir(ConnectionManager manager)
        {
            List<Yetkili> yetkililer = new List<Yetkili>();
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName, manager?.baglanti))
                {
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        while (await okuyucu?.ReadAsync())
                        {
                            Yetkili yetkili = ReaderToYetkili(okuyucu);
                            if (yetkili != null)
                            {
                                yetkililer.Add(yetkili);
                            }
                        }
                    }
                }
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                yetkililer = null;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                yetkililer = null;
                throw;
            }
            return yetkililer;
        }
        /// <summary>
        /// Veritabanındaki bir yetkiliyi döndürür.
        /// </summary>
        /// <param name="Id">Yetkilinin Id'si.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>Yetkili türünde yetkili bilgilerini döndürür.</returns>
        public async static Task<Yetkili> Getir(int Id, ConnectionManager manager)
        {
            Yetkili yetkili = null;
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName + " WHERE id=@id", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@id", Id);
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        if (await okuyucu?.ReadAsync())
                        {
                            yetkili = ReaderToYetkili(okuyucu);
                        }
                    }
                }
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                yetkili = null;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                yetkili = null;
                throw;
            }
            return yetkili;
        }
        /// <summary>
        /// Veritabanına yeni bir yetkili ekler.
        /// </summary>
        /// <param name="yetkili">Eklenecek yetkilinin bilgileri.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>bool türünde ekleme durumunu döndürür.</returns>
        public async static Task<bool> Ekle(Yetkili yetkili, ConnectionManager manager)
        {
            try
            {
                using (OleDbCommand komut = new OleDbCommand("INSERT INTO " + DBTableName + " (Ad,Soyad,Telefon,Eposta,Aciklama) VALUES(@ad, @soyad,@telefon,@eposta,@aciklama)", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@ad", yetkili.Ad);
                    komut.Parameters.AddWithValue("@soyad", yetkili.Soyad);
                    komut.Parameters.AddWithValue("@telefon", yetkili.IletisimBilgileri.Telefon);
                    komut.Parameters.AddWithValue("@eposta", yetkili.IletisimBilgileri.Eposta);
                    komut.Parameters.AddWithValue("@aciklama", yetkili.Aciklama);
                    int sonuc = await manager?.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (DbException ex) { Logger.Log(ex); return false; throw; }
            catch (Exception ex) { Logger.Log(ex); return false; throw; }
        }
        /// <summary>
        /// Veritabanındaki bir yetkiliyi günceller.
        /// </summary>
        /// <param name="yetkili">Güncellenecek yetkilinin bilgileri.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>bool türünde güncelleme durumunu döndürür.</returns>
        public async static Task<bool> Guncelle(Yetkili yetkili, ConnectionManager manager)
        {
            try
            {
                using (OleDbCommand komut = new OleDbCommand("UPDATE " + DBTableName + " SET Ad = @ad , Soyad = @soyad , Telefon = @telefon , Eposta = @eposta , Aciklama = @aciklama WHERE id=@id", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@ad", yetkili.Ad);
                    komut.Parameters.AddWithValue("@soyad", yetkili.Soyad);
                    komut.Parameters.AddWithValue("@telefon", yetkili.IletisimBilgileri.Telefon);
                    komut.Parameters.AddWithValue("@eposta", yetkili.IletisimBilgileri.Eposta);
                    komut.Parameters.AddWithValue("@aciklama", yetkili.Aciklama);
                    komut.Parameters.AddWithValue("@id", yetkili.Id);
                    int sonuc = await manager?.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (DbException ex) { Logger.Log(ex); return false; throw; }
            catch (Exception ex) { Logger.Log(ex); return false; throw; }
        }
        /// <summary>
        /// Veritabanındaki bir yetkiliyi siler.
        /// </summary>
        /// <param name="Id">Silinecek yetkilinin Id'si.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>bool türünde silme durumunu döndürür.</returns>
        public async static Task<bool> Sil(int Id, ConnectionManager manager)
        {
            try
            {
                using (OleDbCommand komut = new OleDbCommand("DELETE FROM " + DBTableName + " WHERE id=@id", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@id", Id);
                    int sonuc = await manager?.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (DbException ex) { Logger.Log(ex); return false; throw; }
            catch (Exception ex) { Logger.Log(ex); return false; throw; }
        }

        private static Yetkili ReaderToYetkili(OleDbDataReader okuyucu)
        {
            if (okuyucu != null)
            {
                int id = int.Parse(okuyucu["id"].ToString());
                string ad = okuyucu["Ad"].ToString();
                string soyad = okuyucu["Soyad"].ToString();
                string telefon = okuyucu["Telefon"].ToString();
                string eposta = okuyucu["Eposta"].ToString();
                IletisimBilgileri iletisimBilgileri = new IletisimBilgileri(telefon, eposta, string.Empty, string.Empty);
                string aciklama = okuyucu["Aciklama"].ToString();
                return new Yetkili(id, ad, soyad, iletisimBilgileri, aciklama);
            }
            else { return null; }
        }
    }
}
