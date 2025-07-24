namespace SixthTask;

internal abstract class Shape
{
    protected Location _c;

    protected Shape(double xCoordinate = 0, double yCoordinate = 0) => _c = new Location(xCoordinate, yCoordinate);

    public abstract double Area();

    public abstract double Perimeter();

    public override string ToString() => _c.ToString();
}
