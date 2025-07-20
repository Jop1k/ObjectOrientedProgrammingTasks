namespace ValidatorLibrary;

public class NumberValidator
{
    public ValidationResult ValidationResult { get; } = new();

    public int VerifiableNumber { get; }

    public NumberValidator(int verifiableNumber) => VerifiableNumber = verifiableNumber;

    public NumberValidator MinValue(int minValue)
    {
        if (VerifiableNumber < minValue)
        {
            ValidationResult.AddError(ValidationError.IncorrectValue, $"the number should not be less than {minValue}!");
        }

        return this;
    }

    public NumberValidator MaxValue(int maxValue)
    {
        if (VerifiableNumber > maxValue)
        {
            ValidationResult.AddError(ValidationError.IncorrectValue, $"the number should not be more than {maxValue}!");
        }

        return this;
    }
}