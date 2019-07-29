using Algorytms.Abstract;

namespace Algorytms.Trees
{
    public class BinarySearchTree
    {

        TNode root;

		/// <summary>
		/// Constructor initializate root = null
		/// </summary>
        public BinarySearchTree()
        {
            root = null;
			root.Colors = TNode.Color.None;
        }

		/// <summary>
		/// Constructor initializate root = data
		/// </summary>
		/// <param name="data"></param>
        public BinarySearchTree(int data)
        {
            root = new TNode(data);
			root.Colors = TNode.Color.None;
        }

		/// <summary>
		/// Return Count nodes from root of Tree
		/// </summary>
        public int Count { get; private set; }

		/// <summary>
		/// Add new node to Tree
		/// </summary>
		/// <param name="data">value</param>
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

		/// <summary>
		/// Return boolean value Is Tree is empty
		/// </summary>
		/// <returns></returns>
        public bool IsEmpty()
        {
            return root == null;
        }

		/// <summary>
		/// Inherit Find method from AbstractTree
		/// </summary>
		/// <param name="data">Target Value</param>
		/// <returns>Node<T></returns>
        public bool Search(int data)
        {
            return root.Find(root, data);
        }

		/// <summary>
		/// Print all Tree to Console window
		/// </summary>
        public void ConsolePrint()
        {
			root.Print();
        }
    }
}
