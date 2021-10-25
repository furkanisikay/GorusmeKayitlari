using GorusmeKayitlari.Core;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GorusmeKayitlari.Components
{
    public partial class Yukleniyor : UserControl
    {
        public Yukleniyor()
        {
            InitializeComponent();
            UpdateControls();
        }

        public Font YaziFontu
        {
            get { return Delegates.Font.Get(lblYazi); }
            set { Delegates.Font.Set(lblYazi, value); }
        }
        public string Yazi
        {
            get { return Delegates.Text.Get(lblYazi); }
            set { Delegates.Text.Set(lblYazi, value); }
        }

#pragma warning disable CS0108 // Üye devralınmış üyeyi gizler; yeni anahtar sözcük eksik
        [BrowsableAttribute(false)]
        protected bool DesignMode { get; }
#pragma warning restore CS0108 // Üye devralınmış üyeyi gizler; yeni anahtar sözcük eksik

        public bool YaziGoster
        {
            get { return Delegates.Visible.Get(lblYazi); }
            set { _SetShowText(value); }
        }

        public void _SetShowText(bool visible)
        {
            Delegates.Visible.Set(lblYazi, visible);
            Delegates.Location.Set(pictureBox1, (visible ? new Point(3, 41) : new Point(3, 3)));
            Delegates.Size.Set(pictureBox1, new Size((Delegates.Width.Get(this) - 6), (Delegates.Height.Get(this) - (visible ? 44 : 6))));
        }

        private void UpdateControls()
        {
            Delegates.Enabled.Set(pictureBox1, !DesignMode);
        }
        
        public void SetThis(string Yazi, int Yuzde)
        {
            this.Yazi = Yazi;
        }

        private void Yukleniyor_VisibleChanged(object sender, System.EventArgs e)
        {
            UpdateControls();
        }
    }
}
