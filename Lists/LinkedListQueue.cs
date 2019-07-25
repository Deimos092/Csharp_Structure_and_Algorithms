using System;
using Algorytms.Abstract;

namespace Algorytms.Lists
{
	public class LinkedListQueue<T> : AbstractList<T>
	{
		/// <summary>
		/// Constructor init Tail field
		/// </summary>
		public LinkedListQueue() : base()
		{
			Tail = null;
		}

		/// <summary>
		/// Add new Node with data to the Tail in List
		/// </summary>
		/// <param name="data">data value</param>
		public void Enqueue(T data)
		{
			var item = new Node<T>(data);
			if (Head == null)
			{
				Head = Tail = item;
			}
			else
			{
				Tail.Next = item;
				Tail = item;
			}
			Count++;
		}

		/// <summary>
		/// Remove Node from Head in List
		/// </summary>
		/// <returns>data of this Node</returns>
		public T Dequeue()
		{
			if (Head == null) throw new Exception("Queue is Empty");

			Node<T> Result = Head;
			Head = Head.Next;

			Count--;
			return Result.Data;
		}

		/// <summary>
		/// Clear all list
		/// Override Clear method from Abstract List
		/// </summary>
		public override void Clear()
		{
			base.Clear();
		}

		/// <summary>
		/// Create string content from linked list
		/// </summary>
		/// <returns>string list "[node.data]->" </returns>
		public override string ToString()
		{
			return base.ToString();
		}
	}
}
