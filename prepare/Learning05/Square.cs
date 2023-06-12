public class Square : Shape
{
    private double _side;

    public Square(String color, double side) : base(color)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side * 4;
    }
}