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
			RedBlackTree myList = new RedBlackTree();

			for (int i = 0; i < CountItems; i++)
				myList.Inser(i);

			myList.ConsolePrint();
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
