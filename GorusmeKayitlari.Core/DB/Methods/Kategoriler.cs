using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Threading.Tasks;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.Extensions;

namespace GorusmeKayitlari.Core.DB.Methods
{
    public static class Kategoriler
    {
        public const string DBTableName = "Kategoriler";
        /// <summary>
        /// Veritabanındaki tüm kategorileri Liste şeklinde döndürür.
        /// </summary>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>List<Kategori> türünde tüm kategorilerileri döndürür.</returns>
        public async static Task<List<Kategori>> TumunuGetir(ConnectionManager manager)
        {
            List<Kategori> kategoriler = new List<Kategori>();
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName, manager?.baglanti))
                {
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        while (await okuyucu?.ReadAsync())
                        {
                            Kategori kategori = ReaderToKategori(okuyucu);
                            if (kategori != null)
                            {
                                kategoriler.Add(kategori);
                            }
                        }
                    }
                }
                if (kategoriler?.Count != 0)
                {
                    foreach (Kategori _kategori in kategoriler)
                    {
                        Kategori kategori = await KategoriIceriginiYukle(_kategori, manager);
                        if (kategori != null)
                        {
                            _kategori.UstKategori = kategori.UstKategori;
                        }
                    }
                }
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                kategoriler = null;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                kategoriler = null;
                throw;
            }
            return kategoriler;
        }
        /// <summary>
        /// Veritabanındaki tüm kategorileri belirtilen Id'ye göre Liste şeklinde döndürür.
        /// </summary>
        /// <param name="UstKategoriId">Listelenecek kategorilerin üst kategorisinin id'si.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>List<Kategori> türünde tüm kategorilerileri döndürür.</returns>
        public async static Task<List<Kategori>> UstKategoriIdeGoreTumunuGetir(int UstKategoriId, ConnectionManager manager)
        {
            List<Kategori> kategoriler = new List<Kategori>();
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName + " WHERE UstKategoriId = @ustkategoriid", manager.baglanti))
                {
                    komut.Parameters.AddWithValue("@ustkategoriid", UstKategoriId);
                    using (OleDbDataReader okuyucu = (OleDbDataReader)await komut.ExecuteReaderAsync())
                    {
                        while (await okuyucu.ReadAsync())
                        {
                            Kategori kategori = ReaderToKategori(okuyucu);
                            if (kategori != null)
                            {
                                kategoriler.Add(kategori);
                            }
                        }
                    }
                }
                if (kategoriler?.Count != 0)
                {
                    List<Kategori> _temp_kategoriler = new List<Kategori>();
                    foreach (Kategori _kategori in kategoriler)
                    {
                        List<Kategori> _tmpktgr = await Kategoriler.UstKategoriIdeGoreTumunuGetir(_kategori.Id, manager);
                        if (_tmpktgr?.Count != 0)
                        {
                            _temp_kategoriler.AddRange(_tmpktgr);
                        }
                    }
                    if (_temp_kategoriler?.Count != 0) { kategoriler.AddRange(_temp_kategoriler); }
                    foreach (Kategori _kategori in kategoriler)
                    {
                        Kategori kategori = await KategoriIceriginiYukle(_kategori, manager);
                        if (kategori != null)
                        {
                            _kategori.UstKategori = kategori.UstKategori;
                        }
                    }
                }
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                kategoriler = null;
                throw;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                kategoriler = null;
                throw;
            }
            return kategoriler;
        }
        /// <summary>
        /// Veritabanındaki bir kategorinin bilgilerini döndürür.
        /// </summary>
        /// <param name="Id">Kategorinin Id'si.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>Kategori türünde bilgilerini döndürür.</returns>
        public async static Task<Kategori> Getir(int Id, ConnectionManager manager, bool UstkategorileriGetir = true)
        {
            Kategori kategori = null;
            try
            {
                if (Id != 0)
                {
                    using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName + " WHERE id=@id", manager?.baglanti))
                    {
                        komut.Parameters.AddWithValue("@id", Id);
                        using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                        {
                            if (await okuyucu?.ReadAsync())
                            {
                                kategori = ReaderToKategori(okuyucu);
                            }
                        }
                    }
                    Kategori _kategori = await KategoriIceriginiYukle(kategori, manager);
                    if (_kategori != null)
                    {
                        kategori.UstKategori = _kategori.UstKategori;
                    }
                }
                else
                {
                    kategori = new Kategori(-1, null, "(yok)");
                }
            }
            catch (DbException ex) { Logger.Log(ex); kategori = null; throw; }
            catch (Exception ex) { Logger.Log(ex); kategori = null; throw; }
            return kategori;
        }
        /// <summary>
        /// Veritabanındaki bir kategorinin ismini döndürür.
        /// </summary>
        /// <param name="Id">Kategorinin Id'si.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>string türünde kategori ismini döndürür.</returns>
        public async static Task<string> IsimGetir(int Id, ConnectionManager manager)
        {
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName + " WHERE id=@id", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@id", Id);
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        if (await okuyucu?.ReadAsync())
                        {
                            return okuyucu["Ad"].ToString();
                        }
                        else { return string.Empty; }
                    }
                }
            }
            catch (DbException ex) { Logger.Log(ex); return string.Empty; throw; }
            catch (Exception ex) { Logger.Log(ex); return string.Empty; throw; }
        }
        /// <summary>
        /// Veritabanına yeni bir kategori ekler.
        /// </summary>
        /// <param name="kategori">Eklenecek kategori bilgileri.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>List<Kategori> türünde tüm kategorilerileri döndürür.</returns>
        /// <returns>bool türünde ekleme durumunu döndürür.</returns>
        public async static Task<bool> Ekle(Kategori kategori, ConnectionManager manager)
        {
            try
            {
                using (OleDbCommand komut = new OleDbCommand("INSERT INTO " + DBTableName + " (UstKategoriId, Ad) VALUES(@ustkategoriid, @ad)", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@ustkategoriid", kategori.UstKategori.Id);
                    komut.Parameters.AddWithValue("@ad", kategori.Ad);
                    int sonuc = await manager?.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (DbException ex) { Logger.Log(ex); return false; throw; }
            catch (Exception ex) { Logger.Log(ex); return false; throw; }
        }
        /// <summary>
        /// Veritabanındaki bir kategoriyi günceller.
        /// </summary>
        /// <param name="kategori">Güncellenecek kategori bilgileri.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>List<Kategori> türünde tüm kategorilerileri döndürür.</returns>
        /// <returns>bool türünde güncelleme durumunu döndürür.</returns>
        public async static Task<bool> Guncelle(Kategori kategori, ConnectionManager manager)
        {
            try
            {
                ;
                using (OleDbCommand komut = new OleDbCommand("UPDATE " + DBTableName + " SET UstKategoriId = @ustkategoriid, Ad = @ad WHERE id=@id", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@ustkategoriid", kategori.UstKategori.Id);
                    komut.Parameters.AddWithValue("@ad", kategori.Ad);
                    komut.Parameters.AddWithValue("@id", kategori.Id);
                    int sonuc = await manager?.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (Exception ex) { Logger.Log(ex); return false; }
        }
        /// <summary>
        /// Veritabanındaki bir kategoriyi siler.
        /// </summary>
        /// <param name="Id">Silinecek kategorinin Id'si.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>List<Kategori> türünde tüm kategorilerileri döndürür.</returns>
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
        private static Kategori ReaderToKategori(OleDbDataReader okuyucu)
        {
            if (okuyucu != null)
            {
                int id = int.Parse(okuyucu["id"].ToString());
                int ustKategoriId = int.Parse(okuyucu["UstKategoriId"].ToString());
                string ad = okuyucu["Ad"].ToString();
                return new Kategori(id, new Kategori(ustKategoriId), ad);
            }
            else { return null; }
        }
        private async static Task<Kategori> KategoriIceriginiYukle(Kategori kategori, ConnectionManager manager, bool UstkategorileriGetir = true)
        {
            Kategori tmpkategori = kategori;
            if (manager?.baglanti != null)
            {
                if (tmpkategori?.UstKategori?.Id > 0 && UstkategorileriGetir)
                {
                    tmpkategori.UstKategori = await Getir(kategori.UstKategori.Id, manager);
                }
                else if (kategori?.UstKategori?.Id == 0)
                {
                    tmpkategori.UstKategori.Ad = "(yok)";
                    tmpkategori.UstKategori.UstKategori = null;
                }
            }
            return tmpkategori;
        }
    }
}
