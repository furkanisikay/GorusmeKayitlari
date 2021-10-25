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
    public class KullaniciHesaplar
    {
        public const string DBTableName = "KullaniciHesaplar";
        /// <summary>
        /// Belirtilen kullanıcı adının veritabanında kayıtlı olup olmadığını döndürür.
        /// </summary>
        /// <param name="kullaniciAdi">Sorgulanacak kullanıcı adı.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>bool türünde kullanıcı adının veritabanında kayıtlı olup olmadığını döndürür.</returns>
        public async static Task<bool> KullaniciAdiMusaitmi(string kullaniciAdi, ConnectionManager manager)
        {
            bool musait = true;
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName + " WHERE KullaniciAdi=@kulad", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@kulad", kullaniciAdi);
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        if (await okuyucu?.ReadAsync())
                        {
                            musait = false;
                        }
                    }
                }
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                musait = false;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                musait = false;
                throw;
            }
            return musait;
        }
        /// <summary>
        /// Belirtilen kullanıcı adı ve şifreye göre veritabanını sorgulayarak kullanıcı hesabını döndürür. 
        /// </summary>
        /// <param name="hesap">Aranan kullanıcı hesabının KullaniciHesap türündeki nesnesi(Kullanıcı adı ve şifre yeterli.)</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>KullaniciHesap türünde bulunan kullanıcı hesabının bilgileri.</returns>
        public async static Task<KullaniciHesap> Bul(KullaniciHesap hesap, ConnectionManager manager)
        {
            KullaniciHesap kullanicihesabi = null;
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName + " WHERE (KullaniciAdi=@kulad) AND (Sifre=@sfr) ", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@kulad", hesap.KullaniciAdi);
                    komut.Parameters.AddWithValue("@sfr", hesap.Sifre);
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        if (okuyucu != null)
                        {
                            if (await okuyucu.ReadAsync())
                            {
                                kullanicihesabi = ReaderToKullaniciHesap(okuyucu);
                            }
                        }
                        else { kullanicihesabi = null; }
                    }
                }
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                kullanicihesabi = null;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                kullanicihesabi = null;
                throw;
            }
            return kullanicihesabi;
        }
        /// <summary>
        /// Belirtilen Idye göre veritabanında bulunan kullanıcı hesabını döndürür.
        /// </summary>
        /// <param name="Id">Belirtilen kullanıcı hesabının Id'si.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>KullaniciHesap türünde kullanıcı hesabı bilgilerini döndürür.</returns>
        public async static Task<KullaniciHesap> Getir(int Id, ConnectionManager manager)
        {
            KullaniciHesap kullanicihesabi = null;
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName + " WHERE id=@id", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@id", Id);
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        if (await okuyucu?.ReadAsync())
                        {
                            kullanicihesabi = ReaderToKullaniciHesap(okuyucu);
                        }
                    }
                }
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                kullanicihesabi = null;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                kullanicihesabi = null;
                throw;
            }
            return kullanicihesabi;
        }
        /// <summary>
        /// Veritabanında bulunan tüm kullanıcı hesaplarını liste şeklinde döndürür.
        /// </summary>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>List<KullaniciHesap> türünde tüm kullanıcı hesaplarını döndürür.</returns>
        public async static Task<List<KullaniciHesap>> TumunuGetir(ConnectionManager manager)
        {
            List<KullaniciHesap> hesaplar = new List<KullaniciHesap>();
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName, manager?.baglanti))
                {
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        while (await okuyucu?.ReadAsync())
                        {
                            KullaniciHesap hesap = ReaderToKullaniciHesap(okuyucu);
                            if (hesap != null)
                            {
                                hesaplar.Add(hesap);
                            }
                        }
                    }
                }
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                hesaplar = null;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                hesaplar = null;
                throw;
            }
            return hesaplar;
        }
        /// <summary>
        /// Veritabanına yeni bir kullanıcı hesabı ekler.
        /// </summary>
        /// <param name="Hesap">Eklencek kullanıcı hesabını bilgileri.(Id'e gerek yok.)</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>bool türünde eklenme durumunu döndürür.</returns>
        public async static Task<bool> Ekle(KullaniciHesap Hesap, ConnectionManager manager)
        {
            try
            {
                using (OleDbCommand komut = new OleDbCommand("INSERT INTO " + DBTableName + " (KullaniciId,KullaniciAdi,Sifre,NesneYetkileri,DigerYetkiler,HesapDurumu,OlusturulmaTarihi,SonDuzenlemeTarihi,SonDuzenleyenKullaniciHesapId,Aciklama) VALUES(@ki, @ka, @s, @ny, @dy, @hd, @ot, @sdt, @sdki, @a)", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@ki", Hesap.GetKullanici(manager).Id);
                    komut.Parameters.AddWithValue("@ka", Hesap.KullaniciAdi);
                    komut.Parameters.AddWithValue("@s", Hesap.Sifre);
                    komut.Parameters.AddWithValue("@ny", Tools.YetkiHesapla(Hesap.NesneYetkileri));
                    komut.Parameters.AddWithValue("@dy", Tools.YetkiHesapla(Hesap.DigerYetkiler));
                    komut.Parameters.AddWithValue("@hd", Hesap.Durum);
                    komut.Parameters.AddWithValue("@ot", DigerFonksiyonlar.GetDateWithoutMilliseconds(Hesap.OlusturulmaTarihi));
                    komut.Parameters.AddWithValue("@sdt", DigerFonksiyonlar.GetDateWithoutMilliseconds(Hesap.SonDuzenlemeTarihi));
                    komut.Parameters.AddWithValue("@sdki", Hesap.GetSonDuzKulHesabi(manager).Id);
                    komut.Parameters.AddWithValue("@a", Hesap.Aciklama);
                    int sonuc = await manager?.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (DbException ex) { Logger.Log(ex); return false; throw; }
            catch (Exception ex) { Logger.Log(ex); return false; throw; }
        }
        /// <summary>
        /// Veritabanındaki bir kullanıcı hesabını günceller.
        /// </summary>
        /// <param name="Hesap">Güncellenecek kullanıcı hesabının bilgileri</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>bool türünde güncellenme durumu.</returns>
        public async static Task<bool> Guncelle(KullaniciHesap Hesap, ConnectionManager manager)
        {
            try
            {
                using (OleDbCommand komut = new OleDbCommand("UPDATE " + DBTableName + " SET KullaniciID = @ki ,  KullaniciAdi = @ka , Sifre = @s , NesneYetkileri = @ny , DigerYetkiler = @dy , HesapDurumu = @hd , OlusturulmaTarihi = @ot , SonDuzenlemeTarihi = @sdt , SonDuzenleyenKullaniciHesapId = @sdki , Aciklama = @a WHERE id=@id", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@ki", Hesap.GetKullanici(manager).Id);
                    komut.Parameters.AddWithValue("@ka", Hesap.KullaniciAdi);
                    komut.Parameters.AddWithValue("@s", Hesap.Sifre);
                    komut.Parameters.AddWithValue("@ny", Tools.YetkiHesapla(Hesap.NesneYetkileri));
                    komut.Parameters.AddWithValue("@dy", Tools.YetkiHesapla(Hesap.DigerYetkiler));
                    komut.Parameters.AddWithValue("@hd", Hesap.Durum.ToString());
                    komut.Parameters.AddWithValue("@ot", DigerFonksiyonlar.GetDateWithoutMilliseconds(Hesap.OlusturulmaTarihi));
                    komut.Parameters.AddWithValue("@sdt", DigerFonksiyonlar.GetDateWithoutMilliseconds(Hesap.SonDuzenlemeTarihi));
                    komut.Parameters.AddWithValue("@sdki", Hesap.GetSonDuzKulHesabi(manager).Id);
                    komut.Parameters.AddWithValue("@a", Hesap.Aciklama);
                    komut.Parameters.AddWithValue("@id", Hesap.Id);
                    int sonuc = await manager.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (Exception ex) { Logger.Log(ex); return false; }
        }
        /// <summary>
        /// Veritabanındaki belirtilen idye göre kullanıcı hesabını siler.
        /// </summary>
        /// <param name="Id">Silinecek kullanıcı hesabının Id'si.</param>
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

        private static KullaniciHesap ReaderToKullaniciHesap(OleDbDataReader okuyucu)
        {
            if (okuyucu != null)
            {
                int id = int.Parse(okuyucu["id"].ToString());
                Kullanici kull = new Kullanici(int.Parse(okuyucu["KullaniciID"].ToString()));
                string kulAdi = okuyucu["KullaniciAdi"].ToString();
                string sifre = okuyucu["Sifre"].ToString();
                string nyetkileri = okuyucu["NesneYetkileri"].ToString();
                List<NesneYetkileri> nesneYetkileri = Tools.YetkiHesapla<NesneYetkileri>(Convert.ToUInt64(nyetkileri));
                string dyetkiler = okuyucu["DigerYetkiler"].ToString();
                List<DigerYetkiler> digerYetkiler = Tools.YetkiHesapla<DigerYetkiler>(Convert.ToUInt64(dyetkiler));
                KullaniciHesapDurumu durum = okuyucu["HesapDurumu"].ToString().ToKullaniciHesabiDurumu();
                DateTime ot = DateTime.Parse(okuyucu["OlusturulmaTarihi"].ToString());
                DateTime sdt = DateTime.Parse(okuyucu["SonDuzenlemeTarihi"].ToString());
                KullaniciHesap sdkh = new KullaniciHesap(int.Parse(okuyucu["SonDuzenleyenKullaniciHesapId"].ToString()));
                string ac = okuyucu["Aciklama"].ToString();
                return new KullaniciHesap(id, kull, kulAdi, sifre, nesneYetkileri, digerYetkiler, durum, ot, sdt, sdkh, ac);
            }
            else { return null; }
        }
    }
}
