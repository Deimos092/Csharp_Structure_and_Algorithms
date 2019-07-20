using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorytms.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorytms.Trees;

namespace Algorytms.Lists.Test
{
    [TestClass()]
    public class AlgorytmUnitTests
    {
        private int CountItems { get => 1000; }
        private int RndMax { get => 10; }
        private int RndMin { get => -10; }

        [TestMethod()]
        public void LinkedListTest()
        {
            LinkedList<int> myList = new LinkedList<int>();

            Random random = new Random();
            for (int i = 0; i < CountItems; i++)
                myList.Add(i);

            for (int i = 0; i < CountItems; i++)
                if (random.Next(i - RndMax, i + RndMin) == i)
                    myList.Remove(i);
        }

		[TestMethod()]
		public void LinkedListDoubleTest()
		{
			LinkedListDouble<int> myList = new LinkedListDouble<int>();

			Random random = new Random();
			for (int i = 0; i < CountItems; i++)
				myList.AddFirst(i);

			for (int i = 0; i < CountItems; i++)
				if (random.Next(i - RndMax, i + RndMin) == i)
					myList.Remove(i);
		}

		[TestMethod]
        public void LinkedListStack()
        {
            Random random = new Random();
            LinkedListStack<string> Stacklist = new LinkedListStack<string>();

            for (int i = 0; i < CountItems; i++)
                Stacklist.Push($"{i.ToString()}");

            for (int i = 0; i < CountItems; i++)
                if (random.Next(i - RndMax, i + RndMin) == i)
                    Stacklist.Pop();
        }

        [TestMethod]
        public void LinkedListQueue()
        {
            Random random = new Random();
            LinkedListQueue<string> Stacklist = new LinkedListQueue<string>();

            for (int i = 0; i < CountItems; i++)
                Stacklist.Enqueue($"{i.ToString()}");

            for (int i = 0; i < CountItems; i++)
                if (random.Next(i - RndMax, i + RndMin) == i)
                    Stacklist.Dequeue();
        }

        [TestMethod]
        public void BSTTree()
        {
            BinarySearchTree BST = new BinarySearchTree(0);

            Random random = new Random();
            for (int i = 0; i < CountItems; i++)
            {
                BST.Inser(random.Next(RndMin * 10, RndMax * 10));
            }

			for (int i = 0; i < CountItems; i++)
			{
				BST.Search(random.Next(RndMin * 10, RndMax * 10));
			}
        }

		[TestMethod]
		public void AVLTree_OnlyADD()
		{
			AVLTree AVL = new AVLTree(0);
			Random random = new Random();
			for (int i = 0; i < CountItems; i++)
			{
				AVL.Inser(random.Next(RndMin * 10, RndMax * 10));
			}
		}
	}
}