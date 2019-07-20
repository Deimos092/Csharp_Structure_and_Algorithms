using System;
using Algorytms.Abstract;

namespace Algorytms.Lists
{
	public class LinkedListQueue<T> : AbstractList<T>
	{
		public LinkedListQueue() : base()
		{
			Tail = null;
		}

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

		public T Dequeue()
		{
			if (Head == null) throw new Exception("Queue is Empty");

			Node<T> Result = Head;
			Head = Head.Next;

			Count--;
			return Result.Data;
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
