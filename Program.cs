using System;
using System.Text;
using Algorytms.Lists;
using Algorytms;
using Algorytms.Trees;

namespace Algorytms
{
    class Program
    {
        static private int CountItems { get => 10; }
		static private int RndMax { get => 10; }
		static private int RndMin { get => -10; }

		public static void CreateList()
        {
            Random random = new Random();
			LinkedListDouble<int> myList = new LinkedListDouble<int>();

			for (int i = 0; i < CountItems; i++)
				myList.AddFirst(i);

			Console.WriteLine(myList.ToString());
		}

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
				CreateList();
            }
            Console.ReadLine();
        }
    }
}
