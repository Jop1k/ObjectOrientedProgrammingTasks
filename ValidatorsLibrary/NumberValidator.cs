namespace ValidatorsLibrary;

public static class NumberValidator
{
    private const int _minValue = 1;
    private const int _maxValue = 100;

    public static int Validation(string text = "Введите число: ")
    {
        while (true)
        {
            Console.Write(text);
            string? potentialNumber = Console.ReadLine();

            if (TryValidateNumber(potentialNumber, out int number, out string? errorMessage))
            {
                return number;
            }

            Console.WriteLine(errorMessage);
            Console.WriteLine("Повторите попытку!");
        }
    }

    private static bool TryValidateNumber(string? inputValue, out int number, out string? errorMessage)
    {
        errorMessage = null;

        if (!int.TryParse(inputValue, out number))
        {
            errorMessage = "Ошибка: не удалось преобразовать введенные данные в целое число!";
            return false;
        }

        if (!CheckCorrectRangeOfValues(number))
        {
            errorMessage = $"Ошибка: число не должно быть меньше {_minValue} или больше {_maxValue}!";
            return false;
        }

        return true;
    }

    private static bool CheckCorrectRangeOfValues(int number)
    {
        return _minValue <= number && number <= _maxValue;
    }
}
