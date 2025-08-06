namespace SixthTask;

internal static class ShapesTest
{
    public static void RunTest()
    {
        var rectangle = new Rectangle(10, 5, new Location(1, 4));
        Console.WriteLine($"Area of a rectangle: {rectangle.Area()}\nPerimeter of a rectagnle: {rectangle.Perimeter()}\n{rectangle}");

        var circle = new Circle(10, new Location(8, 7));
        Console.WriteLine($"Area of a circle: {circle.Area()}\nPerimeter of a circle: {circle.Perimeter()}\n{circle}");
    }
}
