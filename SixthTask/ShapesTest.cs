namespace SixthTask;

internal static class ShapesTest
{
    public static void RunTest()
    {
        var rectangle = new Rectangle(10, 5, xCoordinate : 1, yCoordinate: 2);
        Console.WriteLine($"Area of a rectangle: {rectangle.Area()} | Perimeter of a rectagnle: {rectangle.Perimeter()} | Location: {rectangle}");

        var circle = new Circle(10);
        Console.WriteLine($"Area of a circle: {circle.Area()} | Perimeter of a circle: {circle.Perimeter()} | Location: {circle}");
    }
}
