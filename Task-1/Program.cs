namespace ObjectOrientedProgrammingTasks;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество создаваемых вами Person: ");
        int count = Validators.NumberValidator(Console.ReadLine()!);

        var persons = CreatePersons(CreateListOfNames(count));

        foreach (var person in persons)
        {
            Console.WriteLine($"Привет! Меня зовут {person}");
        }
    }

    static string[] CreateListOfNames(int count)
    {
        var names = new string[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Введите {i + 1} имя: ");
            names[i] = Validators.NameValidator(Console.ReadLine()!)!;
        }

        return names;
    }

    static Person[] CreatePersons(string[] names)
    {
        var persons = new Person[names.Length];

        for (int i = 0; i < persons.Length; ++i)
        {
            persons[i] = new Person(names[i]);
        }

        return persons;
    }
}
