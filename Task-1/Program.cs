namespace Task_1;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество создаваемых вами Person:");
        int count = Validator(Console.ReadLine()!);

        Person[] persons = CreatePersons(["test-1", "test-2"]);
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

            Console.WriteLine("Введите число или цифру:");
            str = Console.ReadLine()!;
        }
    }
}
