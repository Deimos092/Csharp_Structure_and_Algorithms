using System;
using Algorytms.Abstract;
using System.Collections.Generic;
using System.Collections;

namespace Algorytms.Lists
{
	public class LinkedList<T> : AbstractList<T>, IEnumerable<T>
	{
		public LinkedList() : base() { }

		/// <summary>
		/// Добавить данные в связный список.
		/// </summary>
		/// <param name="data"></param>
		public void Add(T data)
		{
			//Create new node with new data
			Node<T> NewNode = new Node<T>(data);

			if (Head == null)// if head ref is null we add new node to head another add to tail
			{
				Head = NewNode;// add first node to head reference
			}
			else
			{
				Tail.Next = NewNode;// Add new node to tail list
			}
			Tail = NewNode;// move reference to last node

			Count++;
		}
		/// <summary>
		/// Remove data from linked list.
		/// Execute removing first data in.
		/// </summary>
		/// <param name="data"> The data woud be delete </param>
		public void Remove(T data)
		{
			// Dont foget to chek on null.
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}
			// Current observe node element.
			Node<T> Current = Head;
			// Previouse elemet before removing element.
			Node<T> Previous = null;

			// Walk all elements in linkedlist to end of it,
			// or while not found current elemnt with data.
			while (Current != null)
			{
				// Если данные обозреваемого элемента совпадают с удаляемыми данными,
				// то выполняем удаление текущего элемента учитывая его положение в цепочке.
				if (Current.Data.Equals(data))
				{

					// Если элемент находится в середине или в конце списка,
					// выкидываем текущий элемент из списка.
					// Иначе это первый элемент списка,
					// выкидываем первый элемент из списка.
					if (Previous != null)
					{
						// Устанавливаем у предыдущего элемента указатель на следующий элемент от текущего.
						Previous.Next = Current.Next;

						// Если это был последний элемент списка, 
						// то изменяем указатель на крайний элемент списка.
						if (Current.Next == null)
						{
							Tail = Previous;
						}
					}
					else
					{
						// Устанавливаем головной элемент следующим.
						Head = Head.Next;

						// Если список оказался пустым,
						// то обнуляем и крайний элемент.
						if (Head == null)
						{
							Tail = null;
						}
					}
					Count--;
					break;
				}
				// Переходим к следующему элементу списка.
				Previous = Current;
				Current = Current.Next;
			}
		}

		/// <summary>
		/// Вернуть перечислитель, выполняющий перебор всех элементов в связном списке.
		/// </summary>
		/// <returns> Перечислитель, который можно использовать для итерации по коллекции. </returns>
		public IEnumerator<T> GetEnumerator()
		{
			// Перебираем все элементы связного списка, для представления в виде коллекции элементов.
			var current = Head;
			while (current != null)
			{
				yield return current.Data;
				current = current.Next;
			}
		}

		/// <summary>
		/// Вернуть перечислитель, который осуществляет итерационный переход по связному списку.
		/// </summary>
		/// <returns> Объект IEnumerator, который используется для прохода по коллекции. </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			// Просто возвращаем перечислитель, определенный выше.
			// Это необходимо для реализации интерфейса IEnumerable
			// чтобы была возможность перебирать элементы связного списка операцией foreach.
			return ((IEnumerable)this).GetEnumerator();
		}
		public override string ToString()
		{
			return base.ToString();
		}
	}
}
