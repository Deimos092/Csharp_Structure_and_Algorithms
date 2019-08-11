using System;
using ShapeCalculater.Shapes;
using ShapeCalculater.Core.Abstract;

namespace TestShapeLib
{
	class Program
	{
		static void Main(string[] args)
		{

			Triangle triangle = new Triangle(4, 3, 5);

			Shape shape = triangle;
			shape.CalcArea(5, 5, 7);
			Console.WriteLine(shape.Area);

			Console.ReadLine();
		}
	}
}
