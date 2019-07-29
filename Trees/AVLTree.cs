using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorytms.Abstract;

namespace Algorytms.Trees
{
	public class AVLTree
	{

		TNode _root;

		/// <summary>
		/// Nullable constructor 
		/// </summary>
		public AVLTree() { }

		/// <summary>
		/// Constructor which initializate root with value
		/// </summary>
		/// <param name="data"></param>
		public AVLTree(int data)
		{
			_root = new TNode(data);
		}
		
		/// <summary>
		/// Inser new Node with all rules of insert
		/// </summary>
		/// <param name="data"></param>
		public virtual void Inser(int data)
		{
			TNode node = new TNode(data);
			if(_root == null)
			{
				_root = node;
				_root.Colors = TNode.Color.None;
			}
			else
			{
				_root.Colors = TNode.Color.None;
				_root = RecursiveInsert(_root, node);
			}
		}

		/// <summary>
		/// Go to end of branch and add new node
		/// </summary>
		/// <param name="currentNode"></param>
		/// <param name="node"></param>
		/// <returns></returns>
		private TNode RecursiveInsert(TNode currentNode, TNode node)
		{
			if (currentNode == null)
			{
				currentNode = node;
				return currentNode;
			}
			else if (node.Data < currentNode.Data)
			{
				currentNode.Left = RecursiveInsert(currentNode.Left, node);
				currentNode = balance_tree(currentNode);
			}
			else if (node.Data > currentNode.Data)
			{
				currentNode.Right = RecursiveInsert(currentNode.Right, node);
				currentNode = balance_tree(currentNode);
			}
			return currentNode;
		}

		/// <summary>
		/// Balanced Tree when It's balance beyond of [-1;1]
		/// </summary>
		/// <param name="current"></param>
		/// <returns></returns>
		private TNode balance_tree(TNode current)
		{
			int b_factor = balance_factor(current);
			if (b_factor > 1)
			{
				if (balance_factor(current.Left) > 0)
				{
					current = RotateLL(current);//Left-Lfet rotate
				}
				else
				{
					current = RotateLR(current);//Left-Right rotate
				}
			}
			else if (b_factor < -1)
			{
				if (balance_factor(current.Right) > 0)
				{
					current = RotateRL(current);//Right-Left rotate
				}
				else
				{
					current = RotateRR(current);//Right-Right rotate
				}
			}
			return current;
		}

		private int max(int left, int right)
		{
			return Math.Max(left, right);
		}

		/// <summary>
		/// Get recursive value max of height each of branch current Node
		/// </summary>
		/// <param name="current"></param>
		/// <returns></returns>
		private int getHeight(TNode current)
		{
			int height = 0;
			if (current != null)
			{
				int l = getHeight(current.Left);
				int r = getHeight(current.Right);
				int m = max(l, r);
				height = m + 1;
			}
			return height;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="current"></param>
		/// <returns></returns>
		private int balance_factor(TNode current)
		{
			int l = getHeight(current.Left);
			int r = getHeight(current.Right);
			int b_factor = l - r;
			return b_factor;
		}
		/// <summary>
		/// Simple Left-Left rotate
		/// </summary>
		/// <param name="parent"></param>
		/// <returns></returns>
		protected TNode RotateLL(TNode parent)
		{
			TNode child = parent.Left;
			parent.Left = child.Right;
			child.Right = parent;
			return child;
		}
		/// <summary>
		/// Complex rotate first of single Right rotating after then Call LL rotate
		/// </summary>
		/// <param name="parent"></param>
		/// <returns></returns>
		protected TNode RotateRL(TNode parent)
		{
			TNode child = parent.Right;
			parent.Right = RotateLL(child);
			return RotateRR(parent);
		}

		/// <summary>
		/// Simple Right-Right rotate
		/// </summary>
		/// <param name="parent"></param>
		/// <returns></returns>
		protected TNode RotateRR(TNode parent)
		{
			TNode child = parent.Right;
			parent.Right = child.Left;
			child.Left = parent;
			return child;
		}
		/// <summary>
		/// Complex rotate first of single Left rotating after then Call RR rotate
		/// </summary>
		/// <param name="parent"></param>
		/// <returns></returns>
		protected TNode RotateLR(TNode parent)
		{
			TNode child = parent.Left;
			parent.Left = RotateRR(child);
			return RotateLL(parent);
		}

		/// <summary>
		/// Print all Tree to Console window
		/// </summary>
		public void ConsolePrint()
		{
			_root.Print();
		}
	}
}
