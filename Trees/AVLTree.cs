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

		public AVLTree() { }

		public AVLTree(int data)
		{
			_root = new TNode(data);
		}
		
		public void Inser(int data)
		{
			TNode node = new TNode(data);
			if(_root == null)
			{
				_root = node;
			}
			else
			{
				_root = RecursiveInsert(_root, node);
			}
		}

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

		private TNode balance_tree(TNode current)
		{
			int b_factor = balance_factor(current);
			if (b_factor > 1)
			{
				if (balance_factor(current.Left) > 0)
				{
					current = RotateLL(current);
				}
				else
				{
					current = RotateLR(current);
				}
			}
			else if (b_factor < -1)
			{
				if (balance_factor(current.Right) > 0)
				{
					current = RotateRL(current);
				}
				else
				{
					current = RotateRR(current);
				}
			}
			return current;
		}

		private int max(int left, int right)
		{
			return Math.Max(left, right);
		}

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

		private int balance_factor(TNode current)
		{
			int l = getHeight(current.Left);
			int r = getHeight(current.Right);
			int b_factor = l - r;
			return b_factor;
		}
		private TNode RotateLL(TNode parent)
		{
			TNode child = parent.Left;
			parent.Left = child.Right;
			child.Right = parent;
			return child;
		}
		private TNode RotateLR(TNode parent)
		{
			TNode child = parent.Left;
			parent.Left = RotateRR(child);
			return RotateLL(parent);
		}
		private TNode RotateRR(TNode parent)
		{
			TNode child = parent.Right;
			parent.Right = child.Left;
			child.Left = parent;
			return child;
		}
		private TNode RotateRL(TNode parent)
		{
			TNode child = parent.Right;
			parent.Right = RotateLL(child);
			return RotateRR(parent);
		}
		public void ConsolePrint()
		{
			_root.Print();
		}
	}
}
