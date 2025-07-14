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
            ValidationResult.AddError(ValidationError.IncorrectValue, $"число не должно быть меньше {minValue}!");
        }

        return this;
    }

    public NumberValidator MaxValue(int maxValue)
    {
        if (VerifiableNumber > maxValue)
        {
            ValidationResult.AddError(ValidationError.IncorrectValue, $"число не должно быть больше {maxValue}!");
        }

        return this;
    }
}