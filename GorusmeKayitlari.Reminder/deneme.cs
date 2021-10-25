using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using GorusmeKayitlari.Core.DB;
using Microsoft.Win32.TaskScheduler;

namespace GorusmeKayitlari.Reminder
{
    public partial class deneme : Form
    {
        ConnectionManager cm;
        public deneme(ConnectionManager cm)
        {
            InitializeComponent();
            this.cm = cm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HatirlatmayiTaskOlarakEkle(int.Parse(textBox1.Text));
        }

        private async void HatirlatmayiTaskOlarakEkle(int Id)
        {
            Hatirlatma ht = await Hatirlatmalar.Getir(Id, cm);
            if (ht != null)
            {
                using (TaskService ts = new TaskService())
                {
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Görüşme Kayıtları - Hatırlatıcı";
                    td.Triggers.Add(new TimeTrigger() { StartBoundary = ht.Tarih });
                    string taskname = "Hatirlatma(" + Id.ToString() + ")";
                    string path = Application.StartupPath + "\\GorusmeKayitlari.Reminder.Notify.exe";
                    string arg = string.Format("/htID:{0} /taskname=\"{1}\"", Id, taskname);
                    ExecAction act = new ExecAction(path, arg, null);
                    td.Actions.Add(act);
                    TaskFolder folder = GetTaskFolder(ts);
                    if (folder != null)
                    {
                        folder.RegisterTaskDefinition(taskname, td);
                    }
                    else { throw new Exception("Hatırlatma Eklenemedi!"); }
                }
            }
        }

        private TaskFolder GetTaskFolder(TaskService ts)
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

    }
}
