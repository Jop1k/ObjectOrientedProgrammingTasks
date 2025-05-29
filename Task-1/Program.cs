global using ValidatorsLibrary;

namespace FirstTask;

internal class Program
{
    static void Main()
    {
        int amount = NumberValidator.Validation("Введите количество создаваемых вами Person: ");

        Helper.CreateListOfNames(amount)
            .Select(name => new Person(name))
            .ToList()
            .ForEach(person => Console.WriteLine($"Привет! Меня зовут {person}"));
    }
}