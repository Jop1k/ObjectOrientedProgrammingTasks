using ValidatorLibrary;
using ExtensionMethods;

namespace Helper;

public static class ConsoleHelper
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
            Console.WriteLine("Please try again!");
        }
    }

    public static string TryReadValidName()
    {
        while (true)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine()!;

            var validator = new StringValidator(name);

            ValidationResult result = validator
                .IsNotNullOrWhiteSpace()
                .IsEnglishLetters()
                .MinLength(2)
                .MaxLength(16)
                .ValidationResult;

            if (result.IsValid)
            {
                return validator.VerifiableString.Сapitalize();
            }

            PrintErrors(result);
            Console.WriteLine("Please try again!");
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
            Console.Write("Enter the number of persons to create: ");
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
            Console.WriteLine("Please try again!");
        }
    }
}
