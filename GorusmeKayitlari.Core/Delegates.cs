using GorusmeKayitlari.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GorusmeKayitlari.Core.Components;

namespace GorusmeKayitlari.Core
{
    public class Delegates
    {
        public class T
        {
            public static T Get<T>(Control ctrl, T ValueforGet)
            {
                T tmpvalue = default(T);
                try
                {
                    if (ctrl.InvokeRequired)
                    {
                        ctrl.Invoke((MethodInvoker)delegate { tmpvalue = ValueforGet; });
                    }
                    else { tmpvalue = ValueforGet; }
                }
                catch (Exception ex) { Logger.Log(ex); tmpvalue = default(T); }
                return tmpvalue;
            }
        }
        public class Text
        {
            public static string Get(Control ctrl)
            {
                return Delegates.T.Get(ctrl, ctrl.Text);
            }
            public static void Set(Control ctrl, string yazi)
            {
                try
                {
                    if (ctrl.InvokeRequired)
                    {
                        ctrl.Invoke((MethodInvoker)delegate { ctrl.Text = yazi; });
                    }
                    else { ctrl.Text = yazi; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }
        public class Tag
        {
            public static object Get(Control ctrl)
            {
                return Delegates.T.Get(ctrl, ctrl.Tag);
            }
            public static void Set(Control ctrl, object Tag)
            {
                try
                {
                    if (ctrl.InvokeRequired)
                    {
                        ctrl.Invoke((MethodInvoker)delegate { ctrl.Tag = Tag; });
                    }
                    else { ctrl.Tag = Tag; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }
        public class Enabled
        {
            public static bool Get(Control ctrl)
            {
                return Delegates.T.Get(ctrl, ctrl.Enabled);
            }
            public static void Set(Control ctrl, bool Enabled)
            {
                try
                {
                    if (ctrl.InvokeRequired)
                    {
                        ctrl.Invoke((MethodInvoker)delegate { ctrl.Enabled = Enabled; });
                    }
                    else { ctrl.Enabled = Enabled; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }
        public class Checked
        {
            public static bool Get(CheckBox chck)
            {
                return Delegates.T.Get(chck, chck.Checked);
            }
            public static void Set(CheckBox chck, bool Checked)
            {
                try
                {
                    if (chck.InvokeRequired)
                    {
                        chck.Invoke((MethodInvoker)delegate { chck.Checked = Checked; });
                    }
                    else { chck.Checked = Checked; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }
        public class Visible
        {
            public static bool Get(Control ctrl)
            {
                return Delegates.T.Get(ctrl, ctrl.Visible);
            }
            public static void Set(Control ctrl, bool Visible)
            {
                try
                {
                    if (ctrl.InvokeRequired)
                    {
                        ctrl.Invoke((MethodInvoker)delegate { ctrl.Visible = Visible; });
                    }
                    else { ctrl.Visible = Visible; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }
        public class Height
        {
            public static int Get(Control ctrl)
            {
                return Delegates.T.Get(ctrl, ctrl.Height);
            }
            public static void Set(Control ctrl, int Height)
            {
                try
                {
                    if (ctrl.InvokeRequired)
                    {
                        ctrl.Invoke((MethodInvoker)delegate { ctrl.Height = Height; });
                    }
                    else { ctrl.Height = Height; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }
        public class Width
        {
            public static int Get(Control ctrl)
            {
                return Delegates.T.Get(ctrl, ctrl.Width);
            }
            public static void Set(Control ctrl, int Width)
            {
                try
                {
                    if (ctrl.InvokeRequired)
                    {
                        ctrl.Invoke((MethodInvoker)delegate { ctrl.Width = Width; });
                    }
                    else { ctrl.Width = Width; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }
        public class Location
        {
            public static System.Drawing.Point Get(Control ctrl)
            {
                return Delegates.T.Get(ctrl, ctrl.Location);
            }
            public static void Set(Control ctrl, System.Drawing.Point Location)
            {
                try
                {
                    if (ctrl.InvokeRequired)
                    {
                        ctrl.Invoke((MethodInvoker)delegate { ctrl.Location = Location; });
                    }
                    else { ctrl.Location = Location; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }
        public class Size
        {
            public static System.Drawing.Size Get(Control ctrl)
            {
                return Delegates.T.Get(ctrl, ctrl.Size);
            }
            public static void Set(Control ctrl, System.Drawing.Size Size)
            {
                try
                {
                    if (ctrl.InvokeRequired)
                    {
                        ctrl.Invoke((MethodInvoker)delegate { ctrl.Size = Size; });
                    }
                    else { ctrl.Size = Size; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }
        public class Style
        {
            public static ProgressBarStyle Get(ProgressBar prg)
            {
                return Delegates.T.Get(prg, prg.Style);
            }
            public static void Set(ProgressBar prg, ProgressBarStyle Style)
            {
                try
                {
                    if (prg.InvokeRequired)
                    {
                        prg.Invoke((MethodInvoker)delegate { prg.Style = Style; });
                    }
                    else { prg.Style = Style; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }
        public class Value
        {
            public static int Get(ProgressBar prg)
            {
                return Delegates.T.Get(prg, prg.Value);
            }
            public static void Set(ProgressBar prg, int Value)
            {
                try
                {
                    if (prg.InvokeRequired)
                    {
                        prg.Invoke((MethodInvoker)delegate { prg.Value = Value; });
                    }
                    else { prg.Value = Value; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
            public static decimal Get(NumericUpDown nud)
            {
                return Delegates.T.Get(nud, nud.Value);
            }
            public static void Set(NumericUpDown nud, int Value)
            {
                try
                {
                    if (nud.InvokeRequired)
                    {
                        nud.Invoke((MethodInvoker)delegate { nud.Value = Value; });
                    }
                    else { nud.Value = Value; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
            public static void Set(NumericUpDown nud, decimal Value)
            {
                try
                {
                    if (nud.InvokeRequired)
                    {
                        nud.Invoke((MethodInvoker)delegate { nud.Value = Value; });
                    }
                    else { nud.Value = Value; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
            public static DateTime Get(DateTimePicker dtp)
            {
                return Delegates.T.Get(dtp, dtp.Value);
            }
            public static void Set(DateTimePicker dtp, DateTime time)
            {
                try
                {
                    if (dtp.InvokeRequired)
                    {
                        dtp.Invoke((MethodInvoker)delegate { dtp.Value = time; });
                    }
                    else { dtp.Value = time; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
            public static int Get(TrackBar tbar)
            {
                return Delegates.T.Get(tbar, tbar.Value);
            }
            public static void Set(TrackBar tbar, int Value)
            {
                try
                {
                    if (tbar.InvokeRequired)
                    {
                        tbar.Invoke((MethodInvoker)delegate { tbar.Value = Value; });
                    }
                    else { tbar.Value = Value; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }
        public class Font
        {
            public static System.Drawing.Font Get(Control ctrl)
            {
                return Delegates.T.Get(ctrl, ctrl.Font);
            }
            public static void Set(Control ctrl, System.Drawing.Font Font)
            {
                try
                {
                    if (ctrl.InvokeRequired)
                    {
                        ctrl.Invoke((MethodInvoker)delegate { ctrl.Font = Font; });
                    }
                    else { ctrl.Font = Font; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }
        public class SelectedIndex
        {
            public static int Get(ComboBox cbox)
            {
                int deger = -1;
                Optimizasyon.Delagate(cbox, () => { deger = cbox.SelectedIndex; });
                return deger;
            }
            public static void Set(ComboBox cbox, int SelectedIndex)
            {
                try
                {
                    if (cbox.InvokeRequired)
                    {
                        cbox.Invoke((MethodInvoker)delegate { cbox.SelectedIndex = SelectedIndex; });
                    }
                    else { cbox.SelectedIndex = SelectedIndex; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }
        public class BackColor
        {
            public static System.Drawing.Color Get(Control ctrl)
            {
                return Delegates.T.Get(ctrl, ctrl.BackColor);
            }
            public static void Set(Control ctrl, System.Drawing.Color BackColor)
            {
                try
                {
                    if (ctrl.InvokeRequired)
                    {
                        ctrl.Invoke((MethodInvoker)delegate { ctrl.BackColor = BackColor; });
                    }
                    else { ctrl.BackColor = BackColor; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }
        public class ForeColor
        {
            public static System.Drawing.Color Get(Control ctrl)
            {
                return Delegates.T.Get(ctrl, ctrl.ForeColor);
            }
            public static void Set(Control ctrl, System.Drawing.Color ForeColor)
            {
                try
                {
                    if (ctrl.InvokeRequired)
                    {
                        ctrl.Invoke((MethodInvoker)delegate { ctrl.ForeColor = ForeColor; });
                    }
                    else { ctrl.ForeColor = ForeColor; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }

        public class Dock
        {
            public static DockStyle Get(Control ctrl)
            {
                return Delegates.T.Get(ctrl, ctrl.Dock);
            }
            public static void Set(Control ctrl, DockStyle Style)
            {
                try
                {
                    if (ctrl.InvokeRequired)
                    {
                        ctrl.Invoke((MethodInvoker)delegate { ctrl.Dock = Style; });
                    }
                    else { ctrl.Dock = Style; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }
        public class Image
        {
            public static System.Drawing.Image Get(PictureBox pbox)
            {
                return Delegates.T.Get(pbox, pbox.Image);
            }
            public static void Set(PictureBox pbox, System.Drawing.Image image)
            {
                try
                {
                    if (pbox.InvokeRequired)
                    {
                        pbox.Invoke((MethodInvoker)delegate { pbox.Image = image; });
                    }
                    else { pbox.Image= image; }
                }
                catch (Exception ex) { Logger.Log(ex); throw new Exception("Bir Hata Oluştu!", ex); }
            }
        }
    }
}
