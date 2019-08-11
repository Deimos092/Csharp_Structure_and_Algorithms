using System;
using System.Text;
using Algorytms.Lists;
using Algorytms;
using Algorytms.Trees;

namespace Algorytms
{
	class Program
	{
		static private int CountItems { get => 25; }
		private static int RndMax { get => 10; }
		private static int RndMin { get => -10; }

		public static void CreateList(Random rnd)
		{
			AVLTree aVL = new AVLTree();

			for (int i = 0; i < CountItems; i++)
			{
				aVL.Inser(rnd.Next(RndMin,RndMax));
			}

			aVL.ConsolePrint();
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
