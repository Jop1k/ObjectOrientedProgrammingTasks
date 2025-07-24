namespace SixthTask;

internal class Circle : Shape
{
    protected double _radius;

    public Circle(double radius, double xCoordinate = 0, double yCoordinate = 0) : base(xCoordinate, yCoordinate)
    {
        _radius = radius;
    }

    public override double Area() => Math.PI * _radius * _radius;

    public override double Perimeter() => 2 * Math.PI * _radius;
}
