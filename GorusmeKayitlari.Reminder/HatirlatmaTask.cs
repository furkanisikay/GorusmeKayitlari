using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GorusmeKayitlari.Core.DB;
using Microsoft.Win32.TaskScheduler;

namespace GorusmeKayitlari.Reminder
{
    public class HatirlatmaTask : IDisposable
    {
        TaskService ts;
        ConnectionManager cm;
        public HatirlatmaTask()
        {
            ts = new TaskService();
            cm = ConnectionManager.Instance;
        }

        public void TaskleriYenidenYukle()
        {
            System.Threading.Tasks.Task task = System.Threading.Tasks.Task.Run(async () =>
            {
                HatirlatmaTasklerininHepsiniSil();
                await HatirlatmaTasklariniGuncelle();
            });
        }

        public void HatirlatmaTasklerininHepsiniSil()
        {
            TaskFolder tFolder = Hatirlatmalar.GetTaskFolder(ts);
            foreach (Microsoft.Win32.TaskScheduler.Task task in tFolder.Tasks)
            {
                tFolder.DeleteTask(task.Path, false);
            }
        }

        public async Task<bool> HatirlatmaTasklariniGuncelle()
        {
            List<bool> Durum = new List<bool>();
            List<Hatirlatma> htListe = await Hatirlatmalar.TumunuGetir(cm);
            if (htListe != null && ts != null)
            {
                TaskFolder tFolder = Hatirlatmalar.GetTaskFolder(ts);
                foreach (Hatirlatma ht in htListe)
                {
                    string taskPath = string.Format("{0}\\Hatirlatma({1})", tFolder, ht.Id);
                    Microsoft.Win32.TaskScheduler.Task task = ts.GetTask(taskPath);
                    if (task == null)
                    {
                        string notifyPath = Application.StartupPath + "\\GorusmeKayitlari.Reminder.Notify.exe";
                        Durum.Add(Hatirlatmalar.HatirlatmayiTaskOlarakEkle(ht, ts, tFolder, notifyPath));
                    }
                }
            }
            return !Durum.Contains(false);//herhangi bir hatırlatma eklenmediyse false dönsün diye
        }

        public void Dispose()
        {
            ts.Dispose();
            cm.Dispose();
        }
    }
}
