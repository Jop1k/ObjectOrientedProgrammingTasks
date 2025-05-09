namespace ObjectOrientedProgrammingTasks;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество создаваемых вами Person: ");
        int amount = Validators.NumberValidator();

        var persons = Creator.CreateListOfNames(amount).Select(name => new Person(name)).ToArray();

        foreach (var person in persons)
        {
            Console.WriteLine($"Привет! Меня зовут {person}");
        }
    }
}