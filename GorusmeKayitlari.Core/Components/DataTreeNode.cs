using System.Windows.Forms;

namespace GorusmeKayitlari.Core.Components
{
    public class DataTreeNode : TreeNode
    {
        private object data;

        public DataTreeNode(object data) : base(data.ToString())
        {
            this.data = data;
        }

        public object Data
        {
            get { return data; }
        }
    }
}
