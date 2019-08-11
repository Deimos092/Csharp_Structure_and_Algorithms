using System;
using ShapeCalculater.Shapes;

namespace TestShapeLib
{
	class Program
	{
		static void Main(string[] args)
		{

			Triangle triangle = new Triangle(4, 3, 5);
			Console.WriteLine(triangle.ToString());
			Console.WriteLine($"Is this Triangle : {triangle.IsThisTriangle}");

			Console.ReadLine();
		}
	}
}
