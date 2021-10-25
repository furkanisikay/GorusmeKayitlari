using System.Windows.Forms;

namespace GorusmeKayitlari.Core.MsgBox
{
    public static class MsgBox
    {
        /// <summary>
        /// Bir Mesaj Penceresi Görüntüler.
        /// </summary>
        /// <param name="owner">Mesaj Penceresinin Kapsayıcısı.</param>
        /// <param name="mesaj">Pencere Mesajı</param>
        /// <param name="butonlar">Mesaj Penceresinin Butonları</param>
        /// <returns>DialogResult</returns>
        public static DialogResult Hata(Control owner, string mesaj, MessageBoxButtons butonlar = MessageBoxButtons.OK)
        {
            DialogResult drSonuc = DialogResult.None;
            Optimizasyon.Delagate(owner, () => { drSonuc = MessageBox.Show(owner, mesaj, MsgBoxBaslikAraclari.BaslikGetir(MsgBoxBaslik.Hata), butonlar, MessageBoxIcon.Error); });
            return drSonuc;
        }
        /// <summary>
        /// Bir Mesaj Penceresi Görüntüler.
        /// </summary>
        /// <param name="owner">Mesaj Penceresinin Kapsayıcısı.</param>
        /// <param name="mesaj">Pencere Mesajı</param>
        /// <param name="butonlar">Mesaj Penceresinin Butonları</param>
        /// <returns>DialogResult</returns>
        public static DialogResult Bilgi(IWin32Window owner, string mesaj, MessageBoxButtons butonlar = MessageBoxButtons.OK)
        {
            return MessageBox.Show(owner, mesaj, MsgBoxBaslikAraclari.BaslikGetir(MsgBoxBaslik.Bilgi), butonlar, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Bir Mesaj Penceresi Görüntüler.
        /// </summary>
        /// <param name="owner">Mesaj Penceresinin Kapsayıcısı.</param>
        /// <param name="mesaj">Pencere Mesajı</param>
        /// <param name="butonlar">Mesaj Penceresinin Butonları</param>
        /// <returns>DialogResult</returns>
        public static DialogResult Soru(IWin32Window owner, string mesaj, MessageBoxButtons butonlar = MessageBoxButtons.YesNo)
        {
            return MessageBox.Show(owner, mesaj, MsgBoxBaslikAraclari.BaslikGetir(MsgBoxBaslik.Soru), butonlar, MessageBoxIcon.Question);
        }
        /// <summary>
        /// Bir Mesaj Penceresi Görüntüler.
        /// </summary>
        /// <param name="owner">Mesaj Penceresinin Kapsayıcısı.</param>
        /// <param name="mesaj">Pencere Mesajı</param>
        /// <param name="butonlar">Mesaj Penceresinin Butonları</param>
        /// <returns>DialogResult</returns>
        public static DialogResult Dikkat(IWin32Window owner, string mesaj, MessageBoxButtons butonlar = MessageBoxButtons.OK)
        {
            return MessageBox.Show(owner, mesaj, MsgBoxBaslikAraclari.BaslikGetir(MsgBoxBaslik.Dikkat), butonlar, MessageBoxIcon.Warning);
        }
    }
}
