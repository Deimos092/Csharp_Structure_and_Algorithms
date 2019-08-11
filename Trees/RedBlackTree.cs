using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorytms.Abstract;

namespace Algorytms.Trees
{
	public class RedBlackTree : AVLTree
	{
		TNode root;

		public RedBlackTree()
		{

		}

		public RedBlackTree(int data, TNode.ColorEnum color = TNode.ColorEnum.Red)
		{
			root = new TNode(data);
			root.Color = color;
		}

		public override void Inser(int data)
		{
			TNode newNode = new TNode(data);
			if (root == null)
			{
				root = newNode;
				root.Color = TNode.ColorEnum.Black;
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
			newNode.Color = TNode.ColorEnum.Red;//colour the new node red
			InsertFixUp(newNode);//call method to check for violations and fix
		}
		private void InsertFixUp(TNode node)
		{
			//Checks Red-Black Tree properties
			while (node != root && node.Parent.Color == TNode.ColorEnum.Red)
			{
				/*We have a violation*/
				if (node.Parent == node.Parent.Parent.Left)
				{
					TNode Anode = node.Parent.Parent.Right;
					if (Anode != null && Anode.Color == TNode.ColorEnum.Red)//Case 1: uncle is red
					{
						node.Parent.Color = TNode.ColorEnum.Black;
						Anode.Color = TNode.ColorEnum.Black;
						node.Parent.Parent.Color = TNode.ColorEnum.Red;
						node = node.Parent.Parent;
					}
					else //Case 2: uncle is black
					{
						if (node == node.Parent.Right)
						{
							node = node.Parent;
							LeftRotate(node);
						}
						//Case 3: recolour & rotate
						node.Parent.Color = TNode.ColorEnum.Black;
						node.Parent.Parent.Color = TNode.ColorEnum.Red;
						RightRotate(node.Parent.Parent);
					}

				}
				else
				{
					//mirror image of code above
					TNode Bnode = null;

					Bnode = node.Parent.Parent.Left;
					if (Bnode != null && Bnode.Color == TNode.ColorEnum.Black)//Case 1
					{
						node.Parent.Color = TNode.ColorEnum.Red;
						Bnode.Color = TNode.ColorEnum.Red;
						node.Parent.Parent.Color = TNode.ColorEnum.Black;
						node = node.Parent.Parent;
					}
					else //Case 2
					{
						if (node == node.Parent.Left)
						{
							node = node.Parent;
							RightRotate(node);
						}
						//Case 3: recolour & rotate
						node.Parent.Color = TNode.ColorEnum.Black;
						node.Parent.Parent.Color = TNode.ColorEnum.Red;
						LeftRotate(node.Parent.Parent);
					}

				}
				root.Color = TNode.ColorEnum.Black;//re-colour the root black as necessary
			}
		}
		/// <summary>
		/// Left Rotate
		/// </summary>
		/// <param name="X"></param>
		/// <returns>void</returns>
		private void LeftRotate(TNode X)
		{
			TNode Y = X.Right; // set Y
			X.Right = Y.Left;//turn Y's left subtree into X's right subtree
			if (Y.Left != null)
			{
				Y.Left.Parent = X;
			}
			if (Y != null)
			{
				Y.Parent = X.Parent;//link X's parent to Y
			}
			if (X.Parent == null)
			{
				root = Y;
			}
			if (X == X.Parent.Left)
			{
				X.Parent.Left = Y;
			}
			else
			{
				X.Parent.Right = Y;
			}
			Y.Left = X; //put X on Y's left
			if (X != null)
			{
				X.Parent = Y;
			}

		}
		/// <summary>
		/// Rotate Right
		/// </summary>
		/// <param name="Y"></param>
		/// <returns>void</returns>
		private void RightRotate(TNode Y)
		{
			// right rotate is simply mirror code from left rotate
			TNode X = Y.Left;
			Y.Left = X.Right;
			if (X.Right != null)
			{
				X.Right.Parent = Y;
			}
			if (X != null)
			{
				X.Parent = Y.Parent;
			}
			if (Y.Parent == null)
			{
				root = X;
			}
			if (Y == Y.Parent.Right)
			{
				Y.Parent.Right = X;
			}
			if (Y == Y.Parent.Left)
			{
				Y.Parent.Left = X;
			}

			X.Right = Y;//put Y on X's right
			if (Y != null)
			{
				Y.Parent = X;
			}
		}
		public new void ConsolePrint()
		{
			root.Print();
		}
	}
}
