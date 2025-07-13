namespace ValidatorLibrary;

public class StringValidator
{
    public ValidationResult ValidationResult { get; } = new();

    public string VerifiableString { get; }

    public StringValidator(string verifiableString)
    {
        if (verifiableString != null)
        {
            VerifiableString = verifiableString.Trim();
        }
        else
        {
            VerifiableString = string.Empty;
        }
    }

    public StringValidator MinLength(int minLength)
    {
        if (VerifiableString.Length < minLength)
        {
            ValidationResult.ErrorValidate($"Ошибка: минимальная длинна строки должна составлять {minLength} символов!");
        }

        return this;
    }

    public StringValidator MaxLength(int maxLength)
    {
        if (VerifiableString.Length > maxLength)
        {
            ValidationResult.ErrorValidate($"Ошибка: максимальная длинна строки должна составлять {maxLength} символов!");
        }

        return this;
    }

    public StringValidator IsNotNullOrWhiteSpace()
    {
        if (string.IsNullOrWhiteSpace(VerifiableString))
        {
            ValidationResult.ErrorValidate("Ошибка: вы ничего не ввели!");
        }

        return this;
    }

    public StringValidator IsRussianLetters()
    {
        if (!VerifiableString.All(letter => ('А' <= letter && letter <= 'я') || letter == 'ё' || letter == 'Ё'))
        {
            ValidationResult.ErrorValidate("Ошибка: строка должна содержать только русские буквы (без пробелов)!");
        }

        return this;
    }

    public StringValidator IsNumber()
    {
        foreach (char symbol in VerifiableString)
        {
            if (!char.IsDigit(symbol))
            {
                ValidationResult.ErrorValidate("Ошибка: это не число!");
                break;
            }
        }

        return this;
    }
}
