namespace Algorytms.Abstract
{
    public class TNode
    {
		public enum Color
		{
			Red,
			Black,
			None
		}
        private int _data;
		private TNode _left, _right, _parent;
		private Color _color;
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

		public Color Colors
		{
			get => _color;
			set => _color = value;
		}
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

        public bool Search(TNode node, int data)
        {
            if (node == null)
                return false;

            if (node.Data == data)
            {
                return true;
            }
            else if (node.Data < data)
            {
                return Search(node.Right, data);
            }
            else if (node.Data > data)
            {
                return Search(node.Left, data);
            }

            return false;
        }
    }
}
