using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNode;

namespace Algorytms.Abstract
{
	public abstract class AbstractList<T>
	{
		internal Node<T> Head;
		internal Node<T> Tail;
		/// <summary>
		/// Constructor for init Head, Tail, Count
		/// </summary>
		internal AbstractList()
		{
			Head = null;
			Tail = Head;
			Count = 0;
		}

		/// <summary>
		/// Return Count of Nodes from LinkedList
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// Indexator for LinkedList
		/// </summary>
		/// <param name="index">index</param>
		/// <returns>subject Node<typeparamref name="T">Type</typeparamref> </returns>
		public Node<T> this[int index]
		{
			get
			{
				if (index >= 0 && index < Count)
				{
					int counter = 0;
					var Current = Head;
					while (counter++ < index)
						Current = Current.Next;
					return Current;
				}
				return Head;
			}
		}

		/// <summary>
		/// Find Node which pass the predicate requirements
		/// </summary>
		/// <param name="predicate">condition , what will you want to found</param>
		/// <returns>subject Node<typeparamref name="T">Type</typeparamref> </returns>
		public Node<T> Find(Predicate<T> predicate)
		{
			if (predicate == null) throw new ArgumentNullException("Argument is Null!");

			var Current = Head;
			while (Current != null)
			{
				if (predicate.Invoke(Current.Data))
					return Current;
				Current = Current.Next;
			}
			return Head;
		}

		
		public virtual void Clear()
		{
			Head = null;
			Tail = Head;
			Count = 0;
		}

		
		public override string ToString()
		{
			StringBuilder output = new StringBuilder();
			var Node = Head;

			if (Head != null)
				output.AppendLine($"Head = [{Head.Data}]");
			else
				output.AppendLine($"Head = [null]");

			while (Node != null)
			{
				output.AppendFormat($"[{Node.Data}]->");
				Node = Node.Next;
			}
			output.AppendLine($"[null];");

			return output.ToString();
		}
	}
}
