namespace Algorytms.Abstract
{
    public class TNode
    {
		//Enumerable Color for Red Black Tree
		public enum Color
		{
			Red,
			Black,
			None
		}
		//------------------- Private Field ---------------------
        private int _data;
		private TNode _left, _right, _parent;
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
		public TNode Parent
		{
			get => _parent;
			set => _parent = value;
		}

        public TNode Left
		{
			get => _left;
			set => _left = value;
		}

		public TNode Right
		{
			get => _right;
			set => _right = value;
		}
		public Color Colors	{ get; set;	}

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
                Insertdata(ref node._left, data);
            }
            else
            {
                Insertdata(ref node._right, data);
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
