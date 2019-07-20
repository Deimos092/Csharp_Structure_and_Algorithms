using System;
using Algorytms.Abstract;

namespace Algorytms.Lists
{
    public class LinkedListStack<T> : AbstractList<T>
    {

        public LinkedListStack() : base()
        { }

        public void Push(T data)
        {
            var Node = new Node<T>(data);
            Node.Next = Head ?? null;
            Head = Node;
            Count++;
        }

        public T Pop()
        {
            var Popitem = Head;
            Head = Head.Next;
            Count--;
            return Popitem.Data;
        }

        public T Peek()
        {
            if (Head == null)
                throw new NullReferenceException("Stack is Clear!");
            else
                return Head.Data;
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
