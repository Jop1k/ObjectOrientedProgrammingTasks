using Helper;

namespace Task1PersonCollectionToString;

internal class Program
{
    static void Main()
    {
        int amount = ConsoleHelper.TryReadValidNumber();

        Enumerable.Range(0, amount)
            .Select(_ => ConsoleHelper.TryReadValidName())
            .Select(name => new Person(name))
            .ToList()
            .ForEach(Console.WriteLine);
    }
}