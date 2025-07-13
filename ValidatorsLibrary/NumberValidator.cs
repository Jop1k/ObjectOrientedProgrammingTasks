namespace ValidatorLibrary;

public class NumberValidator
{
    public ValidationResult ValidationResult { get; } = new();

    public int VerifiableNumber { get; }

    public NumberValidator(int verifiableNumber)
    {
        VerifiableNumber = verifiableNumber;
    }

    public NumberValidator MinValue(int minValue)
    {
        if (VerifiableNumber < minValue)
        {
            ValidationResult.ErrorValidate($"Ошибка: число не должно быть меньше {minValue}!");
        }

        return this;
    }

    public NumberValidator MaxValue(int maxValue)
    {
        if (VerifiableNumber > maxValue)
        {
            ValidationResult.ErrorValidate($"Ошибка: число не должно быть больше {maxValue}!");
        }

        return this;
    }
}