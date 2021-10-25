using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GorusmeKayitlari.Core.DisariAktar.Excel;
using GorusmeKayitlari.Core;

namespace GorusmeKayitlari.Components.ExcelBilesenleri
{
    public partial class ExcelTema : UserControl
    {
        #region Constructor
        public ExcelTema()
        {
            InitializeComponent();
            _SetThisTheme(ExcelAraclari._GetDefaultTheme(this));
        }
        #endregion

        #region ExcelTema Members
        public ExcelIcerikTemasi tema = null;
        public ExcelIcerikTemasi Tema { get { return tema; } }

#pragma warning disable CS0114 // Üye devralınmış üyeyi gizler; geçersiz kılma anahtar sözcüğü eksik
        [Browsable(true)]
        public string Text
#pragma warning restore CS0114 // Üye devralınmış üyeyi gizler; geçersiz kılma anahtar sözcüğü eksik
        {
            get { return Delegates.Text.Get(gboxTema); }
            set { Delegates.Text.Set(gboxTema, value); }
        }
        #endregion

        #region Methods
        public ExcelIcerikTemasi _GetThisTheme()
        {
            ExcelBlok baslik = null, birincil = null, ikincil = null;
            Optimizasyon.Delagate(fkAltBaslik, () => { baslik = fkAltBaslik._GetthisBlok(); });
            Optimizasyon.Delagate(fkAltBaslik, () => { birincil = fkBirincilBlok._GetthisBlok(); });
            Optimizasyon.Delagate(fkAltBaslik, () => { ikincil = fkIkincilBlok._GetthisBlok(); });
            return new ExcelIcerikTemasi(baslik, birincil, ikincil);
        }
        public void _SetThisTheme(ExcelIcerikTemasi Tema)
        {
            Optimizasyon.Delagate(fkAltBaslik, () => { fkAltBaslik._SetThis(Tema.BaslikBloklari); });
            Optimizasyon.Delagate(fkBirincilBlok, () => { fkBirincilBlok._SetThis(Tema.BirincilBlok); });
            Optimizasyon.Delagate(fkIkincilBlok, () => { fkIkincilBlok._SetThis(Tema.IkincilBlok); });
        }
        #endregion
    }
}