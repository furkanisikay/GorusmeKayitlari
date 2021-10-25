using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.MsgBox;
using System;
using System.Data.Common;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorusmeKayitlari.Core.DB
{
    public class ConnectionManager : IDisposable
    {
        #region Constructor
        public ConnectionManager(string baglantiYazisi)
        {
            baglanti = new OleDbConnection(baglantiYazisi);
            _tmrKontrol = new Timer()
            {
                Interval = 1000
            };
            _tmrKontrol.Tick += new EventHandler(TmrKontrol_Tick);
        }
        #endregion

        #region Destructor
        ~ConnectionManager()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                baglanti.Close();
                baglanti.Dispose();
                _tmrKontrol.Dispose();
            }
            //Yönetilemeyen metotların null olarak atanması
        }
        #endregion

        #region Members
        #region Private Members
        private Timer _tmrKontrol;
        #endregion

        #region Public Members
        public OleDbConnection baglanti;
        public static ConnectionManager Instance { get { return new ConnectionManager(Tools.BaglYazisiniGetir(Regedit.GetMainRegKey())); } }
        #endregion
        #endregion

        #region Methods
        #region Private Methods
        private bool BaglantiKapat()
        {
            if (baglanti.State == System.Data.ConnectionState.Open)
            {
                baglanti.Close();
                return true;
            }
            else { return false; }
        }

        private void TmrKontrol_Tick(object sender, EventArgs e)
        {
            if (BaglantiKapat()) { _tmrKontrol.Stop(); }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Parametre olarak verilen komutun üzerinden ExecuteReader fonksiyonunu çalıştırır ve sonra timer çalıştırılarak işlem bitiminde bağlantı kapatılır.
        /// </summary>
        /// <param name="komut">İşlenecek komut</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>OleDbDataReader türünde data okuyucuyu döndürür.</returns>
        public OleDbDataReader SendCommand(OleDbCommand komut)
        {
            try
            {
                if (baglanti.State == System.Data.ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                OleDbDataReader reader = komut.ExecuteReader();
                _tmrKontrol.Start();
                return reader;
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                if (ex.Message.Contains("is already opened"))
                {
                    MessageBox.Show("Lütfen açık olan veritabanı dosyasını kapatıp tekrar deneyin.", MsgBoxBaslikAraclari.BaslikGetir(MsgBoxBaslik.Hata), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                else { throw; }
            }
            catch (Exception ex) { Logger.Log(ex); throw; }
            finally
            {
                komut.Dispose();
            }
        }
        /// <summary>
        /// Parametre olarak verilen komutun üzerinden ExecuteReaderAsync fonksiyonunu çalıştırır ve sonra timer çalıştırılarak işlem bitiminde bağlantı kapatılır.
        /// </summary>
        /// <param name="komut">İşlenecek komut</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>OleDbDataReader türünde data okuyucuyu döndürür.</returns>
        public async Task<OleDbDataReader> SendCommandAsync(OleDbCommand komut)
        {
            try
            {
                if (baglanti.State == System.Data.ConnectionState.Closed)
                {
                    await baglanti.OpenAsync();
                }
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("{0}\tGönderilen OleDb Komutu : {1}", DateTime.Now.ToLongTimeString(), komut.CommandText));
                }
                OleDbDataReader reader = (OleDbDataReader)await komut.ExecuteReaderAsync();
                _tmrKontrol.Start();
                return reader;
            }
            catch (DbException ex)
            {
                Logger.Log(ex);
                if (ex.Message.Contains("is already opened"))
                {
                    MessageBox.Show("Lütfen açık olan veritabanı dosyasını kapatıp tekrar deneyin.", MsgBoxBaslikAraclari.BaslikGetir(MsgBoxBaslik.Hata), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                else { throw; }
            }
            catch (Exception ex) { Logger.Log(ex); throw; }
            finally
            {
                komut.Dispose();
            }
        }

        /// <summary>
        /// Parametre olarak verilen komutu ExecuteNonQuery yaparak işleme koyar ve bitiminde bağlantıyı hemen kapatır.
        /// </summary>
        /// <param name="komut">Çalıştırılacak komut</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>int türünde ExecuteNonQuery fonksiyonundan gelen degeri döndürür.</returns>
        public int SendQuery(OleDbCommand komut)
        {
            int result = int.MinValue;
            try
            {
                if (baglanti.State == System.Data.ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                result = komut.ExecuteNonQuery();
            }
            catch (DbException ex) { Logger.Log(ex); throw; }
            catch (Exception exx) { Logger.Log(exx); throw; }
            finally
            {
                komut.Dispose();
                _tmrKontrol.Start();
            }
            return result;
        }
        /// <summary>
        /// Parametre olarak verilen komutu ExecuteNonQueryAsync yaparak işleme koyar ve bitiminde bağlantıyı hemen kapatır.
        /// </summary>
        /// <param name="komut">Çalıştırılacak komut</param>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns>int türünde ExecuteNonQueryAsync fonksiyonundan gelen degeri döndürür.</returns>
        public async Task<int> SendQueryAsync(OleDbCommand komut)
        {
            int result = int.MinValue;
            try
            {
                if (baglanti.State == System.Data.ConnectionState.Closed)
                {
                    await baglanti.OpenAsync();
                }
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("{0}\tYürütülen OleDb Komutu : {1}", DateTime.Now.ToLongTimeString(), komut.CommandText));
                }
                result = await komut.ExecuteNonQueryAsync();
            }
            catch (DbException ex) { Logger.Log(ex); throw; }
            catch (Exception exx) { Logger.Log(exx); throw; }
            finally
            {
                komut.Dispose();
                _tmrKontrol.Start();
            }
            return result;
        }
        #endregion
        #endregion
    }
}
