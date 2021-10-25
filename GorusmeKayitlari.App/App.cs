using GorusmeKayitlari.App.Formlar;
using GorusmeKayitlari.App.Formlar.DigerFormlar;
using GorusmeKayitlari.App.SingleInstancing;
using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.Extension;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.UI;
using GorusmeKayitlari.Extensions.Database;
using GorusmeKayitlari.Extensions.InterviewExporter;
using GorusmeKayitlari.Extensions.Logger;
using GorusmeKayitlari.Extensions.Reminder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GorusmeKayitlari.App
{
    [Serializable]
    class App : IApp
    {
        #region Singleton

        private static App instance = new App();

        public static App Instance
        {
            get
            {
                return instance;
            }
        }

        private App()
        {
            AppManager.Instance.Initialize(this);
            extensions = new List<IExtension>
            {
                new LoggerExtension(),
                new DatabaseExtension(),
                new InterviewExporterExtension(),
                new ReminderExtension()
            };
        }

        #endregion

        #region Fields
        private List<IExtension> extensions;
        private SingleInstanceTracker tracker = null;
        private bool disposed = false;
        private ConnectionManager _ConnManager;
        public ConnectionManager ConnManager => GetConnManager();

        #endregion

        #region Properties

        public Form MainForm
        {
            get
            {
                return (Formlar.MainForm)tracker.Enforcer;
            }
        }

        public NotifyIcon NotifyIcon
        {
            get
            {
                return ((Formlar.MainForm)MainForm).notifyIcon;
            }
        }

        public List<IExtension> Extensions
        {
            get
            {
                return extensions;
            }
        }

        #endregion

        #region Methods

        private ConnectionManager GetConnManager()
        {
            if (this._ConnManager == null)
            {
                this._ConnManager = ConnectionManager.Instance;
            }
            return this._ConnManager;
        }


        public IExtension GetExtensionByType(Type type)
        {
            for (int i = 0; i < this.extensions.Count; i++)
            {
                if (this.extensions[i].GetType() == type)
                {
                    return this.extensions[i];
                }
            }

            return null;
        }

        private ISingleInstanceEnforcer GetSingleInstanceEnforcer(object[] EnforcerArgs)
        {
            List<object> args = new List<object>(EnforcerArgs);
            args.Add(GetConnManager());
            return new MainForm(args.ToArray());
        }

        public void InitExtensions()
        {
            for (int i = 0; i < Extensions.Count; i++)
            {
                if (Extensions[i] is IInitializable)
                {
                    ((IInitializable)Extensions[i]).Init();
                }
            }

        }
        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                for (int i = 0; i < Extensions.Count; i++)
                {
                    if (Extensions[i] is IDisposable)
                    {
                        try
                        {
                            ((IDisposable)Extensions[i]).Dispose();
                        }
                        catch (Exception ex)
                        {
                            Logger.Log(ex);
                        }
                    }
                }
                _ConnManager?.Dispose();
            }
        }

        public void Start(object[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (_GerekliBilesenleriAyarla())
            {
                try
                {
                    // Attempt to create a tracker
                    tracker = new SingleInstanceTracker("SingleInstanceSample",
                        new SingleInstanceEnforcerRetriever(GetSingleInstanceEnforcer), args);

                    // If this is the first instance of the application, run the main form
                    if (tracker.IsFirstInstance)
                    {
                        try
                        {
                            MainForm form = (MainForm)tracker.Enforcer;


                            //form.downloadList1.AddDownloadURLs(ResourceLocation.FromURLArray(args), 1, null, 0);

                            if (Array.IndexOf<object>(args, "/as") >= 0)
                            {
                                form.WindowState = FormWindowState.Minimized;
                            }

                            form.Load += delegate (object sender, EventArgs e)
                            {
                                InitExtensions();

                                if (form.WindowState == FormWindowState.Minimized)
                                {
                                    form.HideForm();
                                }

                                if (args.Length > 0)
                                {
                                    form.OnMessageReceived(new MessageEventArgs(args));
                                }
                            };

                            form.FormClosing += delegate (object sender, FormClosingEventArgs e)
                            {
                                Dispose();
                            };

                            Application.Run(form);
                        }
                        finally
                        {
                            Dispose();
                        }
                    }
                    else
                    {
                        // This is not the first instance of the application, so do nothing but send a message to the first instance
                        if (args.Length > 0)
                        {
                            tracker.SendMessageToFirstInstance(args);
                        }
                    }
                }
                catch (SingleInstancingException ex)
                {
                    MessageBox.Show("Could not create a SingleInstanceTracker object:\n" + ex.Message + "\nApplication will now terminate.\n" + ex.InnerException.ToString());

                    return;
                }
                finally
                {
                    if (tracker != null)
                        tracker.Dispose();
                }
            }
        }
        static bool _GerekliBilesenleriAyarla()
        {
            bool ayarlandi = false;
            Gereksinimler.FixTaskSchAccDenied();
            ayarlandi = _RegeditAyarla();
            ayarlandi = _CheckDBFile();
            return ayarlandi;
        }


        static bool _CheckDBFile()
        {
            string databasefile = string.Format("{0}\\{1}", Regedit.Ayar_Oku("Database-Path", "", Regedit.rkMain, false), Regedit.Ayar_Oku("Database-File-Name", "", Regedit.rkMain, false));
            if (!File.Exists(databasefile))
            {
                using (DatabaseForm frmDB = new DatabaseForm())
                {
                    frmDB.ShowDialog();
                }
                databasefile = string.Format("{0}\\{1}", Regedit.Ayar_Oku("Database-Path", "", Regedit.rkMain, false), Regedit.Ayar_Oku("Database-File-Name", "", Regedit.rkMain, false));
                return File.Exists(databasefile);
            }
            else { return true; }
        }
        static bool _RegeditAyarla()
        {
            try
            {
                Regedit.rkMain = Regedit.GetMainRegKey();
                return Regedit.rkMain != null;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return false;
            }
        }
        #endregion
    }
}
