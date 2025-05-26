namespace ObjectOrientedProgrammingTasks;

class Program
{
    static void Main()
    {
        int amount = Validators.NumberValidator();

        var persons = Utils.CreateListOfNames(amount).Select(name => new Person(name));

        foreach (var person in persons)
        {
            Console.WriteLine($"Привет! Меня зовут {person}");
        }
    }
}