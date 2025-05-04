namespace Task_1;

static class Validator
{
    public static int NumberValidator(string str)
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
