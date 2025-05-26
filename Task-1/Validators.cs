namespace ObjectOrientedProgrammingTasks;

static class Validators
{
    public static int NumberValidator()
    {
        while (true)
        {
            Console.Write("Введите количество создаваемых вами Person: ");
            string? str = Console.ReadLine();

            if (int.TryParse(str, out int number))
            {
                return number;
            }

            Console.WriteLine("Ошибка: не удалось преобразовать введенные данные в целое число!");
        }
    }

    public static string NameValidator()
    {
        while (true)
        {
            Console.Write("Введите имя: ");
            string? name = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Ошибка: введенное имя не может быть пустым!");
                continue;
            }

            if (!(2 <= name.Length && name.Length <= 16))
            {
                Console.WriteLine("Ошибка: имя должно содержать от 2 до 16 букв включительно!");
                continue;
            }

            if (!IsRussianLetters(name))
            {
                Console.WriteLine("Ошибка: имя должно содержать только русские буквы!");
                continue;
            }

            return char.ToUpper(name[0]) + name[1..];
        }

        bool IsRussianLetters(string word)
        {
            foreach (char letter in word)
            {
                if (!('а' <= letter && letter <= 'я' || letter == 'ё'))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
