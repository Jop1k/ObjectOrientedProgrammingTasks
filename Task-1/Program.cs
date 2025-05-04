namespace Task_1;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество создаваемых вами Person: ");
        int count = Validators.NumberValidator(Console.ReadLine()!);

        Person[] persons = CreatePersons(CreateListOfNames(count));

        foreach (Person person in persons)
        {
            Console.WriteLine($"Привет! Меня зовут {person}");
        }
    }
    static string[] CreateListOfNames(int count)
    {
        string[] names = new string[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Введите {i + 1} имя: ");
            names[i] = Validators.NameValidator(Console.ReadLine()!)!;
        }

        return names;
    }
    static Person[] CreatePersons(string[] names)
    {
        Person[] persons = new Person[names.Length];

        for (int i = 0; i < persons.Length; ++i)
        {
            persons[i] = new Person(names[i]);
        }

        return persons;
    }
}
