namespace ValidatorLibrary;

public class StringValidator
{
    public ValidationResult ValidationResult { get; } = new();

    public string VerifiableString { get; }

    public StringValidator(string verifiableString) => VerifiableString = verifiableString;

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
        char[] russianLetter = ['а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж',
            'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т',
            'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'];

        if (!VerifiableString.ToLower().All(letter => russianLetter.Contains(letter)))
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
