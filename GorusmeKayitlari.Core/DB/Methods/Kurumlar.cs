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
    public static class Kurumlar
    {
        public const string DBTableName = "Kurumlar";
        /// <summary>
        /// Veritabanındaki tüm kurumları döndürür.
        /// </summary>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>List<Kurum> türünde tüm kurumların listesini döndürür.</returns>
        public async static Task<List<Kurum>> TumunuGetir(ConnectionManager manager)
        {
            List<Kurum> kurumlar = new List<Kurum>();
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName, manager?.baglanti))
                {
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        while (await okuyucu?.ReadAsync())
                        {
                            Kurum kurum = ReaderToKurum(okuyucu);
                            if (kurum != null)
                            {
                                kurumlar.Add(kurum);
                            }
                        }
                    }
                }
                if (kurumlar?.Count != 0)
                {
                    foreach (Kurum _kurum in kurumlar)
                    {
                        Kurum tmpKurum = await KurumIceriginiYukle(_kurum, manager);
                        _kurum.Kategori = tmpKurum.Kategori;
                        _kurum.Yetkili = tmpKurum.Yetkili;
                    }
                }
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                kurumlar = null;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                kurumlar = null;
                throw;
            }
            return kurumlar;
        }
        /// <summary>
        /// Veritabanındaki tüm kurumları belirtilen Kategorinin Id'sine göre döndürür.
        /// </summary>
        /// <param name="Id">Kurumların Kategori'si.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>List<Kurum> türünde tüm kurumların listesini döndürür.</returns>
        public async static Task<List<Kurum>> TumunuGetir(Kategori Kategori, ConnectionManager manager)
        {
            List<Kurum> kurumlar = new List<Kurum>();
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName + " Where KategoriId = @kategoriid", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@kategoriid", Kategori.Id);
                    using (OleDbDataReader okuyucu = await manager.SendCommandAsync(komut))
                    {
                        while (await okuyucu?.ReadAsync())
                        {
                            Kurum kurum = ReaderToKurum(okuyucu);
                            if(kurum != null)
                            {
                                kurumlar.Add(kurum);
                            }
                        }
                    }
                }
                if (kurumlar?.Count != 0)
                {
                    foreach (Kurum _kurum in kurumlar)
                    {
                        Kurum tmpKurum = await KurumIceriginiYukle(_kurum, manager);
                        _kurum.Kategori = tmpKurum.Kategori;
                        _kurum.Yetkili = tmpKurum.Yetkili;
                    }
                }
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                kurumlar = null;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                kurumlar = null;
                throw;
            }
            return kurumlar;
        }
        /// <summary>
        /// Veritabanındaki tüm kurumları belirtilen Kategorinin Id'sine ve Kategorinin Alt Kategorisindeki Id'lere göre döndürür.
        /// </summary>
        /// <param name="Id">Kurumların Ana Kategori'si.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>List<Kurum> türünde tüm kurumların listesini döndürür.</returns>
        public async static Task<List<Kurum>> AltKategorilereGoreTumunuGetir(Kategori Kategori, ConnectionManager manager)
        {
            List<Kurum> kurumlar = new List<Kurum>();
            try
            {
                List<Kategori> kategoriler = await Kategoriler.UstKategoriIdeGoreTumunuGetir(Kategori.Id, manager);
                if (kategoriler != null)
                {
                    kategoriler.Add(Kategori);
                    List<OleDbParameter> parametreler = new List<OleDbParameter>();
                    string kategoriidleryazisi = DigerFonksiyonlar.CommandGenerator(DBTableName + ".[KategoriId]", kategoriler, ref parametreler);
                    using (OleDbCommand komut = new OleDbCommand(string.Format("SELECT * FROM " + DBTableName + " WHERE({0});", kategoriidleryazisi), manager?.baglanti))
                    {
                        komut.Parameters.AddRange(parametreler.ToArray());
                        using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                        {
                            while (await okuyucu?.ReadAsync())
                            {
                                Kurum kurum = ReaderToKurum(okuyucu);
                                if (kurum != null)
                                {
                                    kurumlar.Add(kurum);
                                }
                            }
                        }
                    }
                    if (kurumlar?.Count != 0)
                    {
                        foreach (Kurum _kurum in kurumlar)
                        {
                            Kurum tmpKurum = await KurumIceriginiYukle(_kurum, manager);
                            _kurum.Kategori = tmpKurum.Kategori;
                            _kurum.Yetkili = tmpKurum.Yetkili;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                kurumlar = null;
            }
            return kurumlar;
        }
        /// <summary>
        /// Veritabanındaki belirtilen Id'ye göre kurumu döndürür.
        /// </summary>
        /// <param name="Id">Kurumun Id'si.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>Kurum türünde kurum bilgilerini döndürür.</returns>
        public async static Task<Kurum> Getir(int Id, ConnectionManager manager)
        {
            Kurum kurum = null;
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName + " WHERE id = @id", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@id", Id);
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        if (await okuyucu?.ReadAsync())
                        {
                            kurum = ReaderToKurum(okuyucu);
                        }
                    }
                }
                Kurum tmpKurum = await KurumIceriginiYukle(kurum, manager);
                kurum.Kategori = tmpKurum.Kategori;
                kurum.Yetkili = tmpKurum.Yetkili;
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                kurum = null;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                kurum = null;
                throw;
            }
            return kurum;
        }
        /// <summary>
        /// Veritabanına yeni bir kurum ekler.
        /// </summary>
        /// <param name="kurum">Eklenecek kurumun bilgileri.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>bool türünde ekleme durumunu döndürür.</returns>
        public async static Task<bool> Ekle(Kurum kurum, ConnectionManager manager)
        {
            try
            {
                using (OleDbCommand komut = new OleDbCommand("INSERT INTO " + DBTableName + " (KategoriId, YetkiliId,Ad,Telefon,Fax,Eposta,Adres,Aciklama) VALUES(@kategoriid, @yetkiliid,@ad,@telefon,@fax,@eposta,@adres,@aciklama)", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@kategoriid", kurum.Kategori.Id);
                    komut.Parameters.AddWithValue("@yetkiliid", kurum.Yetkili.Id);
                    komut.Parameters.AddWithValue("@ad", kurum.Ad);
                    komut.Parameters.AddWithValue("@telefon", kurum.IletisimBilgileri.Telefon);
                    komut.Parameters.AddWithValue("@fax", kurum.IletisimBilgileri.Fax);
                    komut.Parameters.AddWithValue("@eposta", kurum.IletisimBilgileri.Eposta);
                    komut.Parameters.AddWithValue("@adres", kurum.IletisimBilgileri.Adres);
                    komut.Parameters.AddWithValue("@aciklama", kurum.Aciklama);
                    int sonuc = await manager?.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (DbException ex) { Logger.Log(ex); return false; throw; }
            catch (Exception ex) { Logger.Log(ex); return false; throw; }
        }
        /// <summary>
        /// Veritabanındaki bir kurumu günceller.
        /// </summary>
        /// <param name="kurum">Güncellenecek kurumun bilgileri.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>bool türünde güncelleme durumunu döndürür.</returns>
        public async static Task<bool> Guncelle(Kurum kurum, ConnectionManager manager)
        {
            try
            {
                using (OleDbCommand komut = new OleDbCommand("UPDATE " + DBTableName + " SET KategoriId = @kategoriid , YetkiliId = @yetkiliid , Ad = @ad , Telefon = @telefon , Fax = @fax , Eposta = @eposta , Adres = @adres , Aciklama = @aciklama WHERE id=@id", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@kategoriid", kurum.Kategori.Id);
                    komut.Parameters.AddWithValue("@yetkiliid", kurum.Yetkili.Id);
                    komut.Parameters.AddWithValue("@ad", kurum.Ad);
                    komut.Parameters.AddWithValue("@telefon", kurum.IletisimBilgileri.Telefon);
                    komut.Parameters.AddWithValue("@fax", kurum.IletisimBilgileri.Fax);
                    komut.Parameters.AddWithValue("@eposta", kurum.IletisimBilgileri.Eposta);
                    komut.Parameters.AddWithValue("@adres", kurum.IletisimBilgileri.Adres);
                    komut.Parameters.AddWithValue("@aciklama", kurum.Aciklama);
                    komut.Parameters.AddWithValue("@id", kurum.Id);
                    int sonuc = await manager?.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (DbException ex) { Logger.Log(ex); return false; throw; }
            catch (Exception ex) { Logger.Log(ex); return false; throw; }
        }
        /// <summary>
        /// Veritabanındaki bir kurumu siler.
        /// </summary>
        /// <param name="Id">Silinecek kurumun Id'si.</param>
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
        private static Kurum ReaderToKurum(OleDbDataReader okuyucu)
        {
            if (okuyucu != null)
            {
                int id = int.Parse(okuyucu["id"].ToString());
                int kategoriId = int.Parse(okuyucu["KategoriId"].ToString());
                int yetkiliId = int.Parse(okuyucu["YetkiliId"].ToString());
                string ad = okuyucu["Ad"].ToString();
                string telefon = okuyucu["Telefon"].ToString();
                string fax = okuyucu["Fax"].ToString();
                string ePosta = okuyucu["Eposta"].ToString();
                string adres = okuyucu["Adres"].ToString();
                string aciklama = okuyucu["Aciklama"].ToString();
                return new Kurum(id, new Kategori(kategoriId), ad, new Yetkili(yetkiliId), new IletisimBilgileri(telefon, ePosta, fax, adres), aciklama);
            }
            else { return null; }
        }
        private async static Task<Kurum> KurumIceriginiYukle(Kurum kurum, ConnectionManager manager)
        {
            Kurum tmpKurum = kurum;
            if (manager?.baglanti != null)
            {
                if (tmpKurum?.Kategori?.Id > 0)
                {
                    tmpKurum.Kategori = await Kategoriler.Getir(tmpKurum.Kategori.Id, manager);
                }
                else if (tmpKurum?.Kategori?.Id == 0)
                {
                    tmpKurum.Kategori.Ad = "(yok)";
                    tmpKurum.Kategori.UstKategori = null;
                }
                if (tmpKurum?.Yetkili?.Id > 0)
                {
                    tmpKurum.Yetkili = await Yetkililer.Getir(tmpKurum.Yetkili.Id, manager);
                }
            }
            return tmpKurum;
        }
    }
}
