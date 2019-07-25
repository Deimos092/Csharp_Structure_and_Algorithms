using System;

namespace Algorytms.Abstract
{
	public class Node<T>
	{

		private T _data;//приватное поле данных

		public Node() { }//стандартный конструктор без параметров

		public Node(T data)//конструктор с парметром данных
		{
			Data = data;
			Next = null;
		}

		public T Data //Открытое поле данных где сразу идет проверка на входные данные
		{
			get => _data;
			set
			{
				if (value == null)//Проверка на пустые входящие данные
					throw new ArgumentException(nameof(value));//Вызываем ошибку
				else
					_data = value;
			}
		}

		public Node<T> Next { get; set; }//Открытое поле указателя
		public Node<T> Previous { get; set; }

		//Переопределнный метод ToString() просто для вывода данных на экран пользователя
		public override string ToString()
		{
			return Data.ToString();
		}
	}
}
