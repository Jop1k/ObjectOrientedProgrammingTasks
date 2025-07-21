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

            PrintErrors(result);
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

            PrintErrors(result);
            Console.WriteLine("Повторите попытку!");
        }
    }

    private static void PrintErrors(ValidationResult result)
    {
        foreach (var error in result.Errors)
        {
            Console.WriteLine($"Validation error: {error.error} | Error message: {error.errorMessage}");
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
                try
                {
                    return int.Parse(potentialNumber);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            PrintErrors(result);
            Console.WriteLine("Повторите попытку!");
        }
    }
}
