namespace SixthTask;

internal class Circle : Shape
{
    protected double _radius;

    public Circle(double radius, Location location) : base(location)
    {
        _radius = radius;
    }

    public override double Area() => Math.PI * _radius * _radius;

    public override double Perimeter() => 2 * Math.PI * _radius;
}
