using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorusmeKayitlari.Core.Components
{
    [Serializable()]
    public class DataListViewItem : ListViewItem,ISerializable
    {
        private object data;

        public DataListViewItem(object data) : base(data.ToString())
        {
            this.data = data;
        }

        public object Data
        {
            get { return data; }
        }
    }
}
