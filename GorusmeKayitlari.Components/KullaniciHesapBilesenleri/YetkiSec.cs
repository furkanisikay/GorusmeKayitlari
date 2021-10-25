using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.DB.Objects;

namespace GorusmeKayitlari.Components.KullaniciHesapBilesenleri
{
    public partial class YetkiSec : Form, IListeliControl
    {
        public YetkiSec()
        {
            InitializeComponent();
            Optimizasyon.Delagate(this, () => { ((IListeliControl)this).ListeyiYukle(); });
        }
        private bool _IptalEdildi = false;
        public bool IptalEdildi => _IptalEdildi;

        void IListeliControl.ListeyeEkle<T>(T nesne)
        {
            string text = DigerFonksiyonlar._YetkiToString(nesne);
            if (!string.IsNullOrEmpty(text))
            {
                DataTreeNode node = new DataTreeNode(nesne)
                {
                    Text = DigerFonksiyonlar._YetkiToString(nesne),
                    Checked = false
                };
                Optimizasyon.Delagate(treeView1, () => { treeView1.Nodes.Add(node); });
            }
        }

        void IListeliControl.ListeyiTemizle()
        {
            Optimizasyon.Delagate(treeView1, () => { treeView1?.Nodes.Clear(); });
        }
        void YetkileriYukle<T>()
        {
            T[] yetkiler = Enum.GetValues(typeof(T)) as T[];
            if (yetkiler?.Count() != 0)
            {
                foreach (T yetki in yetkiler)
                {
                    (this as IListeliControl)?.ListeyeEkle(yetki);
                }
            }
        }
        void IListeliControl.ListeyiYukle()
        {
            YetkileriYukle<NesneYetkileri>();
            YetkileriYukle<DigerYetkiler>();
        }
        

        bool IListeliControl._ListeBosDegilse()
        {
            throw new NotImplementedException();
        }

        void IListeliControl.ListeyeEkle<T>(List<T> nesne)
        {
            throw new NotImplementedException();
        }

        object IListeliControl.BosNesneOlustur(string ad)
        {
            throw new NotImplementedException();
        }

        //public void SetYetkiler(List<NesneYetkileri> yetkiler) 
        //{
        //    if (yetkiler?.Count != 0)
        //    {
        //        Optimizasyon.Delagate(treeView1, () =>
        //        {
        //            foreach (DataTreeNode node in treeView1.Nodes)
        //            {
        //                if (node.Data is NesneYetkileri && yetkiler.Contains((NesneYetkileri)(node.Data)))
        //                {
        //                    node.Checked = true;
        //                }
        //            }
        //        });
        //    }
        //}
        //public void SetYetkiler(List<DigerYetkiler> yetkiler)
        //{
        //    if (yetkiler?.Count != 0)
        //    {
        //        Optimizasyon.Delagate(treeView1, () =>
        //        {
        //            foreach (DataTreeNode node in treeView1.Nodes)
        //            {
        //                if (node.Data is DigerYetkiler && yetkiler.Contains((DigerYetkiler)(node.Data)))
        //                {
        //                    node.Checked = true;
        //                }
        //            }
        //        });
        //    }
        //}
        public void SetYetkiler<T>(List<T> yetkiler) where T : IConvertible
        {
            if (yetkiler?.Count != 0)
            {
                Optimizasyon.Delagate(treeView1, () =>
                {
                    foreach (DataTreeNode node in treeView1.Nodes)
                    {
                        if (node.Data is T && yetkiler.Contains<T>((T)(node.Data)))
                        {
                            node.Checked = true;
                        }
                    }
                });
            }
        }

        public List<T> GetYetkiler<T>()
        {
            List<T> yetkiler = new List<T>();
            foreach (DataTreeNode node in treeView1.Nodes)
            {
                if (node.Checked && node.Data is T)
                {
                    T yetki = (T)node.Data;
                    yetkiler.Add(yetki);
                }
            }
            return yetkiler;
        }

        private void OnaylaIptal1_Onaylandiginde(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnaylaIptal1_IptalEdildiginde(object sender, EventArgs e)
        {
            _IptalEdildi = true;
            this.Close();
        }

        private void YetkiSec_Load(object sender, EventArgs e)
        {

        }

        private void BtnTumunuSec_Click(object sender, EventArgs e)
        {
            Optimizasyon.Delagate(treeView1,()=> 
            {
                foreach (DataTreeNode node in treeView1.Nodes)
                {
                    node.Checked = true;
                }
            });
        }

        private void btnSecilenleriTemizle_Click(object sender, EventArgs e)
        {
            Optimizasyon.Delagate(treeView1, () =>
            {
                foreach (DataTreeNode node in treeView1.Nodes)
                {
                    node.Checked = false;
                }
            });
        }
    }
}
