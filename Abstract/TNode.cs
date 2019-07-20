namespace Algorytms.Abstract
{
    public class TNode
    {
        private int data;
        private TNode left, right;

        public TNode(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        public int Data
        {
            get => data;
            set
            {
                if (value.GetType() == typeof(int))
                    data = value;
            }
        }

        public TNode Left
        {
            get => left;
            set
            {
                left = value;
            }
        }

        public TNode Right
        {
            get => right;
            set
            {
                right = value;
            }
        }
     
        public void Insertdata(ref TNode node, int data)
        {
            if (node == null)
            {
                node = new TNode(data);
            }
            else if (data < node.Data)
            {
                Insertdata(ref node.left, data);
            }
            else
            {
                Insertdata(ref node.right, data);
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
