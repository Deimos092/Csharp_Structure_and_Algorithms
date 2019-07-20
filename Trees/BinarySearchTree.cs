using Algorytms.Abstract;

namespace Algorytms.Trees
{
    public class BinarySearchTree
    {
        TNode root;
        public BinarySearchTree()
        {
            root = null;
        }

        public BinarySearchTree(int data)
        {
            root = new TNode(data);
        }

        public int Count { get; private set; }

        public void Inser(int data )
        {
            if (IsEmpty())
                root = new TNode(data);
            else
            {
                root.Insertdata(ref root, data);
            }
            Count++;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public bool Search(int data)
        {
            return root.Search(root, data);
        }

        public void ConsolePrint()
        {
			root.Print();
        }
    }
}
