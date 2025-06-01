namespace ValidatorsLibrary;

public class StringValidator
{
    private readonly ValidationResult _validationResult = new();

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
            _validationResult.ErrorValidate($"Ошибка: минимальная длинна строки должна составлять {minLength} символов!");
        }

        return this;
    }

    public StringValidator MaxLength(int maxLength)
    {
        if (VerifiableString.Length > maxLength)
        {
            _validationResult.ErrorValidate($"Ошибка: максимальная длинна строки должна составлять {maxLength} символов!");
        }

        return this;
    }

    public StringValidator IsNotNullOrWhiteSpace()
    {
        if (string.IsNullOrWhiteSpace(VerifiableString))
        {
            _validationResult.ErrorValidate("Ошибка: вы ничего не ввели!");
        }

        return this;
    }

    public StringValidator IsRussianLetters()
    {
        if (!VerifiableString.All(letter => ('А' <= letter && letter <= 'я') || letter == 'ё' || letter == 'Ё'))
        {
            _validationResult.ErrorValidate("Ошибка: строка должна содержать только русские буквы (без пробелов)!");
        }

        return this;
    }

    public StringValidator IsNumber()
    {
        foreach (char symbol in VerifiableString)
        {
            if (!char.IsDigit(symbol))
            {
                _validationResult.ErrorValidate("Ошибка: это не число!");
                break;
            }
        }

        return this;
    }

    public ValidationResult Validate()
    {
        return _validationResult;
    }
}
