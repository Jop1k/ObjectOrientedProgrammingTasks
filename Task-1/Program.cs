namespace Task_1;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество создаваемых вами Person: ");
        int count = Validator(Console.ReadLine()!);

        string[] names = CreateListOfNames(count);

        Person[] persons = CreatePersons(names);

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
            names[i] = Console.ReadLine()!;
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
    static int Validator(string str)
    {
        while (true)
        {
            int number;

            if (int.TryParse(str, out number))
            {
                return number;
            }

            Console.Write("Введите число или цифру: ");
            str = Console.ReadLine()!;
        }
    }
}
