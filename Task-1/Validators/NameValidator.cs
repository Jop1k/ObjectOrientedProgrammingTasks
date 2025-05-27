namespace ObjectOrientedProgrammingTasks;

internal class NameValidator
{
    private const int _minLength = 2;
    private const int _maxLength = 16;

    public static string Validation(string text = "Введите имя: ")
    {
        while (true)
        {
            Console.Write(text);
            string? name = Console.ReadLine()?.Trim().ToLower();

            if (TryValidateName(name, out string? errorMessage))
            {
                return char.ToUpper(name![0]) + name[1..];
            }

            Console.WriteLine(errorMessage);
            Console.WriteLine("Повторите попытку!");
        }
    }

    private static bool TryValidateName(string? inputName, out string? errorMessage)
    {
        errorMessage = null;

        if (string.IsNullOrWhiteSpace(inputName))
        {
            errorMessage = "Ошибка: введенное имя не может быть пустым!";
            return false;
        }

        if (!CheckCorrectLength(inputName))
        {
            errorMessage = $"Ошибка: имя должно содержать от {_minLength} до {_maxLength} букв включительно!";
            return false;
        }

        if (!IsRussianLetters(inputName))
        {
            errorMessage = "Ошибка: имя должно содержать только русские буквы!";
            return false;
        }

        return true;
    }

    private static bool CheckCorrectLength(string word)
    {
        return _minLength <= word.Length && word.Length <= _maxLength;
    }

    private static bool IsRussianLetters(string word)
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
