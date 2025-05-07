namespace ObjectOrientedProgrammingTasks;

static class Validators
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

            Console.Write("Введите число: ");
            str = Console.ReadLine()!;
        }
    }

    public static string NameValidator(string name)
    {
        bool flag;

        while (true)
        {
            flag = true;

            name = name.Trim().ToLower();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Вы ничего не ввели");
                Console.Write("Повторно введите имя: ");
                name = Console.ReadLine()!;
                continue;
            }

            foreach (char c in name)
            {
                if (!('а' <= c && c <= 'я'))
                {
                    Console.WriteLine("Введите имя используя только русские буквы");
                    Console.Write("Повторно введите имя: ");
                    name = Console.ReadLine()!;
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                return name[0].ToString().ToUpper() + name[1..];
            }
        }
    }
}
