using Helper;

namespace EighthTask;

internal class Program
{
    static void Main()
    {
        var dog = new Dog { Name = ConsoleHelper.TryReadValidName() };

        Console.WriteLine(dog.Name);
        dog.Eat();
    }
}
