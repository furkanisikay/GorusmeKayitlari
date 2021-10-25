using GorusmeKayitlari.Core.MsgBox;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GorusmeKayitlari.Extensions
{
    [DefaultEvent("SecilenDosyaDegistiginde")]
    public partial class GozatButton : Button
    {
        [Description("GözatButton nesnesinin SecilenNesne adlı değişkenine yeni bir dosya atandığında gerçekleşir."), Category("Action")]
        public event EventHandler<string> SecilenDosyaDegistiginde;
        [Category("Özellikler")]
        public string Baslik
        {
            get { return ofdGozat != null ? ofdGozat.Title : string.Empty; }
            set { if (ofdGozat != null) { ofdGozat.Title = value; } }
        }
        [Category("Özellikler")]
        public string DosyaUzantilari
        {
            get { return ofdGozat != null ? ofdGozat.Filter : string.Empty; }
            set { if (ofdGozat != null) { ofdGozat.Filter = value; } }
        }
        [Category("Özellikler")]
        public string VarsayilanUzanti
        {
            get { return ofdGozat != null ? ofdGozat.DefaultExt : string.Empty; }
            set { if (ofdGozat != null) { ofdGozat.DefaultExt = value; } }
        }
        [Category("Özellikler"), Browsable(false)]
        public string SecilenDosya { get { return _secilenDosya; } }
        private string _secilenDosya = string.Empty;
        OpenFileDialog ofdGozat;
        public GozatButton()
        {
            InitializeComponent();
            ofdGozat = new OpenFileDialog();
            ofdGozat.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void GozatButton_Click(object sender, EventArgs e)
        {
            DialogResult drSonuc = DialogResult.Cancel;
            while (drSonuc == DialogResult.Cancel)
            {
                drSonuc = ofdGozat.ShowDialog();
                if (drSonuc == DialogResult.Cancel && MsgBox.Hata(this, "Dosya Seçilmedi!", MessageBoxButtons.RetryCancel) != DialogResult.Retry)
                {
                    _Reset();
                    return;
                }
            }
            if (ofdGozat != null && !string.IsNullOrEmpty(ofdGozat.FileName) && ofdGozat.FileName != this._secilenDosya)
            {
                this._secilenDosya = ofdGozat.FileName;
                SecilenDosyaDegistiginde?.Invoke(sender, ofdGozat.FileName);
            }
        }

        public GozatButton(IContainer container)
        {
            container.Add(this);
            ofdGozat = new OpenFileDialog();
            ofdGozat.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            InitializeComponent();
            base.Click += GozatButton_Click;
        }
        

        public GozatButton(OpenFileDialogArgs args)
        {
            InitializeComponent();
            ofdGozat = new OpenFileDialog();
            ofdGozat.Filter = args.DosyaUzantilari;
            ofdGozat.InitialDirectory = args.VarsayilanDizin;
            ofdGozat.Title = args.Baslik;
            ofdGozat.DefaultExt = args.VarsayilanUzanti;
            base.Click += GozatButton_Click;
        }
        /// <summary>
        /// Belirtilen uzantıya yönelik yeni bir GozatButton nesnesi oluşturur.
        /// </summary>
        /// <param name="uzanti">noktasız(.) uzantı adi</param>
        public GozatButton(string uzanti)
        {
            InitializeComponent();
            if (uzanti.Substring(0, 1) == ".") // eğer nokta yazzaılmışsa silmek için.
            {
                uzanti = uzanti.Substring(1);
            }
            uzanti = uzanti.ToLower();
            ofdGozat = new OpenFileDialog();
            ofdGozat.Filter = uzanti.ToUpper() + " Dosyaları|*." + uzanti.ToLower();
            ofdGozat.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofdGozat.Title = "Lütfen dosya seçin.";
            ofdGozat.DefaultExt = "." + uzanti.ToLower();
            base.Click += GozatButton_Click;
        }

        private void _Reset()
        {
            OpenFileDialogArgs args = new OpenFileDialogArgs(ofdGozat.Title, ofdGozat.Filter, ofdGozat.InitialDirectory, ofdGozat.DefaultExt);
            ofdGozat.Dispose();
            ofdGozat = new OpenFileDialog();
            ofdGozat.Filter = args.DosyaUzantilari;
            ofdGozat.InitialDirectory = args.VarsayilanDizin;
            ofdGozat.Title = args.Baslik;
            ofdGozat.DefaultExt = args.VarsayilanUzanti;
        }
    }

    public class OpenFileDialogArgs
    {
        public string DosyaUzantilari { get; set; }
        public string VarsayilanDizin { get; set; }
        public string Baslik { get; set; }
        public string VarsayilanUzanti { get; set; }
        public OpenFileDialogArgs(string Baslik, string DosyaUzantilari, string VarsayilanDizin, string VarsayilanUzanti)
        {
            this.Baslik = Baslik;
            this.DosyaUzantilari = DosyaUzantilari;
            this.VarsayilanDizin = VarsayilanDizin;
            this.VarsayilanUzanti = VarsayilanUzanti;
        }
    }
}
