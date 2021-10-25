using GorusmeKayitlari.Core.DB;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorusmeKayitlari.Extensions.Reminder
{
    public class HatirlatmaTask : IDisposable
    {
        ConnectionManager cm;
        public HatirlatmaTask()
        {
            cm = ConnectionManager.Instance;
        }

        /// <summary>
        /// GorusmeKayitlari.Reminder.Notify.exe nin bulunduğu dizini döndürür.
        /// </summary>
        public static string NotifyPath = Application.StartupPath + "\\GorusmeKayitlari.Reminder.Notify.exe";

        public bool TaskleriYenidenYukle(bool OnceTemizle = false)
        {
            bool durum = false;
            System.Threading.Tasks.Task task = System.Threading.Tasks.Task.Run(async () =>
            {
                if (OnceTemizle) { HatirlatmaTasklerininHepsiniSil(); }
                durum = await HatirlatmaTasklariniGuncelle();
            });
            task.Wait();
            return durum;
        }

        public void HatirlatmaTasklerininHepsiniSil()
        {
            using (TaskService ts = new TaskService())
            {
                TaskFolder tFolder = Hatirlatmalar.GetTaskFolder(ts);
                foreach (Microsoft.Win32.TaskScheduler.Task task in tFolder.Tasks)
                {
                    tFolder.DeleteTask(task.Name, false);
                }
            }
        }

        public async Task<bool> HatirlatmaTasklariniGuncelle()
        {
            List<bool> Durum = new List<bool>();
            List<Hatirlatma> htListe = null;
            if (!string.IsNullOrEmpty(cm?.baglanti?.ConnectionString)) { htListe = await Hatirlatmalar.TumunuGetir(cm); }
            if (htListe != null)
            {
                using (TaskService ts = new TaskService())
                {
                    TaskFolder tFolder = Hatirlatmalar.GetTaskFolder(ts);
                    foreach (Hatirlatma ht in htListe)
                    {
                        string taskPath = string.Format("{0}\\Hatirlatma({1})", tFolder, ht.Id);
                        Microsoft.Win32.TaskScheduler.Task task = ts.GetTask(taskPath);
                        if (task == null)
                        {
                            Durum.Add(Hatirlatmalar.HatirlatmayiTaskOlarakEkle(ht, NotifyPath));
                        }
                    }
                }
            }
            return !Durum.Contains(false);//herhangi bir hatırlatma eklenmediyse false dönsün diye
        }


        public void Dispose()
        {
            cm.Dispose();
        }
    }
}
