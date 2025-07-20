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
            ValidationResult.AddError(ValidationError.IncorrectLength, $"minimum line length must be {minLength} characters!");
        }

        return this;
    }

    public StringValidator MaxLength(int maxLength)
    {
        if (VerifiableString.Length > maxLength)
        {
            ValidationResult.AddError(ValidationError.IncorrectLength, $"the maximum line length must be {maxLength} characters!");
        }

        return this;
    }

    public StringValidator IsNotNullOrWhiteSpace()
    {
        if (string.IsNullOrWhiteSpace(VerifiableString))
        {
            ValidationResult.AddError(ValidationError.IncorrectString, "you haven't entered anything!");
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
            ValidationResult.AddError(ValidationError.IncorrectNationalLetters, "the line must contain only Russian letters (no spaces)!");
        }

        return this;
    }

    public StringValidator IsNumber()
    {
        foreach (char symbol in VerifiableString)
        {
            if (!char.IsDigit(symbol))
            {
                ValidationResult.AddError(ValidationError.IncorrectValue, "this is not a number!");
                break;
            }
        }

        return this;
    }
}
