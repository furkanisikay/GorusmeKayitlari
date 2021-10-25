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
    public static class Kullanicilar
    {
        public const string DBTableName = "Kullanicilar";
        /// <summary>
        /// Veritabanındaki tüm kullanıcıları Liste şeklinde döndürür.
        /// </summary>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>List<Kullanici> türünde tüm kullanıcıların listesini döndürür.</returns>
        public async static Task<List<Kullanici>> TumunuGetir(ConnectionManager manager)
        {
            List<Kullanici> kullanicilar = new List<Kullanici>();
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName, manager?.baglanti))
                {
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        while (await okuyucu?.ReadAsync())
                        {
                            Kullanici kullanici = ReaderToKullanici(okuyucu);
                            if (kullanici != null)
                            {
                                kullanicilar.Add(kullanici);
                            }
                        }
                    }
                }
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                kullanicilar = null;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                kullanicilar = null;
                throw;
            }
            return kullanicilar;
        }
        /// <summary>
        /// Veritabanındaki bir kullanıcı döndürür.
        /// </summary>
        /// <param name="Id">Kullanıcı Id'si.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>Kullanici türünde kullanıcı bilgilerini döndürür.</returns>
        public async static Task<Kullanici> Getir(int Id, ConnectionManager manager)
        {
            Kullanici kullanici = null;
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName + " WHERE id=@id", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@id", Id);
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        if (await okuyucu?.ReadAsync())
                        {
                            kullanici = ReaderToKullanici(okuyucu);
                        }
                    }
                }
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                kullanici = null;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                kullanici = null;
                throw;
            }
            return kullanici;
        }
        /// <summary>
        /// Veritabanına yeni bir kullanıcı ekler.
        /// </summary>
        /// <param name="kullanici">Eklenecek kullanıcının bilgileri.(Id'ye Gerek Yok.)</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>bool türünde ekleme durumunu döndürür.</returns>
        public async static Task<bool> Ekle(Kullanici kullanici, ConnectionManager manager)
        {
            try
            {
                using (OleDbCommand komut = new OleDbCommand("INSERT INTO " + DBTableName + " (Ad,Soyad,Telefon,Eposta,Aciklama) VALUES(@ad, @soyad,@telefon,@eposta,@aciklama)", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@ad", kullanici.Ad);
                    komut.Parameters.AddWithValue("@soyad", kullanici.Soyad);
                    komut.Parameters.AddWithValue("@telefon", kullanici.IletisimBilgileri.Telefon);
                    komut.Parameters.AddWithValue("@eposta", kullanici.IletisimBilgileri.Eposta);
                    komut.Parameters.AddWithValue("@aciklama", kullanici.Aciklama);
                    int sonuc = await manager?.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (DbException ex) { Logger.Log(ex); return false; throw; }
            catch (Exception ex) { Logger.Log(ex); return false; throw; }
        }
        /// <summary>
        /// Veritabanındaki bir kullanıcıyı günceller.
        /// </summary>
        /// <param name="kullanici">Güncellenecek kullanıcının bilgileri.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>bool türünde güncelleme durumu</returns>
        public async static Task<bool> Guncelle(Kullanici kullanici, ConnectionManager manager)
        {
            try
            {
                using (OleDbCommand komut = new OleDbCommand("UPDATE " + DBTableName + " SET Ad = @ad , Soyad = @soyad , Telefon = @telefon , Eposta = @eposta , Aciklama = @aciklama WHERE id=@id", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@ad", kullanici.Ad);
                    komut.Parameters.AddWithValue("@soyad", kullanici.Soyad);
                    komut.Parameters.AddWithValue("@telefon", kullanici.IletisimBilgileri.Telefon);
                    komut.Parameters.AddWithValue("@eposta", kullanici.IletisimBilgileri.Eposta);
                    komut.Parameters.AddWithValue("@aciklama", kullanici.Aciklama);
                    komut.Parameters.AddWithValue("@id", kullanici.Id);
                    int sonuc = await manager?.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (Exception ex) { Logger.Log(ex); return false; }
        }
        /// <summary>
        /// Veritabanındaki bir kullanıcıyı siler.
        /// </summary>
        /// <param name="Id">Silinecek kullanıcının Id'si.</param>
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
                    int sonuc = await manager.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (DbException ex) { Logger.Log(ex); return false; throw; }
            catch (Exception ex) { Logger.Log(ex); return false; throw; }
        }
        private static Kullanici ReaderToKullanici(OleDbDataReader okuyucu)
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
                return new Kullanici(id, ad, soyad, iletisimBilgileri, aciklama);
            }
            else { return null; }
        }
    }
}
