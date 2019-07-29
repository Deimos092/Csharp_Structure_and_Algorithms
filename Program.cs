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
		private static int RndMax { get => 10; }
		private static int RndMin { get => -10; }


		public static void CreateList(Random rnd)
		{
			AVLTree AVL = new AVLTree(0);

			for (int i = 0; i < CountItems; i++)
			{
				AVL.Inser(rnd.Next(RndMin * 10, RndMax * 10));
			}

			AVL.ConsolePrint();
		}

		static void Main(string[] args)
		{
			Random random = new Random();
			for (int i = 0; i < 10; i++)
			{
				CreateList(random);
			}
			Console.ReadLine();
		}
	}
}
