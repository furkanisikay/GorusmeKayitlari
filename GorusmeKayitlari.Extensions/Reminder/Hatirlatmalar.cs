using GorusmeKayitlari.Core.DB;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Threading.Tasks;

namespace GorusmeKayitlari.Extensions.Reminder
{
    public static class Hatirlatmalar
    {
        public const string DBTableName = "Hatirlatmalar";
        /// <summary>
        /// Veritabanındaki tüm hatırlatmaları Liste şeklinde döndürür.
        /// </summary>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>List<Hatirlatma> türünde tüm hatırlatmaları döndürür.</returns>
        public async static Task<List<Hatirlatma>> TumunuGetir(ConnectionManager manager)
        {
            List<Hatirlatma> hatirlatmalar = new List<Hatirlatma>();
            try
            {
                using (OleDbCommand komut = new OleDbCommand("SELECT * FROM " + DBTableName, manager?.baglanti))
                {
                    using (OleDbDataReader okuyucu = await manager?.SendCommandAsync(komut))
                    {
                        while (await okuyucu?.ReadAsync())
                        {
                            Hatirlatma kategori = ReaderToHatirlatma(okuyucu);
                            if (kategori != null)
                            {
                                hatirlatmalar.Add(kategori);
                            }
                        }
                    }
                }
            }
            catch (DbException ex)
            {
                Core.Extensions.Logger.Log(ex);
                hatirlatmalar = null;
                throw;
            }
            catch (Exception ex)
            {
                Core.Extensions.Logger.Log(ex);
                hatirlatmalar = null;
                throw;
            }
            return hatirlatmalar;
        }
        /// <summary>
        /// Veritabanındaki bir hatırlatmanın bilgilerini döndürür.
        /// </summary>
        /// <param name="Id">Hatırlatmanın Id'si.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>Hatirlatma türünde bilgilerini döndürür.</returns>
        public async static Task<Hatirlatma> Getir(int Id, ConnectionManager manager)
        {
            Hatirlatma hatirlatma = null;
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
                                hatirlatma = ReaderToHatirlatma(okuyucu);
                            }
                        }
                    }
                }
                else
                {
                    hatirlatma = Hatirlatma.Bos;
                }
            }
            catch (Exception ex)
            {
                Exception exx = new Exception("cs:" + manager.baglanti.ConnectionString + "  -  " + ex.Message, ex);
                Core.Extensions.Logger.Log(exx); hatirlatma = null; throw;
            }
            return hatirlatma;
        }
        /// <summary>
        /// Veritabanına yeni bir hatırlatma ekler.
        /// </summary>
        /// <param name="hatirlatma">Eklenecek hatırlatma bilgileri.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>List<Hatirlatma> türünde tüm hatırlatmaları döndürür.</returns>
        /// <returns>bool türünde ekleme durumunu döndürür.</returns>
        public async static Task<bool> Ekle(Hatirlatma hatirlatma, ConnectionManager manager)
        {
            try
            {
                using (OleDbCommand komut = new OleDbCommand("INSERT INTO " + DBTableName + " (Tarih, Metin) VALUES(@tarih, @metin)", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@tarih", hatirlatma.Tarih);
                    komut.Parameters.AddWithValue("@metin", hatirlatma.Metin);
                    int sonuc = await manager?.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (DbException ex) { Core.Extensions.Logger.Log(ex); return false; throw; }
            catch (Exception ex) { Core.Extensions.Logger.Log(ex); return false; throw; }
        }
        /// <summary>
        /// Veritabanındaki bir hatırlatmayı günceller.
        /// </summary>
        /// <param name="hatirlatma">Güncellenecek hatirlatma bilgileri.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>List<Hatirlatma> türünde tüm hatırlatmaları döndürür.</returns>
        /// <returns>bool türünde güncelleme durumunu döndürür.</returns>
        public async static Task<bool> Guncelle(Hatirlatma hatirlatma, ConnectionManager manager)
        {
            try
            {
                using (OleDbCommand komut = new OleDbCommand("UPDATE " + DBTableName + " SET Metin = @metin, Tarih = @tarih WHERE id=@id", manager?.baglanti))
                {
                    komut.Parameters.AddWithValue("@metin", hatirlatma.Metin);
                    komut.Parameters.AddWithValue("@tarih", hatirlatma.Tarih);
                    komut.Parameters.AddWithValue("@id", hatirlatma.Id);
                    int sonuc = await manager?.SendQueryAsync(komut);
                    return sonuc == 1;
                }
            }
            catch (Exception ex) { Core.Extensions.Logger.Log(ex); return false; }
        }
        /// <summary>
        /// Veritabanındaki bir hatırlatmayı siler.
        /// </summary>
        /// <param name="Id">Silinecek hatırlatmanın Id'si.</param>
        /// <param name="manager">ConnectionManager türündeki bağlantı yöneticisi nesnesi.</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>List<Hatirlatma> türünde tüm hatırlatmaları döndürür.</returns>
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
            catch (DbException ex) { Core.Extensions.Logger.Log(ex); return false; throw; }
            catch (Exception ex) { Core.Extensions.Logger.Log(ex); return false; throw; }
        }
        private static Hatirlatma ReaderToHatirlatma(OleDbDataReader okuyucu)
        {
            if (okuyucu != null)
            {
                int id = int.Parse(okuyucu["id"].ToString());
                string metin = okuyucu["Metin"].ToString();
                DateTime tarih = DateTime.Parse(okuyucu["Tarih"].ToString());
                return new Hatirlatma(id, metin, tarih);
            }
            else { return null; }
        }
        /// <summary>
        /// Görüşme Kayıtları - Hatırlatıcı Programının Windows Task klasörünü döndürür.
        /// </summary>
        /// <param name="ts">Klasörü edinmek için gerekli TaskService</param>
        /// <returns>TaskFolder türünde Görüşme Kayıtları - Hatırlatıcı Programının klasörü</returns>
        public static TaskFolder GetTaskFolder(TaskService ts)
        {
            try
            {
                TaskFolder folder = ts.GetFolder("\\GorusmeKayitlari");
                if (folder == null)
                {
                    folder = ts.RootFolder.CreateFolder("GorusmeKayitlari");
                }
                TaskFolder htFolder = ts.GetFolder("\\GorusmeKayitlari\\Hatirlatici");
                if (htFolder == null)
                {
                    htFolder = folder.CreateFolder("Hatirlatici");
                }
                return htFolder;
            }
            catch { return null; }
        }

        private static TaskDefinition HatırlatmaGetTD(TaskService tss, Hatirlatma ht, string NotifyPath, out string taskname)
        {
            TaskDefinition td = tss.NewTask();
            td.RegistrationInfo.Description = "Görüşme Kayıtları - Hatırlatıcı";
            td.Triggers.Add(new TimeTrigger() { StartBoundary = ht.Tarih });
            td.Principal.RunLevel = TaskRunLevel.Highest;
            string tskname = "Hatirlatma(" + ht.Id.ToString() + ")";
            string arg = string.Format("/FirstRun /htID:{0} /taskname:\"{1}\"", ht.Id, tskname);
            ExecAction act = new ExecAction(NotifyPath, arg, null);
            td.Actions.Add(act);
            taskname = tskname;
            return td;
        }

        public static bool HatirlatmayiTaskOlarakEkle(Hatirlatma ht, string NotifyPath)
        {
            if (ht != null && File.Exists(NotifyPath))
            {
                using (TaskService tss = new TaskService())
                {
                    TaskFolder folder = GetTaskFolder(tss);
                    TaskDefinition td = HatırlatmaGetTD(tss, ht, NotifyPath, out string taskname);
                    try
                    {
                        Microsoft.Win32.TaskScheduler.Task task = folder.RegisterTaskDefinition(taskname, td);
                        return task != null;
                    }
                    catch (Exception ex) { Core.Extensions.Logger.Log(ex); return false; }
                }
            }
            else { return false; }
        }
        public static void HatirlatmayiTasklerdeGuncelle(Hatirlatma ht, string NotifyPath)
        {
            if (ht != null)
            {
                using (TaskService tss = new TaskService())
                {
                    TaskFolder tFolder = GetTaskFolder(tss);
                    string taskPath = string.Format("{0}\\Hatirlatma({1})", tFolder, ht.Id);
                    tFolder.DeleteTask("Hatirlatma(" + ht.Id + ")", false);
                    TaskDefinition td = HatırlatmaGetTD(tss, ht, NotifyPath, out string taskname);
                    try { tFolder.RegisterTaskDefinition(taskname, td); }
                    catch (Exception ex) { Core.Extensions.Logger.Log(ex); }
                }
            }
        }
        public static void HatirlatmayiTasklerdenSil(Hatirlatma ht)
        {
            if (ht != null)
            {
                using (TaskService tss = new TaskService())
                {
                    TaskFolder folder = GetTaskFolder(tss);
                    try { folder.DeleteTask("Hatirlatma(" + ht.Id + ")", false); }
                    catch { }
                }
            }
        }
    }
}
