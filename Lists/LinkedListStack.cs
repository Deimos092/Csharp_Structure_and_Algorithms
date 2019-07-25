using System;
using Algorytms.Abstract;

namespace Algorytms.Lists
{
    public class LinkedListStack<T> : AbstractList<T>
    {
		/// <summary>
		/// Init empty Constructor 
		/// </summary>
		public LinkedListStack() : base()
        { }

		/// <summary>
		/// Add new node with data to Head of Stack
		/// </summary>
		/// <param name="data">data value</param>
        public void Push(T data)
        {
            var Node = new Node<T>(data);
            Node.Next = Head ?? null;
            Head = Node;
            Count++;
        }

		/// <summary>
		/// Remove Firs Node from Head of Stack 
		/// </summary>
		/// <returns>Node of data</returns>
        public T Pop()
        {
            var Popitem = Head;
            Head = Head.Next;
            Count--;
            return Popitem.Data;
        }

		/// <summary>
		/// Show first Node in Stack List or return NullReferenceException
		/// </summary>
		/// <returns>Node of data</returns>
		public T Peek()
        {
            if (Head == null)
                throw new NullReferenceException("Stack is Clear!");
            else
                return Head.Data;
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
