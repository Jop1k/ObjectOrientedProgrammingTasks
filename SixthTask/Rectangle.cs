using System.Transactions;

namespace SixthTask;

internal class Rectangle : Shape
{
    protected double _height;
    protected double _width;

    public Rectangle(double height, double width, Location location) : base(location)
    {
         _width = width;
        _height = height;
    }

    public override double Area() => _height * _width;

    public override double Perimeter() => 2 * (_height + _width);
}
