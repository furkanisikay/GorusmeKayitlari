using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.MsgBox;

namespace GorusmeKayitlari.Core.YetkiSistemi
{
    public class Methods
    {
        public static bool _OturumVeYetkiSorgula<T>(Control owner, T yetki, Oturum oturum, bool Msg = true)
        {
            if (!typeof(T).IsEnum)
            {
                new ArgumentException("T nesnesine sadece enum atanabilir");
            }
            if (oturum != null && oturum.OturumAcildi)
            {
                if (oturum.OturumAcilanHesap.Durum == KullaniciHesapDurumu.Aktif)
                {
                    if (oturum.OturumAcilanHesap.YetkileriAra(yetki))
                    {
                        return true;
                    }
                    else
                    {
                        if (Msg)
                        {
                            MsgBox.MsgBox.Hata(owner, DigerFonksiyonlar._YetkiToString(yetki) + " adlı yetkiniz bulunmadığından bu işlem gerçekleştirilemez");
                        }
                        return false;
                    }
                }
                else
                {
                    if (Msg)
                    {
                        MsgBox.MsgBox.Hata(owner, "Oturum açılan kullanıcı hesabının hesap durumu aktif olmadığı için bu işlem gerçekleştirilemez");
                    }
                    return false;
                }
            }
            else
            {
                if (Msg)
                {
                    MsgBox.MsgBox.Hata(owner, "Bu işlemi gerçekleştirmek için lütfen oturum açın.");
                }
                return false;
            }
        }
    }
}
