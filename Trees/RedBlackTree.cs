using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorytms.Abstract;

namespace Algorytms.Trees
{
	class RedBlackTree : AVLTree
	{
		TNode root;

		public RedBlackTree()
		{
			root = null;
		}

		public RedBlackTree(int data)
		{
			root = new TNode(data);
			root.Colors = TNode.Color.Red;
		}

		public RedBlackTree(TNode.Color color)
		{
			root.Colors = color;
		}

		public RedBlackTree(int data, TNode.Color color = TNode.Color.Red)
		{
			root = new TNode(data);
			root.Colors = color;
		}

		public override void Inser(int data)
		{
			TNode newNode = new TNode(data);
			if (root == null)
			{
				root = newNode;
				root.Colors = TNode.Color.Black;
				return;
			}
			TNode Anode = null;
			TNode Bnode = root;

			while (Bnode != null)
			{
				Anode = Bnode;
				if (newNode.Data < Bnode.Data)
				{
					Bnode = Bnode.Left;
				}
				else
				{
					Bnode = Bnode.Right;
				}
			}

			newNode.Parent = Anode;
			if (Anode == null)
			{
				root = newNode;
			}
			else if (newNode.Data < Anode.Data)
			{
				Anode.Left = newNode;
			}
			else
			{
				Anode.Right = newNode;
			}
			newNode.Left = null;
			newNode.Right = null;
			newNode.Colors = TNode.Color.Red;//colour the new node red
			InsertFixUp(newNode);//call method to check for violations and fix
		}
		private void InsertFixUp(TNode node)
		{
			//Checks Red-Black Tree properties
			while (node != root && node.Parent.Colors == TNode.Color.Red)
			{
				/*We have a violation*/
				if (node.Parent == node.Parent.Parent.Left)
				{
					TNode Anode = node.Parent.Parent.Right;
					if (Anode != null && Anode.Colors == TNode.Color.Red)//Case 1: uncle is red
					{
						node.Parent.Colors = TNode.Color.Black;
						Anode.Colors = TNode.Color.Black;
						node.Parent.Parent.Colors = TNode.Color.Red;
						node = node.Parent.Parent;
					}
					else //Case 2: uncle is black
					{
						if (node == node.Parent.Right)
						{
							node = node.Parent;
							RotateLR(node);
						}
						//Case 3: recolour & rotate
						node.Parent.Colors = TNode.Color.Black;
						node.Parent.Parent.Colors = TNode.Color.Red;
						RotateRR(node.Parent.Parent);
					}

				}
				else
				{
					//mirror image of code above
					TNode Bnode = null;

					Bnode = node.Parent.Parent.Left;
					if (Bnode != null && Bnode.Colors == TNode.Color.Black)//Case 1
					{
						node.Parent.Colors = TNode.Color.Red;
						Bnode.Colors = TNode.Color.Red;
						node.Parent.Parent.Colors = TNode.Color.Black;
						node = node.Parent.Parent;
					}
					else //Case 2
					{
						if (node == node.Parent.Left)
						{
							node = node.Parent;
							RotateRR(node);
						}
						//Case 3: recolour & rotate
						node.Parent.Colors = TNode.Color.Black;
						node.Parent.Parent.Colors = TNode.Color.Red;
						RotateLR(node.Parent.Parent);
					}

				}
				root.Colors = TNode.Color.Black;//re-colour the root black as necessary
			}
		}
		public new void ConsolePrint()
		{
			root.Print();
		}
	}
}
