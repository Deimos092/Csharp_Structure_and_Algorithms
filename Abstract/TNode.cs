namespace Algorytms.Abstract
{
    public class TNode
    {
		//Enumerable Color for Red Black Tree
		public enum ColorEnum
		{
			Red,
			Black,
			None
		}
		//------------------- Private Field ---------------------
        private int _data;
		public TNode Left, Right, Parent;
		//-------------------------------------------------------

		/// <summary>
		/// Constructor for init Data, Left, Right fields
		/// </summary>
		/// <param name="data">data field</param>
        public TNode(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        public int Data
        {
            get => _data;
            set
            {
                if (value.GetType() == typeof(int))
					_data = value;
			}
		}

		public ColorEnum Color	{ get; set;	}

		/// <summary>
		/// Reqursion inserting Node like BST tree method
		/// </summary>
		/// <param name="node">Curent node</param>
		/// <param name="data">Data value</param>
        public void Insertdata(ref TNode node, int data)
        {
            if (node == null)
            {
                node = new TNode(data);
            }
            else if (data < node.Data)
            {
                Insertdata(ref node.Left, data);
            }
            else
            {
                Insertdata(ref node.Right, data);
            }
        }

		/// <summary>
		/// Find Data from tree 
		/// </summary>
		/// <param name="node">Current Node</param>
		/// <param name="data">Target data</param>
		/// <returns> Boolean result </returns>
        public bool Find(TNode node, int data)
        {
            if (node == null)
                return false;

            if (node.Data == data)
            {
                return true;
            }
            else if (node.Data < data)
            {
                return Find(node.Right, data);
            }
            else if (node.Data > data)
            {
                return Find(node.Left, data);
            }

            return false;
        }
    }
}
