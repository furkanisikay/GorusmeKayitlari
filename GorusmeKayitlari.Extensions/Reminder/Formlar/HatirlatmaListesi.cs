using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.MsgBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorusmeKayitlari.Extensions.Reminder.Formlar
{
    public partial class HatirlatmaListesi : Form, IListeliControl
    {
        #region Members
        HatirlatmaTask HTask { get; }
        internal ConnectionManager CmHatirlatmalar { get; }
        
        private Oturum KullaniciOturumu { get; }
        #endregion

        #region  Constructor
        public HatirlatmaListesi(Oturum KullaniciOturum)
        {
            InitializeComponent();
            BW();//BackgroundWorker i ayarlamak için
            this.KullaniciOturumu = KullaniciOturum;
            this.HTask = new HatirlatmaTask();
            CmHatirlatmalar = ConnectionManager.Instance;
        }
        #endregion

        #region BtnHatirlatma Ekle-Güncelle-Sil Kodları

        private void BtnHatirlatmaEkle_Click(object sender, EventArgs e)
        {
            using (HatirlatmaEkle heForm = new HatirlatmaEkle(KullaniciOturumu))
            {
                try { heForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Core.Extensions.Logger.Log(ex); MsgBox.Hata(this, "Hatırlatma Ekleme Formu Gösterilirken Hata Oluştu!"); }
                if (heForm.DegisiklikYapildi)
                {
                    HTask.TaskleriYenidenYukle();
                    HatirlatmalariYukle();
                }
            }
        }

        private void BtnHatirlatmaDuzenle_Click(object sender, EventArgs e)
        {
            List<ListViewItem> secilenlistesi = _SecilenItemleriGetir();
            if (secilenlistesi != null)
            {
                if (secilenlistesi.Count == 1)
                {
                    using (HatirlatmaEkle heForm = new HatirlatmaEkle((secilenlistesi[0].Tag as Hatirlatma), KullaniciOturumu))
                    {
                        try { heForm.ShowDialog(); }
                        catch (InvalidOperationException exx) { Core.Extensions.Logger.Log(exx); MsgBox.Hata(this, "Hatırlatma Ekleme Formu Gösterilirken Hata Oluştu!"); }
                        if (heForm.DegisiklikYapildi)
                        {
                            HTask.TaskleriYenidenYukle();
                            if (heForm.Silindi)
                            {
                                ItemSil(secilenlistesi[0].Index);
                                Hatirlatmalar.HatirlatmayiTasklerdenSil(heForm.DuzenlenmisHatirlatma);
                            }
                            else
                            {
                                ItemDuzenle(secilenlistesi[0].Index, heForm.DuzenlenmisHatirlatma);
                                Hatirlatmalar.HatirlatmayiTasklerdeGuncelle(heForm.DuzenlenmisHatirlatma, HatirlatmaTask.NotifyPath);
                            }
                        }
                    }
                }
                else { MsgBox.Hata(this, "Lütfen düzenlemek için sadece bir hatırlatma seçin"); }
            }
        }

        private async void BtnHatirlatmaSil_Click(object sender, EventArgs e)
        {
            List<ListViewItem> secilenlistesi = _SecilenItemleriGetir();
            if (secilenlistesi != null)
            {
                if (secilenlistesi.Count >= 1)
                {
                    DialogResult drcevap = MsgBox.Soru(this, "Seçilen Hatırlatma" + (secilenlistesi.Count > 1 ? "ları" : "yı") + " Silmek İstediğinize Eminmisiniz?",MessageBoxButtons.YesNo);
                    if (drcevap == DialogResult.Yes)
                    {
                        //bool degisiklikyapildi = false;
                        bool sonuc = false;
                        foreach (ListViewItem item in secilenlistesi)
                        {
                            int id = (item.Tag as Hatirlatma).Id;
                            sonuc = await Hatirlatmalar.Sil(id, CmHatirlatmalar);
                            if (!sonuc)
                            {
                                MsgBox.Hata(this, "'" + id.ToString() + "' Id'li Hatırlatma Silinemedi!");
                            }
                            else
                            {
                                ItemSil(item.Index);
                                Hatirlatmalar.HatirlatmayiTasklerdenSil(item.Tag as Hatirlatma);
                                //degisiklikyapildi = true;
                            }
                        }
                        //if (degisiklikyapildi)
                        //{
                        //    HTask.TaskleriYenidenYukle();
                        //    HatirlatmalariYukle();
                        //}
                    }
                }
            }
        }

        private void btnListeyiYenile_Click(object sender, EventArgs e)
        {
            HatirlatmalariYukle();
        }

        #endregion

        #region IListeliControl metodları
        void IListeliControl.ListeyiTemizle()
        {
            Optimizasyon.Delagate(lstHatirlatmalar, () =>
            {
                lstHatirlatmalar.Items.Clear();
            });
        }
        #region Listeye Ekleme Kodları
        void IListeliControl.ListeyeEkle<T>(T nesne)
        {
            if (nesne is Hatirlatma)
            {
                Hatirlatma hatirlatma = nesne as Hatirlatma;
                if (hatirlatma != null)
                {
                    DataListViewItem item = HatirlatmaToItem(hatirlatma);
                    if (item != null)
                    {
                        Optimizasyon.Delagate(lstHatirlatmalar, () => { lstHatirlatmalar.Items.Add(item); });
                    }
                }
            }
        }
        void IListeliControl.ListeyeEkle<T>(List<T> nesneler)
        {
            if (nesneler is List<Hatirlatma>)
            {
                List<Hatirlatma> hatirlatmalar = nesneler as List<Hatirlatma>;
                if (hatirlatmalar != null)
                {
                    List<DataListViewItem> gelecekHatItemleri = new List<DataListViewItem>();
                    List<DataListViewItem> gecmisHatItemleri = new List<DataListViewItem>();
                    foreach (Hatirlatma hatirlatma in hatirlatmalar)
                    {
                        if (bwHatirlatmalariYukle.CancellationPending) { break; }
                        DataListViewItem item = HatirlatmaToItem(hatirlatma);
                        if (item != null)
                        {
                            if(DateTime.Compare(hatirlatma.Tarih,DateTime.Now)>0)
                            {
                                gelecekHatItemleri.Add(item);
                            }
                            else
                            {
                                gecmisHatItemleri.Add(item);
                            }
                        }
                    }
                    if(gelecekHatItemleri.Count >= 1)
                    {
                        ListViewGroup gelecek = new ListViewGroup("Gelecek Hatırlatmalar");
                        foreach (DataListViewItem item in gelecekHatItemleri)
                        {
                            item.Group = gelecek;
                        }
                        Optimizasyon.Delagate(lstHatirlatmalar, () => { lstHatirlatmalar.Groups.Add(gelecek); });
                    }
                    if (gecmisHatItemleri.Count >= 1)
                    {
                        ListViewGroup gecmis = new ListViewGroup("Geçmiş Hatırlatmalar");
                        foreach (DataListViewItem item in gecmisHatItemleri)
                        {
                            item.Group = gecmis;
                        }
                        Optimizasyon.Delagate(lstHatirlatmalar, () => { lstHatirlatmalar.Groups.Add(gecmis); });
                    }
                    if (bwHatirlatmalariYukle.CancellationPending)
                    {
                        ((IListeliControl)this).ListeyeEkle(((IListeliControl)this).BosNesneOlustur("Hatırlatma bulunamadı"));
                    }
                    else
                    {
                        Optimizasyon.Delagate(lstHatirlatmalar, () => { lstHatirlatmalar.Items.AddRange(gecmisHatItemleri.ToArray()); });
                        Optimizasyon.Delagate(lstHatirlatmalar, () => { lstHatirlatmalar.Items.AddRange(gelecekHatItemleri.ToArray()); });
                    }
                }
            }
        }
        private void Gruplamalari_Ayarla()
        {
            
        }

        DataListViewItem HatirlatmaToItem(Hatirlatma hatirlatma)
        {
            if (hatirlatma != null)
            {
                DataListViewItem item = new DataListViewItem(hatirlatma)
                {
                    Tag = hatirlatma,
                    Name = "_lstHatirlatmalar_" + hatirlatma.Id.ToString(),
                    Text = hatirlatma.Metin,
                    ToolTipText = hatirlatma.Metin,
                };
                string tarih = string.Empty;
                if (hatirlatma.Id != -1)
                {
                    tarih = string.Format("{0} - {1}", hatirlatma.Tarih.ToShortDateString(), hatirlatma.Tarih.ToLongTimeString());
                }
                else { tarih = "-"; }
                item.SubItems.Add(tarih);
                return item;
            }
            else { return null; }
        }
        #endregion

        async void IListeliControl.ListeyiYukle()
        {
            List<Hatirlatma> hatirlatmalar = await Hatirlatmalar.TumunuGetir(CmHatirlatmalar);
            if (hatirlatmalar != null && hatirlatmalar.Count != 0)
            {
                ((IListeliControl)this).ListeyeEkle(hatirlatmalar);
            }
            else
            {
                ((IListeliControl)this).ListeyeEkle(((IListeliControl)this).BosNesneOlustur("Hatırlatma bulunamadı"));
            }
        }

        object IListeliControl.BosNesneOlustur(string ad)
        {
            return new Hatirlatma(-1, ad, DateTime.Now);
        }

        bool IListeliControl._ListeBosDegilse()
        {
            bool durum = false;
            Optimizasyon.Delagate(lstHatirlatmalar, () => { durum = (lstHatirlatmalar?.Items?.Count != 0 && _IsNotBulunamadi(lstHatirlatmalar?.Items?[0])); });
            return durum;
        }
        #endregion

        #region Diğer Kodlar
        private void ItemDuzenle(int index, Hatirlatma ht)
        {
            Optimizasyon.Delagate(lstHatirlatmalar, () =>
             {
                 DataListViewItem item = HatirlatmaToItem(ht);
                 lstHatirlatmalar.Items.RemoveAt(index);
                 lstHatirlatmalar.Items.Insert(index, item);
             });
        }
        private void ItemSil(int index)
        {
            Optimizasyon.Delagate(lstHatirlatmalar, () =>
            {
                lstHatirlatmalar.Items.RemoveAt(index);
            });
        }


        private bool _IsNotBulunamadi(ListViewItem item)
        {
            return item != null
                && item.Tag != null
                && item.Tag is Hatirlatma
                && (item.Tag as Hatirlatma).Id > 0
                && !string.IsNullOrEmpty(item.Name)
                && item.Name.StartsWith("_lstHatirlatmalar_")
                && item.Name.Remove(0, "_lstHatirlatmalar_".Length) != "-1";
        }

        private bool _SecileniDogrula()
        {
            return lstHatirlatmalar?.SelectedItems != null && lstHatirlatmalar?.SelectedItems?.Count != 0 && _ItemiDogrula(lstHatirlatmalar?.SelectedItems[0]);
        }
        private bool _ItemiDogrula(ListViewItem item)
        {
            return item != null && item.Tag != null && item.Tag is Hatirlatma;
        }
        private List<ListViewItem> _SecilenItemleriGetir()
        {
            if (((IListeliControl)this)._ListeBosDegilse() && lstHatirlatmalar.SelectedItems != null && lstHatirlatmalar.SelectedItems.Count != 0)
            {
                List<ListViewItem> itemler = new List<ListViewItem>();
                foreach (ListViewItem item in lstHatirlatmalar.SelectedItems)
                {
                    if (_IsNotBulunamadi(item) && _ItemiDogrula(item))
                    {
                        itemler.Add(item);
                    }
                }
                return itemler;
            }
            else { return null; }
        }
        #endregion

        #region Yukleniyor Metodları
        private void _Yukleniyor(bool Goster)
        {
            Delegates.BackColor.Set(yukleniyor1, Delegates.BackColor.Get(lstHatirlatmalar));
            _YukleniyorOrtala();
            Delegates.Visible.Set(yukleniyor1, Goster);
        }
        private void _YukleniyorOrtala()
        {
            Size lstgorusmelersize = Delegates.Size.Get(lstHatirlatmalar);
            Size yukleniyorsize = Delegates.Size.Get(yukleniyor1);
            int x = (lstgorusmelersize.Width / 2) - (yukleniyorsize.Width / 2);
            int y = (lstgorusmelersize.Height / 2) - (yukleniyorsize.Height / 2);
            Delegates.Location.Set(yukleniyor1, new Point(x, y));
        }
        #endregion

        #region lblDurum Metodları
        private void _SetDurum(string yazi, Color renk)
        {
            Optimizasyon.Delagate(ssHatirlatma, () =>
            {
                lblDurum.Text = string.Format("Durum : {0}", yazi);
                lblDurum.ForeColor = renk;
            });
        }
        private async Task _ResetDurum()
        {
            await Task.Delay(3000);
            Optimizasyon.Delagate(ssHatirlatma, () =>
            {
                if (lblDurum.ForeColor == Color.Green)
                {
                    _SetDurum("İşlem bekleniyor", Color.DodgerBlue);
                }
            });
        }
        #endregion

        #region bwHatirlatmalariYukle Metodları

        private BackgroundWorker bwHatirlatmalariYukle;

        private void BW()
        {
            bwHatirlatmalariYukle = new BackgroundWorker();
            bwHatirlatmalariYukle.DoWork += new DoWorkEventHandler(BwHatirlatmalariYukle_DoWork);
            bwHatirlatmalariYukle.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BwHatirlatmalariYukle_RunWorkerCompleted);
        }

        private async void BwHatirlatmalariYukle_DoWork(object sender, DoWorkEventArgs e)
        {
            _SetDurum("Hatırlatmalar Yükleniyor...", Color.OrangeRed);
            Stopwatch sw = new Stopwatch();
            _Yukleniyor(true);
            ((IListeliControl)this).ListeyiTemizle();
            sw.Start();
            ((IListeliControl)this).ListeyiYukle();
            sw.Stop();
            _Yukleniyor(false);
            _SetDurum("Hatırlatmalar " + DigerFonksiyonlar.MillisecondsToTimeString(sw.ElapsedMilliseconds) + " sürede yüklendi", Color.Green);
            await _ResetDurum();
        }
        private void BwHatirlatmalariYukle_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                bwHatirlatmalariYukle.RunWorkerAsync();
            }
        }
        #endregion



        public void HatirlatmalariYukle()
        {
            if (bwHatirlatmalariYukle.IsBusy)
            {
                BW();
            }
            bwHatirlatmalariYukle.RunWorkerAsync();
        }

        private void HatirlatmaListesi_Load(object sender, EventArgs e)
        {
            HatirlatmalariYukle();
        }

        private void cmsHatırlatmaListesi_Opening(object sender, CancelEventArgs e)
        {
            List<ListViewItem> secilenler = _SecilenItemleriGetir();
            if(secilenler != null && secilenler.Count >= 1)
            {
                btnHatirlatmaEkle.Visible = true;
                btnHatirlatmaSil.Visible = true;
                btnHatirlatmaDuzenle.Visible = secilenler.Count == 1;
            }
            else
            {
                btnHatirlatmaEkle.Visible = true;
                btnHatirlatmaSil.Visible = false;
                btnHatirlatmaDuzenle.Visible = false;
            }
        }
    }
}
