using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.Extensions;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GorusmeKayitlari.App.Bilesenler
{
    public partial class TarihFiltreleme : UserControl
    {
        public TarihFiltreleme()
        {
            InitializeComponent();
            Delegates.SelectedIndex.Set(cmbTarihler, 0);
        }

        #region Events
        public event EventHandler<TarihFiltreleEventArgs> FiltreleTiklandiginda;
        #endregion
        [Browsable(true)]
        public int SelectedIndex
        {
            get { return Delegates.SelectedIndex.Get(cmbTarihler); }
            set { _cmbTarih_Sec(value); }
        }

        [Browsable(true)]
        public bool FiltrelemeAktif
        {
            get { return Delegates.Enabled.Get(btnFiltrele); }
            set { Delegates.Enabled.Set(btnFiltrele,value); }
        }
        private void CmbTarihler_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DigerTarih(cmbTarihler.SelectedIndex == 4);
        }

        private void _DigerTarih(bool Goster)
        {
            Delegates.Visible.Set(panel1, Goster);
            Delegates.Enabled.Set(panel1, Goster);
            int x = Delegates.Location.Get(panel1).X + (Goster ? Delegates.Width.Get(panel1) +  6 : 0);
            int y = Delegates.Location.Get(btnFiltrele).Y;
            Delegates.Location.Set(btnFiltrele, new Point(x, y));
        }
        private void _cmbTarih_Sec(int index)
        {
            if (index != -1 && index < cmbTarihler.Items.Count)
            {
                try
                {
                    Delegates.SelectedIndex.Set(cmbTarihler, index);
                }
                catch (Exception ex) { Logger.Log(ex); }
            }
        }
        public DateTime _BaslangicTarihiOlustur()
        {
            int index = Delegates.SelectedIndex.Get(cmbTarihler);
            switch (index)
            {
                case 0:
                    return DateTime.Now.AddDays(-1);
                case 1:
                    return DateTime.Now.AddDays(-7);
                case 2:
                    return DateTime.Now.AddDays(-30);
                case 3:
                    return DateTime.Now.AddDays(-365);
                case 4:
                    return Delegates.Value.Get(dtpTarih1);
                default:
                    return DateTime.Now;
            }
        }
        public DateTime _BitisTarihiOlustur()
        {
            return Delegates.Visible.Get(panel1) ? Delegates.Value.Get(dtpTarih2) : DateTime.Now;
        }

        private TarihFiltreleEventArgs _GetEventArgs()
        {
            return new TarihFiltreleEventArgs(_BaslangicTarihiOlustur(), _BitisTarihiOlustur());
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            if (FiltreleTiklandiginda != null)
            {
                try { FiltreleTiklandiginda(sender, _GetEventArgs()); }
                catch (Exception ex) { Logger.Log(ex); }
            }
        }
    }
}
