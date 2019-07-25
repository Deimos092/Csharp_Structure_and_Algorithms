using System;
using System.Text;
using Algorytms.Lists;
using Algorytms;
using Algorytms.Trees;

namespace Algorytms
{
	class Program
	{
		static private int CountItems { get => 20; }

		public static void CreateList(Random rnd)
		{
			LinkedList<int> myList = new LinkedList<int>();//Инициализация списка


			for (int i = 0; i < CountItems; i++)
				myList.Add(i);//Добавление элементов в список

			for (int i = 0; i < CountItems; i+= rnd.Next(3))
			{
				myList.Remove(i);//Удаление элементов
			}
			Console.WriteLine($"3й элемент по списку = {myList[2].ToString()}");//Использование индексации из базового класса
			Console.WriteLine($"Найти элемент = 5 : {myList.Find(x => x == 5)}");//Использование поиска из базового класса
			Console.WriteLine(myList.ToString());//Вывод на консоль
		}

		static void Main(string[] args)
		{
			Random random = new Random();
			for (int i = 0; i < 3; i++)
			{
				CreateList(random);
			}
			Console.ReadLine();
		}
	}
}
