 using System;
using System.Threading;
using System.Windows.Forms;
using GorusmeKayitlari.Core.Extensions;

namespace GorusmeKayitlari.Core
{
    public class Optimizasyon
    {

        public static void ArkaplandaCalistir(ThreadStart ts, ThreadPriority oncelik , bool Bekle = false, bool Arkaplanda = true)
        {
            Thread thread = new Thread(ts)
            {
                IsBackground = Arkaplanda,
                Priority = oncelik
            };
            thread.Start();
            if (Bekle)
            {
                thread.Join();
            }
        }
        public static void ArkaplandaCalistir(ThreadStart ts, bool Bekle = false, bool Arkaplanda = true)
        {
            Thread thread = new Thread(ts)
            {
                IsBackground = Arkaplanda,
                Priority =  ThreadPriority.Highest
            };
            thread.Start();
            if (Bekle)
            {
                thread.Join();
            }
        }
        public static void Delagate(Control ctrl, Action islemler)
        {
            if (ctrl != null)
            {
                if (ctrl.InvokeRequired)
                {
                    try { ctrl.Invoke((MethodInvoker)delegate { islemler(); }); }
                    catch(ObjectDisposedException) { }
                    catch (Exception ex) { Logger.Log(ex); }
                }
                else { islemler(); }
            }
        }
    }
}
