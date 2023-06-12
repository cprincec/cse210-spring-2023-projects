using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("red", 5);
        Rectangle rectangle = new Rectangle("Green", 5, 10);
        Circle circle = new Circle("Yellow", 3);

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine(area);
            Console.WriteLine(color);
        }
    }
}