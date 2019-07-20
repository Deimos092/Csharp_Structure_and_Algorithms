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
        internal AbstractList()
        {
            Head = null;
			Tail = Head;
            Count = 0;
        }

        public int Count { get; set; }

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
        public virtual Node<T> Find(Predicate<T> predicate)
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
