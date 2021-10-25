using GorusmeKayitlari.App.Formlar.DigerFormlar;
using GorusmeKayitlari.App.Formlar.NesneFormlari;
using GorusmeKayitlari.App.SingleInstancing;
using GorusmeKayitlari.Components;
using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.DB.Methods;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.MsgBox;
using GorusmeKayitlari.Extensions.Reminder.Formlar;
using GorusmeKayitlari.Updater.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace GorusmeKayitlari.App.Formlar
{
    public partial class MainForm : Form, IUpdatable, ISingleInstanceEnforcer
    {
        public MainForm(object[] Args)
        {
            InitializeComponent();
            OturumAyarla();
            _ConnMgrAyarla(Args);
            ProgramGuncellendiyse(Args);
        }

        Action loadislemleri = null;
        public ConnectionManager CmMain { get; set; }


        #region ISingleInstanceEnforcer Members

        public void OnMessageReceived(MessageEventArgs e)
        {
            string[] args = (string[])e.Message;

            //if (args.Length == 2 && args[0] == "/sw")
            //{
            //    this.BeginInvoke((MethodInvoker)delegate { downloadList1.NewDownloadFromData(args[1]); });
            //}
            //else
            //{
            //    downloadList1.AddDownloadURLs(ResourceLocation.FromURLArray(args), 1, null, 0);
            //}
        }
        public void HideForm()
        {
            this.ShowInTaskbar = false;
            this.Visible = false;
        }

        public void OnNewInstanceCreated(EventArgs e)
        {
            this.Focus();
        }

        #endregion

        #region ### AppUpdater Bölümü ###
        public string ApplicationName { get { return "Görüşme Kayıtları"; } }

        public string ApplicationID { get { return "GorusmeKayitlari"; } }

        public Assembly ApplicationAssembly { get { return Assembly.GetExecutingAssembly(); } }

        public Icon ApplicationIcon { get { return this.Icon; } }

        public Uri UpdateXmlLocation { get { return new Uri("http://noviceprog.esy.es/Gorusme-Kayitlari/update.xml"); } }

        public Form Context { get { return this; } }
        /// <summary>
        /// Program Güncellendiyse programın güncellendiğine dair açıklama yazısıyla birlikte bir mesaj kutusu görüntüler.
        /// </summary>
        /// <param name="args">Programın çalıştırma parametresi</param>
        public static bool _Guncellendimi(object[] args)
        {
            try
            {
                if (args != null && args.Length > 0)
                {
                    return args[0] != null && args[0].ToString() == "/guncellendi=true";
                }
                else { return false; }
            }
            catch (Exception ex) { Logger.Log(ex); return false; }
        }
        private void ProgramGuncellendiyse(object[] args)
        {
            if (_Guncellendimi(args))
            {
                this.loadislemleri = () =>
                {
                    string description = new GorusmeKayitlari.Updater.Classes.Updater(this).GuncellemeAciklamasiGetir();
                    MessageBox.Show(description, "Program Başarıyla Güncellendi.", MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
                };
            }
        }
        #endregion

        #region ### btnKategori ###

        private void BtnKategori_Ekle_Click(object sender, EventArgs e)
        {
            using (KategoriEkle keForm = new KategoriEkle(this.KullaniciOturumu))
            {
                try { keForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Kategori Ekleme Formu Gösterilirken Hata Oluştu!"); }
                if (keForm.DegisiklikYapildi)
                {
                    lstKategoriler.KategorileriYukle();
                }
            }
        }

        private void BtnKategori_Duzenle_Click(object sender, EventArgs e)
        {
            using (Formlar.NesneFormlari.SecmeFormlari.KategoriSec ksForm = new Formlar.NesneFormlari.SecmeFormlari.KategoriSec(this.KullaniciOturumu))
            {
                try { ksForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Kategori Seçme Formu Gösterilirken Hata Oluştu!"); }
                if (ksForm.SecilenNesne != null)
                {
                    using (KategoriEkle keForm = new KategoriEkle(ksForm.SecilenNesne, this.KullaniciOturumu))
                    {
                        try { keForm.ShowDialog(); }
                        catch (InvalidOperationException exx) { Logger.Log(exx); MsgBox.Hata(this, "Kategori Ekleme Formu Gösterilirken Hata Oluştu!"); }
                        if (keForm.DegisiklikYapildi)
                        {
                            lstKategoriler.KategorileriYukle();
                        }
                    }
                }
                //else
                //{
                //    MsgBox.Hata(this, "Kategori Seçilmedi!");
                //}
            }
        }

        private void BtnKategori_Sil_Click(object sender, EventArgs e)
        {
            _NesneSil(NesneTuru.Kategori);
        }
        #endregion

        #region ### btnKurum ###
        private void BtnKurum_Ekle_Click(object sender, EventArgs e)
        {
            using (KurumEkle keForm = new KurumEkle(this.KullaniciOturumu))
            {
                try { keForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Kurum Ekleme Formu Gösterilirken Hata Oluştu!"); }
            }
        }

        private async void BtnKurum_Duzenle_Click(object sender, EventArgs e)
        {
            using (NesneSec nsForm = new NesneSec(NesneTuru.Kurum, this.KullaniciOturumu))
            {
                try { nsForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Kurum Seçme Formu Gösterilirken Hata Oluştu!"); }
                if (nsForm.SecilenNesneId != -1)
                {
                    Kurum ilkkurum = await Kurumlar.Getir(nsForm.SecilenNesneId, App.Instance.ConnManager);
                    if (ilkkurum != null)
                    {
                        using (KurumEkle keForm = new KurumEkle(nsForm.SecilenNesneId, this.KullaniciOturumu))
                        {
                            try { keForm.ShowDialog(); }
                            catch (InvalidOperationException exx) { Logger.Log(exx); MsgBox.Hata(this, "Kurum Ekleme Formu Gösterilirken Hata Oluştu!"); }
                            if (keForm.DegisiklikYapildi)
                            {
                                Kurum kurum = await Kurumlar.Getir(keForm.NesneId, App.Instance.ConnManager);
                                if (kurum != null && lstKategoriler.SecilenNesne != null && lstKategoriler.SecilenNesne.Id != -1)
                                {
                                    Kategori tmpkategoriilk = ilkkurum.Kategori;
                                    Kategori tmpkategori = kurum.Kategori;
                                    while (tmpkategori.Id != 0 || tmpkategoriilk.Id != 0)
                                    {
                                        if (tmpkategori.Id == lstKategoriler.SecilenNesne.Id || tmpkategoriilk.Id == lstKategoriler.SecilenNesne.Id)
                                        {
                                            lstKurumlar.KurumlariYukle();
                                            break;
                                        }
                                        tmpkategori = tmpkategori.UstKategori;
                                        tmpkategoriilk = tmpkategoriilk.UstKategori;
                                    }
                                    //lstKurumlar._KurumlariYukle();
                                }
                            }
                        }
                    }
                }
                //else
                //{
                //    MsgBox.Hata(this, "Kurum Seçilmedi!");
                //}
            }
        }

        private void BtnKurum_Sil_Click(object sender, EventArgs e)
        {
            //TODO:Doldurulacak
        }
        #endregion

        #region ### btnYetkili ###
        private void BtnYetkili_Ekle_Click(object sender, EventArgs e)
        {
            using (YetkiliEkle yeForm = new YetkiliEkle(this.KullaniciOturumu))
            {
                try
                {
                    yeForm.ShowDialog();
                }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Yetkili Ekleme Formu Gösterilirken Hata Oluştu!"); }
            }
        }

        private void BtnYetkili_Duzenle_Click(object sender, EventArgs e)
        {
            using (NesneSec nsForm = new NesneSec(NesneTuru.Yetkili, this.KullaniciOturumu))
            {
                try { nsForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Yetkili Seçme Formu Gösterilirken Hata Oluştu!"); }
                if (nsForm.SecilenNesneId != -1)
                {
                    using (YetkiliEkle yeForm = new YetkiliEkle(nsForm.SecilenNesneId, this.KullaniciOturumu))
                    {
                        try { yeForm.ShowDialog(); }
                        catch (InvalidOperationException exx) { Logger.Log(exx); MsgBox.Hata(this, "Yetkili Ekleme Formu Gösterilirken Hata Oluştu!"); }
                    }
                }
                //else
                //{
                //    MsgBox.Hata(this, "Yetkili Seçilmedi!");
                //}
            }
        }

        private void BtnYetkili_Sil_Click(object sender, EventArgs e)
        {
            _NesneSil(NesneTuru.Yetkili);
        }
        #endregion

        #region ### btnKullanici ###
        private void BtnKullanici_Ekle_Click(object sender, EventArgs e)
        {
            using (KullaniciEkle keForm = new KullaniciEkle(this.KullaniciOturumu))
            {
                try { keForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Kullanıcı Ekleme Formu Gösterilirken Hata Oluştu!"); }
            }
        }

        private void BtnKullanici_Duzenle_Click(object sender, EventArgs e)
        {
            using (NesneSec nsForm = new NesneSec(NesneTuru.Kullanici, this.KullaniciOturumu))
            {
                try { nsForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Kullanıcı Seçme Formu Gösterilirken Hata Oluştu!"); }
                if (nsForm.SecilenNesneId != -1)
                {
                    using (KullaniciEkle keForm = new KullaniciEkle(nsForm.SecilenNesneId))
                    {
                        try { keForm.ShowDialog(); }
                        catch (InvalidOperationException exx) { Logger.Log(exx); MsgBox.Hata(this, "Kullanıcı Ekleme Formu Gösterilirken Hata Oluştu!"); }
                    }
                }
                //else
                //{
                //    MsgBox.Hata(this, "Kullanıcı Seçilmedi!");
                //}
            }
        }

        private void BtnKullanici_Sil_Click(object sender, EventArgs e)
        {
            _NesneSil(NesneTuru.Kullanici);
        }
        #endregion

        #region ### btnKullaniciHesabi ###

        private void BtnKullaniciHesabi_Ekle_Click(object sender, EventArgs e)
        {
            using (KullaniciHesapEkle kheForm = new KullaniciHesapEkle(this.KullaniciOturumu))
            {
                try { kheForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Kullanıcı Hesap Ekleme Formu Gösterilirken Hata Oluştu!"); }
            }
        }

        private void BtnKullaniciHesabi_Duzenle_Click(object sender, EventArgs e)
        {
            using (NesneSec nsForm = new NesneSec(NesneTuru.KullaniciHesabi, this.KullaniciOturumu))
            {
                try { nsForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Kullanıcı Hesabı Seçme Formu Gösterilirken Hata Oluştu!"); }
                if (nsForm.SecilenNesneId > 0)
                {
                    using (KullaniciHesapEkle keForm = new KullaniciHesapEkle(nsForm.SecilenNesneId, this.KullaniciOturumu))
                    {
                        try { keForm.ShowDialog(); }
                        catch (InvalidOperationException exx) { Logger.Log(exx); MsgBox.Hata(this, "Kullanıcı Hesabı Ekleme Formu Gösterilirken Hata Oluştu!"); }
                    }
                }
            }
        }

        private void BtnKullaniciHesabi_Sil_Click(object sender, EventArgs e)
        {
            _NesneSil(NesneTuru.KullaniciHesabi);
        }
        #endregion

        #region ### lstKurumlar ###
        private void LstKurumlar_EkleTiklandiginde(object sender, EventArgs e)
        {
            using (KurumEkle keForm = new KurumEkle(this.KullaniciOturumu))
            {
                try { keForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Kurum Ekleme Formu Gösterilirken Hata Oluştu!"); }
                if (keForm.DegisiklikYapildi) { lstKurumlar.KurumlariYukle(); }
            }
        }
        private void LstKurumlar_DuzenleTiklandiginde(object sender, Kurum e)
        {
            using (KurumEkle keForm = new KurumEkle(e, this.KullaniciOturumu))
            {
                try { keForm.ShowDialog(); }
                catch (InvalidOperationException ex) { MsgBox.Hata(this, "Kurum Düzenleme Formu Gösterilirken Hata Oluştu!"); Logger.Log(ex); }
                if (keForm.DegisiklikYapildi) { lstKurumlar.KurumlariYukle(); }
            }
        }
        private async void LstKurumlar_SilTiklandiginde(object sender, List<Kurum> e)
        {
            DialogResult drcevap = MsgBoxEx.YesNoCancel("Seçilen Kurum" + (e.Count == 1 ? "u" : "ları") + " Silmek İstediğinize Eminmisiniz?", "Evet, Görüşmelerinide Sil", "Evet", "Hayır");
            if (drcevap != DialogResult.Cancel)
            {
                bool degisiklikyapildi = false;
                //Kurum ile Beraber Görüşmeleride Silme veya sadece Kurum Silme seçilirse
                foreach (Kurum kurum in e)
                {
                    if (!(await Kurumlar.Sil(kurum.Id, App.Instance.ConnManager)))
                    {
                        MsgBox.Hata(this, "\"" + kurum.ToString() + "\" adlı kurum silinemedi!");
                    }
                    else
                    {
                        degisiklikyapildi = true;
                        if (drcevap == DialogResult.No)
                        {
                            //görüşmeleride sil demişse
                            List<Gorusme> gorusmeler = await Gorusmeler.TumunuGetir(kurum, App.Instance.ConnManager);
                            if (gorusmeler != null && gorusmeler.Count != 0)
                            {
                                foreach (Gorusme gorusme in gorusmeler)
                                {
                                    if (!(await Gorusmeler.Sil(gorusme.Id, App.Instance.ConnManager)))
                                    {
                                        MsgBox.Hata(this, "\'" + gorusme.Id + "\' idli görüşme silinemedi!");
                                    }
                                    else { degisiklikyapildi = true; }
                                }
                            }
                        }
                    }
                }
                if (degisiklikyapildi) { lstKurumlar.KurumlariYukle(); }
            }
        }
        private void LstKurumlar_GoruntuleTiklandiginde(object sender, List<Kurum> e)
        {
            if (e.Count >= 1)
            {
                KurumGoster kgForm;
                if (e.Count > 1) { kgForm = new KurumGoster(e, this.CmMain, this.KullaniciOturumu); }
                else { kgForm = new KurumGoster(e[0], this.CmMain, this.KullaniciOturumu); }
                try { kgForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Görüşme Gösterme Penceresi Açılırken Bir Hata Oluştu!"); }
            }
        }
        private void LstKurumlar_TumGoruntuleTiklandiginde(object sender, Kategori e)
        {
            using (KurumGoster kgForm = new KurumGoster(e, this.CmMain, this.KullaniciOturumu))
            {
                try { kgForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Görüşme Gösterme Penceresi Açılırken Bir Hata Oluştu!"); }
            }
        }
        private void LstKurumlar_KurumlarYuklenirken(object sender, YukleniyorkenArgs e)
        {
            if (KullaniciOturumu.OturumAcildi)
            {
                if (!KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KurumGoruntule))
                {
                    e.Data = "yetkisiz";
                    //MsgBox.Hata(this, "Kurum görüntüleme yetkiniz bulunmadığından bu işlem gerçekleştirilemez");
                    //e.Cancel = true;
                }
            }
            else { e.Cancel = true; }
        }
        #endregion

        #region ### lstKategoriler ###
        private void LstKategoriler_KategorilerYuklenirken(object sender, YukleniyorkenArgs e)
        {
            if (KullaniciOturumu.OturumAcildi)
            {
                if (!KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KategoriGoruntule))
                {
                    e.Data = "yetkisiz";
                    //MsgBox.Hata(this, "Kategori görüntüleme yetkiniz bulunmadığından bu işlem gerçekleştirilemez");
                    //e.Cancel = true;
                }
            }
            else { e.Cancel = true; }
        }
        private void LstKategoriler_KurumSecildiginde(object sender, TreeViewEventArgs e)
        {
            if (lstKategoriler.SecilenNesne != null)
            {
                lstKurumlar.KategoriId = lstKategoriler.SecilenNesne.Id;
                lstKurumlar.KurumlariYukle();
            }
        }
        private void LstKategoriler_KurumIsaretlendiginde(object sender, KurumListelemeModuArgs e)
        {
            List<int> KatIDler = new List<int>();
            foreach (Kategori kat in e.SecilenKategoriler)
            {
                KatIDler.Add(kat.Id);
            }
            lstKurumlar.KategoriIdler = KatIDler;
            lstKurumlar.KurumlariYukle();
        }
        private void LstKategoriler_EkleTiklandiginda(object sender, Kategori e)
        {
            using (KategoriEkle keForm = new KategoriEkle(this.KullaniciOturumu))
            {
                if (e != null) { keForm._UstKategoriAyarla(e); }
                try
                {
                    keForm.ShowDialog();
                }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Kategori Ekleme Formu Açılırken Hata Oluştu!"); }
                if (keForm.DegisiklikYapildi)
                {
                    lstKategoriler.KategorileriYukle();
                }
            }
        }

        private void LstKategoriler_DuzenleTiklandiginda(object sender, Kategori e)
        {
            if (e != null)
            {
                using (KategoriEkle keForm = new KategoriEkle(e, this.KullaniciOturumu))
                {
                    try { keForm.ShowDialog(); }
                    catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Kategori Düzenleme Formu Açılırken Hata Oluştu!"); }
                    if (keForm.DegisiklikYapildi)
                    {
                        lstKategoriler.KategorileriYukle();
                    }
                }
            }
        }

        private async void LstKategoriler_SilTiklandiginda(object sender, Kategori e)
        {
            if (e != null)
            {
                DialogResult drcevap = MsgBoxEx.YesNoCancel("'" + e.ToString() + "' adlı Kategoriyi Silmek İstediğinize Eminmisiniz?", "Evet, Alt Kategorileride Sil", "Evet", "Hayır");
                if (drcevap != DialogResult.Cancel)
                {
                    bool degisiklikyapildi = false;
                    bool sonuc = await Kategoriler.Sil(e.Id, App.Instance.ConnManager);
                    if (!sonuc)
                    {
                        MsgBox.Hata(this, "'" + e.ToString() + "' Adlı Kategori Silinemedi!");
                    }
                    else if (sonuc && drcevap == DialogResult.No)
                    { degisiklikyapildi = true; }
                    else if (sonuc && drcevap == DialogResult.Yes)
                    {
                        degisiklikyapildi = true;
                        //altkategorileride sil demişse
                        List<Kategori> kategoriler = await Kategoriler.UstKategoriIdeGoreTumunuGetir(e.Id, App.Instance.ConnManager);
                        if (kategoriler != null && kategoriler.Count != 0)
                        {
                            foreach (Kategori kategori in kategoriler)
                            {
                                bool _sonuc = await Kategoriler.Sil(kategori.Id, App.Instance.ConnManager);
                                if (!_sonuc)
                                {
                                    MsgBox.Hata(this, "'" + kategori.ToString() + "' Adlı Kategori Silinemedi!");
                                }
                                else { degisiklikyapildi = true; }
                            }
                        }
                    }
                    if (degisiklikyapildi) { lstKategoriler.KategorileriYukle(); }
                }
            }
        }

        private void LstKategoriler_KurumGosterimModuDegistiginde(object sender, Core.Components.KurumListelemeModuArgs e)
        {
            if (e.Mod == Core.Components.KurumListelemeModu.OzelSecim)
            {
                lstKurumlar.GosterimTuru = Core.Components.GosterimTuru.Coklu;
                List<int> KatIDler = new List<int>();
                foreach (Kategori kat in e.SecilenKategoriler)
                {
                    KatIDler.Add(kat.Id);
                }
                lstKurumlar.AltKategorilerDahil = e.altKategorilerDahil;
                lstKurumlar.KategoriIdler = KatIDler;
                lstKurumlar.KurumlariYukle();
            }
            else if (e.Mod == Core.Components.KurumListelemeModu.Tekli)
            {
                lstKurumlar.GosterimTuru = Core.Components.GosterimTuru.Tekli;
                lstKurumlar.KurumlariYukle();
            }
        }

        private void LstKategoriler_YenileTiklandiginda(object sender, EventArgs e)
        {
            lstKategoriler.KategorileriYukle();
        }
        #endregion

        #region ### lblKullaniciHesap ###
        private void LblKullaniciHesap_Click(object sender, EventArgs e)
        {
            if (KullaniciOturumu.OturumAcilanHesap != null)
            {
                KullaniciOturumu.OturumKapat();
            }
            OturumAcmaAyarla();
        }

        private void LblKullaniciHesap_MouseEnter(object sender, EventArgs e)
        {
            lblKullaniciHesap.Font = new Font(lblKullaniciHesap.Font, FontStyle.Underline);
            lblKullaniciHesap.ForeColor = Color.Blue;
        }

        private void LblKullaniciHesap_MouseLeave(object sender, EventArgs e)
        {
            lblKullaniciHesap.Font = new Font(lblKullaniciHesap.Font, FontStyle.Regular);
            lblKullaniciHesap.ForeColor = SystemColors.ControlText;
        }

        private void LblKullaniciHesap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //lblKullaniciHesap.Font = new Font(lblKullaniciHesap.Font, FontStyle.Underline);
                lblKullaniciHesap.ForeColor = Color.FromArgb(64, 0, 16);
            }
        }
        #endregion

        #region Oturum açma ile ilgili kodlar

        public Oturum KullaniciOturumu = null;
        Panel pnlOturum;
        GirisYap gy;

        private void OturumAyarla()
        {
            KullaniciOturumu = new Oturum();
            KullaniciOturumu.OturumAcildiginda += new EventHandler<KullaniciHesap>(App_Instance_OturumAcildiginda);
            KullaniciOturumu.OturumKapatildiginda += new EventHandler(App_Instance_OturumKapatildiginda);
        }

        private void BekleAdminGirisiYap()
        {
            Optimizasyon.ArkaplandaCalistir(() =>
            {
                System.Threading.Thread.Sleep(2000);
                DebugModuiseOturumAc();
            });
        }

        private void DebugModuiseOturumAc()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                KullaniciHesap hesap = new KullaniciHesap(
                    -1,
                    new Kullanici(
                        -1,
                        "Admin",
                        " ",
                        IletisimBilgileri.Bos,
                        string.Empty),
                    "Debug Modu",
                    string.Empty,
                    NesneYetkileri.None.TumunuGetir(),
                    DigerYetkiler.None.TumunuGetir(),
                    KullaniciHesapDurumu.Aktif,
                    DateTime.Now,
                    DateTime.Now,
                    KullaniciHesap.Bos,
                    string.Empty);
                KullaniciOturumu.OturumAc(hesap);
            }
        }

        private void _OturumFormuGoster()
        {
            if (pnlOturum == null)
            {
                pnlOturum = new Panel();
                gy = new GirisYap();
                gy.OturumAcilacaginda += new EventHandler<KullaniciHesap>(Gy_OturumAcilacaginda);
                Delegates.Size.Set(gy, Delegates.Size.Get(pnlOturum));
                Delegates.Location.Set(gy, Delegates.Location.Get(pnlOturum));
                Optimizasyon.Delagate(gy, () => { gy.BringToFront(); });
                Delegates.Dock.Set(gy, DockStyle.Fill);
                Delegates.Visible.Set(gy, true);
                Delegates.Size.Set(pnlOturum, Delegates.Size.Get(this));
                Delegates.Location.Set(pnlOturum, Delegates.Location.Get(this));
                Delegates.Dock.Set(pnlOturum, Delegates.Dock.Get(this));
                Delegates.Visible.Set(pnlOturum, true);
                Optimizasyon.Delagate(pnlOturum, () => { pnlOturum.Controls.Add(gy); });
                Optimizasyon.Delagate(this, () => { this.Controls.Add(pnlOturum); });
            }
            Optimizasyon.Delagate(gy.txtKulAd, () => { gy.txtKulAd.Focus(); });
        }

        private void OturumAcmaAyarla()
        {
            Optimizasyon.ArkaplandaCalistir(() => 
            {
                _OturumFormuGoster();
                _InitComponents();
            });
        }
        private void UpdateControls()
        {
            Optimizasyon.ArkaplandaCalistir(() =>
            {
                _UpdateControls();
            });
        }
        private void _UpdateControls()
        {
            Optimizasyon.Delagate(tsMain, () =>
            {
                btnAraclar.Visible = KullaniciOturumu.OturumAcildi;
                btnAraclar.Enabled = KullaniciOturumu.OturumAcildi;
                if (btnAraclar.Enabled)
                {
                    btnKategori.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KategoriGoruntule);
                    btnKategori_Ekle.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KategoriEkle);
                    btnKategori_Duzenle.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KategoriDuzenle);
                    btnKategori_Sil.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KategoriSil);
                    btnKurum.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KurumGoruntule);
                    btnKurum_Ekle.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KurumEkle);
                    btnKurum_Duzenle.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KurumDuzenle);
                    btnKurum_Sil.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KurumSil);
                    btnYetkili.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.YetkiliGoruntule);
                    btnYetkili_Ekle.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.YetkiliEkle);
                    btnYetkili_Duzenle.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.YetkiliDuzenle);
                    btnYetkili_Sil.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.YetkiliSil);
                    btnKullanici.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KullaniciGoruntule);
                    btnKullanici_Ekle.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KullaniciEkle);
                    btnKullanici_Duzenle.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KullaniciDuzenle);
                    btnKullanici_Sil.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KullaniciSil);
                    btnKullaniciHesabi.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KullaniciHesapGoruntuleme);
                    btnKullaniciHesabi_Ekle.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KullaniciHesapEkleme);
                    btnKullaniciHesabi_Duzenle.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KullaniciHesapDuzenleme);
                    btnKullaniciHesabi_Sil.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(NesneYetkileri.KullaniciHesapSilme);
                }
                btnEklenti.Enabled = KullaniciOturumu.OturumAcildi;
                btnEklenti.Visible = KullaniciOturumu.OturumAcildi;
                if (btnEklenti.Enabled)
                {
                    btnHatirlatici.Visible = KullaniciOturumu.OturumAcilanHesap.YetkileriAra(DigerYetkiler.HatirlatmaGoruntule);
                }
                btnYardim.Enabled = KullaniciOturumu.OturumAcildi;
                btnYardim.Visible = KullaniciOturumu.OturumAcildi;
                btnKulHesapAyar.Enabled = KullaniciOturumu.OturumAcildi;
                btnKulHesapAyar.Visible = KullaniciOturumu.OturumAcildi;
                btnKulHesapAyar.Tag = KullaniciOturumu.OturumAcilanHesap;
            });
            Optimizasyon.Delagate(splitContainer1, () =>
            {
                if (splitContainer1 != null)
                {
                    Delegates.Enabled.Set(splitContainer1, KullaniciOturumu.OturumAcildi);
                    Delegates.Visible.Set(splitContainer1, KullaniciOturumu.OturumAcildi);
                }
            });
            if (!KullaniciOturumu.OturumAcildi)
            {
                Optimizasyon.Delagate(lstKategoriler, () => { lstKategoriler?.Resetle(); });
                Optimizasyon.Delagate(lstKurumlar, () => { lstKurumlar?.Resetle(); });
            }
        }

        private void Gy_OturumAcilacaginda(object sender, KullaniciHesap e)
        {
            KullaniciOturumu.OturumAc(e);
        }

        public void App_Instance_OturumKapatildiginda(object sender, EventArgs e)
        {
            Optimizasyon.Delagate(lstKategoriler, () => { lstKategoriler.KulOturumu = null; });
            Optimizasyon.Delagate(lstKurumlar, () => { lstKurumlar.KullaniciOturumu = null; });
            lblKullaniciHesap.Text = "Oturum Açılmadı";
            lblKullaniciHesap.ToolTipText = "";
            UpdateControls();
        }

        public void App_Instance_OturumAcildiginda(object sender, KullaniciHesap e)
        {
            string kullanici = e.GetKullanici(App.Instance.ConnManager).ToString();
            lblKullaniciHesap.Text = string.Format("{0}({1})", kullanici, e.KullaniciAdi);
            lblKullaniciHesap.ToolTipText = "Çıkış yapmak için buraya tıklayın.";
            UpdateControls();
            Optimizasyon.Delagate(gy, () => { gy.Dispose(); });
            Optimizasyon.Delagate(pnlOturum, () => { pnlOturum.Dispose(); pnlOturum = null; });
            Optimizasyon.Delagate(pnlOturum, () => { pnlOturum.Dispose(); pnlOturum = null; });
            Optimizasyon.Delagate(lstKategoriler, () => { lstKategoriler.KulOturumu = this.KullaniciOturumu; lstKategoriler.KategorileriYukle(); });
            Optimizasyon.Delagate(lstKurumlar, () => { lstKurumlar.KullaniciOturumu = this.KullaniciOturumu; lstKurumlar.KurumlariYukle(); });
            if (splitContainer1 != null)
            {
                Optimizasyon.Delagate(splitContainer1, () =>
                {
                    this.splitContainer1.BringToFront();
                });
            }
        }
        #endregion

        #region ### Komponentleri Yükleme Kısmı ###

        private void _InitComponents()
        {
            Optimizasyon.Delagate(splitContainer1, () =>
            {
                if (splitContainer1 != null)
                {
                    splitContainer1.Dispose();
                    this.Controls.Remove(splitContainer1);
                }
            });
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            //Optimizasyon.Delagate(splitContainer1, () => { splitContainer1 = new SplitContainer(); });
            splitContainer1 = new SplitContainer();
            this.lstKategoriler = new Bilesenler.Liste();
            this.lstKurumlar = new Bilesenler.KurumListe();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            Optimizasyon.Delagate(splitContainer1, () => { this.splitContainer1.SuspendLayout(); });
            Optimizasyon.Delagate(this, () => { this.SuspendLayout(); });
            // 
            // splitContainer1
            // 
            Optimizasyon.Delagate(splitContainer1, () =>
            {
                this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.splitContainer1.Location = new System.Drawing.Point(0, 26);
                this.splitContainer1.Name = "splitContainer1";
            });
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstKategoriler);
            this.splitContainer1.Panel1MinSize = 150;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstKurumlar);
            this.splitContainer1.Panel2MinSize = 200;
            this.splitContainer1.Size = new System.Drawing.Size(716, 311);
            this.splitContainer1.SplitterDistance = 172;
            this.splitContainer1.TabIndex = 5;
            // 
            // lstKategoriler
            // 
            Optimizasyon.Delagate(lstKategoriler, () =>
            {
                this.lstKategoriler.Dock = System.Windows.Forms.DockStyle.Fill;
                this.lstKategoriler.Location = new System.Drawing.Point(0, 0);
                this.lstKategoriler.Name = "lstKategoriler";
                this.lstKategoriler.Size = new System.Drawing.Size(172, 311);
                this.lstKategoriler.TabIndex = 3;
                this.lstKategoriler.KurumSecildiginde += new System.EventHandler<System.Windows.Forms.TreeViewEventArgs>(this.LstKategoriler_KurumSecildiginde);
                this.lstKategoriler.KurumIsaretlendiginde += new System.EventHandler<GorusmeKayitlari.Core.Components.KurumListelemeModuArgs>(this.LstKategoriler_KurumIsaretlendiginde);
                this.lstKategoriler.EkleTiklandiginda += new System.EventHandler<GorusmeKayitlari.Core.DB.Objects.Kategori>(this.LstKategoriler_EkleTiklandiginda);
                this.lstKategoriler.DuzenleTiklandiginda += new System.EventHandler<GorusmeKayitlari.Core.DB.Objects.Kategori>(this.LstKategoriler_DuzenleTiklandiginda);
                this.lstKategoriler.SilTiklandiginda += new System.EventHandler<GorusmeKayitlari.Core.DB.Objects.Kategori>(this.LstKategoriler_SilTiklandiginda);
                this.lstKategoriler.YenileTiklandiginda += new System.EventHandler(this.LstKategoriler_YenileTiklandiginda);
                this.lstKategoriler.KurumGosterimModuDegistiginde += new System.EventHandler<GorusmeKayitlari.Core.Components.KurumListelemeModuArgs>(this.LstKategoriler_KurumGosterimModuDegistiginde);
                this.lstKategoriler.KategorilerYuklenirken += new System.EventHandler<GorusmeKayitlari.Core.DB.Objects.YukleniyorkenArgs>(this.LstKategoriler_KategorilerYuklenirken);
            });
            // 
            // lstKurumlar
            // 
            Optimizasyon.Delagate(lstKurumlar, () =>
            {
                this.lstKurumlar.AltKategorilerDahil = true;
                this.lstKurumlar.Dock = System.Windows.Forms.DockStyle.Fill;
                this.lstKurumlar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
                this.lstKurumlar.GosterimTuru = GorusmeKayitlari.Core.Components.GosterimTuru.Tekli;
                this.lstKurumlar.KategoriId = -1;
                this.lstKurumlar.KategoriIdler = null;
                this.lstKurumlar.Location = new System.Drawing.Point(0, 0);
                this.lstKurumlar.Name = "lstKurumlar";
                this.lstKurumlar.Size = new System.Drawing.Size(540, 311);
                this.lstKurumlar.TabIndex = 4;
                this.lstKurumlar.GoruntuleTiklandiginde += new System.EventHandler<System.Collections.Generic.List<GorusmeKayitlari.Core.DB.Objects.Kurum>>(this.LstKurumlar_GoruntuleTiklandiginde);
                this.lstKurumlar.EkleTiklandiginde += new System.EventHandler(this.LstKurumlar_EkleTiklandiginde);
                this.lstKurumlar.DuzenleTiklandiginde += new System.EventHandler<GorusmeKayitlari.Core.DB.Objects.Kurum>(this.LstKurumlar_DuzenleTiklandiginde);
                this.lstKurumlar.SilTiklandiginde += new System.EventHandler<System.Collections.Generic.List<GorusmeKayitlari.Core.DB.Objects.Kurum>>(this.LstKurumlar_SilTiklandiginde);
                this.lstKurumlar.TumGoruntuleTiklandiginde += new System.EventHandler<GorusmeKayitlari.Core.DB.Objects.Kategori>(this.LstKurumlar_TumGoruntuleTiklandiginde);
                this.lstKurumlar.KurumlarYuklenirken += new System.EventHandler<GorusmeKayitlari.Core.DB.Objects.YukleniyorkenArgs>(this.LstKurumlar_KurumlarYuklenirken);
            });
            Optimizasyon.Delagate(splitContainer1, () =>
            {
                this.splitContainer1.Panel1.ResumeLayout(false);
                this.splitContainer1.Panel2.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
                this.splitContainer1.ResumeLayout(false);
            });
            Optimizasyon.Delagate(this, () =>
            {
                this.ResumeLayout(false);
                this.Controls.Add(this.splitContainer1);
                this.PerformLayout();
            });
        }

        #region üyeler
        private Bilesenler.Liste lstKategoriler;
        private Bilesenler.KurumListe lstKurumlar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        #endregion

        #endregion

        private async void _NesneSil(NesneTuru Tur)
        {
            using (NesneSec nsForm = new NesneSec(Tur, this.KullaniciOturumu))
            {
                try { nsForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, NesneTuruAraclari.NesneTuruToString(Tur) + " Seçme Formu Gösterilirken Hata Oluştu!"); }
                if (nsForm.SecilenNesneId != -1)
                {
                    switch (Tur)
                    {
                        case NesneTuru.Yetkili:
                            Yetkili tmpadicinyet = await Yetkililer.Getir(nsForm.SecilenNesneId, App.Instance.ConnManager);
                            if (MsgBoxEx.YesNoCancel("'" + (tmpadicinyet != null ? tmpadicinyet.ToString() + "' adlı" : nsForm.SecilenNesneId.ToString()) + " Yetkiliyi Silmek İstediğinize Eminmisiniz?", "Evet, Görüşmelerinide Sil", "Evet", "Hayır") != DialogResult.Cancel)
                            {
                                bool sonuc = await Yetkililer.Sil(nsForm.SecilenNesneId, App.Instance.ConnManager);
                                if (sonuc) { MsgBox.Bilgi(this, "Yetkili Silindi!"); }
                                else { MsgBox.Hata(this, "Yetkili Silinemedi!"); }
                                List<Gorusme> gorusmeler = await Gorusmeler.TumunuGetir(new Yetkili(nsForm.SecilenNesneId), App.Instance.ConnManager);
                                if (gorusmeler != null && gorusmeler.Count != 0)
                                {
                                    foreach (Gorusme gorusme in gorusmeler)
                                    {
                                        if (!(await Gorusmeler.Sil(gorusme.Id, App.Instance.ConnManager)))
                                        {
                                            MsgBox.Hata(this, "\'" + gorusme.Id + "\' idli görüşme silinemedi!");
                                        }
                                    }
                                }
                            }
                            break;
                        case NesneTuru.Kullanici:
                            Kullanici tmpadicinkul = await Kullanicilar.Getir(nsForm.SecilenNesneId, App.Instance.ConnManager);
                            if (MsgBoxEx.YesNoCancel("'" + (tmpadicinkul != null ? tmpadicinkul.ToString() + "' adlı" : nsForm.SecilenNesneId.ToString() + "' idli") + " Kullanıcıyı Silmek İstediğinize Eminmisiniz?", "Evet, Görüşmelerinide Sil", "Evet", "Hayır") != DialogResult.Cancel)
                            {
                                bool sonuc = await Kullanicilar.Sil(nsForm.SecilenNesneId, App.Instance.ConnManager);
                                if (sonuc) { MsgBox.Bilgi(this, "Kullanıcı Silindi!"); }
                                else { MsgBox.Hata(this, "Kullanıcı Silinemedi!"); }
                                List<Gorusme> gorusmeler = await Gorusmeler.TumunuGetir(new Kullanici(nsForm.SecilenNesneId), App.Instance.ConnManager);
                                if (gorusmeler != null && gorusmeler.Count != 0)
                                {
                                    foreach (Gorusme gorusme in gorusmeler)
                                    {
                                        if (!(await Gorusmeler.Sil(gorusme.Id, App.Instance.ConnManager)))
                                        {
                                            MsgBox.Hata(this, "\'" + gorusme.Id + "\' idli görüşme silinemedi!");
                                        }
                                    }
                                }
                            }
                            break;
                        case NesneTuru.Kurum:
                            Kurum tmpadicinkur = await Kurumlar.Getir(nsForm.SecilenNesneId, App.Instance.ConnManager);
                            if (MsgBoxEx.YesNoCancel("'" + (tmpadicinkur != null ? tmpadicinkur.ToString() + "' adlı" : nsForm.SecilenNesneId.ToString() + "' idli") + " Kurumu Silmek İstediğinize Eminmisiniz?", "Evet, Görüşmelerinide Sil", "Evet", "Hayır") != DialogResult.Cancel)
                            {
                                bool sonuc = await Kurumlar.Sil(nsForm.SecilenNesneId, App.Instance.ConnManager);
                                if (sonuc) { MsgBox.Bilgi(this, "Kurum Silindi!"); lstKategoriler.KategorileriYukle(); }
                                else { MsgBox.Hata(this, "Kurum Silinemedi!"); }
                                List<Gorusme> gorusmeler = await Gorusmeler.TumunuGetir(new Kurum(nsForm.SecilenNesneId), App.Instance.ConnManager);
                                if (gorusmeler != null && gorusmeler.Count != 0)
                                {
                                    foreach (Gorusme gorusme in gorusmeler)
                                    {
                                        if (!(await Gorusmeler.Sil(gorusme.Id, App.Instance.ConnManager)))
                                        {
                                            MsgBox.Hata(this, "\'" + gorusme.Id + "\' idli görüşme silinemedi!");
                                        }
                                    }
                                }
                            }
                            break;
                        case NesneTuru.Kategori:
                            Kategori tmpadicinkat = await Kategoriler.Getir(nsForm.SecilenNesneId, App.Instance.ConnManager);
                            if (MsgBox.Soru(this, "'" + (tmpadicinkat != null ? tmpadicinkat.ToString() + "' adlı" : nsForm.SecilenNesneId.ToString() + "' idli") + " Kategoriyi Silmek istediğinize Eminmisiniz?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                bool sonuc = await Kategoriler.Sil(nsForm.SecilenNesneId, App.Instance.ConnManager);
                                if (sonuc) { MsgBox.Bilgi(this, "Kategori Silindi!"); lstKategoriler.KategorileriYukle(); }
                                else { MsgBox.Hata(this, "Kategori Silinemedi!"); }
                            }
                            break;
                        default:
                            break;
                    }
                }
                //else
                //{
                //    MsgBox.Hata(this, "Nesne Seçilmedi!");
                //}
            }
        }

        private void _ConnMgrAyarla(object[] Args)
        {
            foreach (object arg in Args)
            {
                if (arg is ConnectionManager)
                {
                    this.CmMain = arg as ConnectionManager;
                }
            }
        }

        private void BtnGuncDenetle_Click(object sender, EventArgs e)
        {
            using (Updater.Classes.Updater updater = new Updater.Classes.Updater(this))
            {
                updater.GuncellemeYap(true);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (loadislemleri != null)
            {
                loadislemleri();
                loadislemleri = null;
            }
            using (Updater.Classes.Updater updater = new Updater.Classes.Updater(this))
            {
                updater.GuncellemeYap(false);
            }
            UpdateControls();
        }

        private void BtnHakkinda_Click(object sender, EventArgs e)
        {
            using (Hakkinda hForm = new Hakkinda())
            {
                try { hForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Hakkında Formu Açılırken Hata Oluştu!"); }
            }
        }

        private void BtnAyarlar_Click(object sender, EventArgs e)
        {
            using (Ayarlar aForm = new Ayarlar())
            {
                try { aForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Ayarlar Formu Açılırken Hata Oluştu!"); }
            }
        }


        private void MainForm_Shown(object sender, EventArgs e)
        {
            OturumAcmaAyarla();
            BekleAdminGirisiYap();
        }

        private void BtnKulHesapAyar_Click(object sender, EventArgs e)
        {
            KullaniciHesap hesap = KullaniciOturumu.OturumAcilanHesap;
            using (KullaniciHesapEkle frmKullaniciHesap = new KullaniciHesapEkle(hesap, this.KullaniciOturumu))
            {
                try
                {
                    frmKullaniciHesap.ShowDialog();
                    if (frmKullaniciHesap.DegisiklikYapildi)
                    {
                        if (frmKullaniciHesap.DegisiklikYapildi)
                        {
                            KullaniciOturumu.OturumKapat();
                        }
                        if (!frmKullaniciHesap.Silindi)//hesap silinmediyse tekrar oturum aç
                        {
                            KullaniciOturumu.OturumAc(frmKullaniciHesap.Hesap);
                        }
                    }
                }
                catch (Exception ex) { Logger.Log(ex); MsgBox.Hata(this, "Kullanıcı Hesap penceresi açılırken bir hata oluştu!"); throw; }
            }
        }

        private void BtnVeritabaniDisaAktar_Click(object sender, EventArgs e)
        {
            //TODO:Veritabanını gözatla dışarı aktarma için gerekli kodlar yazılacak
        }

        private void BtnLisans_Click(object sender, EventArgs e)
        {
            //TODO:Lisans Penceresi Açılıacak ve o pencerede de lisans bilgileri gösterilecek.
        }

        private void BtnVeritabaniOtoYedekle_Click(object sender, EventArgs e)
        {
            //TODO:Veritabanını otomatik yedeklemek için google drive onedrive apileri ile bulut yedekleme yapılacak
        }


        private void BtnHatirlatici_Click(object sender, EventArgs e)
        {
            using (HatirlatmaListesi hForm = new HatirlatmaListesi(KullaniciOturumu))
            {
                hForm.ShowDialog();
            }
        }
    }
}

