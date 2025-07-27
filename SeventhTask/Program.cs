namespace SeventhTask;

internal class Program
{
    static void Main()
    {
        var car = new Car();
        car.Refuel(int.Parse(Console.ReadLine()!));
        car.Drive();
    }
}
