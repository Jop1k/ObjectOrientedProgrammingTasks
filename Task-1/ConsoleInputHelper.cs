namespace FirstTask;

internal static class ConsoleInputHelper
{
    public static int TryReadValidNumber()
    {
        while (true)
        {
            int number = TryReadNumber();

            ValidationResult result = new NumberValidator(number).MinValue(1).MaxValue(20).Validate();

            if (result.IsValid)
            {
                return number;
            }

            result.PrintErrors();
        }

        int TryReadNumber()
        {
            while (true)
            {
                Console.Write("Введите количество создаваемых Person: ");
                string? potentialNumber = Console.ReadLine();

                ValidationResult result = new StringValidator(potentialNumber!).IsNotNullOrWhiteSpace().IsNumber().Validate();

                if (result.IsValid)
                {
                    return int.Parse(potentialNumber!);
                }

                result.PrintErrors();
                Console.WriteLine("Повторите попытку!");
            }
        }
    }

    public static string TryReadValidName()
    {
        while (true)
        {
            Console.Write("Введите имя: ");
            string? name = Console.ReadLine();

            var validator = new StringValidator(name!);

            ValidationResult result = validator
                .IsNotNullOrWhiteSpace()
                .IsRussianLetters()
                .MinLength(2)
                .MaxLength(16)
                .Validate();

            if (result.IsValid)
            {
                return char.ToUpper(validator.VerifiableString[0]) + validator.VerifiableString[1..].ToLower();
            }

            result.PrintErrors();
            Console.WriteLine("Повторите попытку!");
        }
    }
}
