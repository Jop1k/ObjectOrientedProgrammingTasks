namespace Task6UMLDiagram;

internal abstract class Shape
{
    protected Location _location;

    protected Shape(Location location) => _location = location;

    public abstract double Area();

    public abstract double Perimeter();

    public override string ToString() => $"Location: {_location.ToString()}\nType: {GetType().Name}";
}
