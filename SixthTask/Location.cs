namespace SixthTask;

internal class Location
{
    private double _x;
    private double _y;

    public Location(double x, double y)
    {
        _x = x;
        _y = y;
    }

    public override string ToString() => $"X: {_x} | Y: {_y}";
}
