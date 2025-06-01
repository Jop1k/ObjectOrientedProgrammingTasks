global using ValidatorsLibrary;

namespace FirstTask;

internal class Program
{
    static void Main()
    {
        int amount = ConsoleInputHelper.TryReadValidNumber();

        Enumerable.Range(0, amount)
            .Select(_ => ConsoleInputHelper.TryReadValidName())
            .Select(name => new Person(name))
            .ToList()
            .ForEach(person => Console.WriteLine($"Привет! Меня зовут {person}"));
    }
}