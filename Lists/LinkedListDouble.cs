using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorytms.Abstract;

namespace Algorytms.Lists
{
	public class LinkedListDouble<T> : AbstractList<T>
	{
		public LinkedListDouble() : base() { }

		public LinkedListDouble(T data) : base()
		{
			AddFirst(data);
		}

		/// <summary>
		/// Add new node to Head of List
		/// </summary>
		/// <param name="data">Data value</param>
		public void AddFirst(T data)
		{
			Node<T> newNode = new Node<T>(data);

			newNode.Next = Head;
			newNode.Previous = null;

			if (Head != null)
			{
				Head.Previous = newNode;
			}
			Head = newNode;
			Count++;
		}

		/// <summary>
		/// Add new node to Back of List
		/// </summary>
		/// <param name="data">Data value</param>
		public void AddLast(T data)
		{
			Node<T> newNode = new Node<T>(data);
			if (Head == null)
			{
				newNode.Previous = null;
				Head = newNode;
				return;
			}
			Node<T> lastNode = GetLastNode();
			lastNode.Next = newNode;
			newNode.Previous = lastNode;
			Count++;

		}

		/// <summary>
		/// Add new node after Target node of List
		/// </summary>
		/// <param name="node">Target node</param>
		/// <param name="data">Data value</param>
		public void AddAfter(Node<T> node, T data)
		{
			if (node == null) throw new NullReferenceException();

			Node<T> newNode = new Node<T>(data);
			newNode.Next = node.Next;

			node.Next = newNode;
			newNode.Previous = node;
			if (newNode.Next != null)
			{
				newNode.Next.Previous = newNode;
			}
			Count++;
		}
		internal Node<T> GetLastNode()
		{
			Node<T> temp = Head;
			while (temp.Next != null)
				temp = temp.Next;
			return temp;
		}


		/// <summary>
		/// Find and delete node with current data
		/// </summary>
		/// <param name="data">data value</param>
		public void Remove(T data)
		{
			Node<T> temp = Head;
			if (temp != null && temp.Data.Equals(data))
			{
				Head = temp.Next;
				Head.Previous = null;
				return;
			}
			while (temp != null && temp.Data.Equals(data))
			{
				temp = temp.Next;
			}
			if (temp == null)
			{
				return;
			}
			if (temp.Next != null)
			{
				temp.Next.Previous = temp.Previous;
			}
			if (temp.Previous != null)
			{
				temp.Previous.Next = temp.Next;
			}
			Count--;
		}

		public override void Clear()
		{
			base.Clear();
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}
