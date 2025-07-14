using ValidatorLibrary;
using ExtensionMethods;

namespace Helper;

public static class ConsoleInputHelper
{
    public static int TryReadValidNumber()
    {
        while (true)
        {
            int number = TryReadNumber();

            ValidationResult result = new NumberValidator(number)
                .MinValue(1)
                .MaxValue(20)
                .ValidationResult;

            if (result.IsValid)
            {
                return number;
            }

            ConsoleLogger.LogValidationErrors(result);
        }
    }

    private static int TryReadNumber()
    {
        while (true)
        {
            Console.Write("Введите количество создаваемых Person: ");
            string potentialNumber = Console.ReadLine()!;

            ValidationResult result = new StringValidator(potentialNumber)
                .IsNotNullOrWhiteSpace()
                .IsNumber()
                .ValidationResult;

            if (result.IsValid)
            {
                return int.Parse(potentialNumber);
            }

            ConsoleLogger.LogValidationErrors(result);
            Console.WriteLine("Повторите попытку!");
        }
    }

    public static string TryReadValidName()
    {
        while (true)
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine()!;

            var validator = new StringValidator(name);

            ValidationResult result = validator
                .IsNotNullOrWhiteSpace()
                .IsRussianLetters()
                .MinLength(2)
                .MaxLength(16)
                .ValidationResult;

            if (result.IsValid)
            {
                return validator.VerifiableString.Сapitalize();
            }

            ConsoleLogger.LogValidationErrors(result);
            Console.WriteLine("Повторите попытку!");
        }
    }
}
