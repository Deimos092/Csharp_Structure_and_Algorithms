using Algorytms.Abstract;

namespace Algorytms.Trees
{
    public class BinarySearchTree
    {
        TNode root;
        public BinarySearchTree()
        {
            root = null;
			root.Colors = TNode.Color.None;
        }

        public BinarySearchTree(int data)
        {
            root = new TNode(data);
			root.Colors = TNode.Color.None;
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
            return root.Find(root, data);
        }

        public void ConsolePrint()
        {
			root.Print();
        }
    }
}
