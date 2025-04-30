namespace Task_1;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество создаваемых вами Person:");
        int count = Validator(Console.ReadLine()!);

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
