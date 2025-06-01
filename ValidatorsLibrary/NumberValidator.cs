namespace ValidatorsLibrary;

public class NumberValidator
{
    private readonly ValidationResult _validationResult = new();

    public int VerifiableNumber { get; }

    public NumberValidator(int verifiableNumber)
    {
        VerifiableNumber = verifiableNumber;
    }

    public NumberValidator MinValue(int minValue)
    {
        if (VerifiableNumber < minValue)
        {
            _validationResult.ErrorValidate($"Ошибка: число не должно быть меньше {minValue}!");
        }

        return this;
    }

    public NumberValidator MaxValue(int maxValue)
    {
        if (VerifiableNumber > maxValue)
        {
            _validationResult.ErrorValidate($"Ошибка: число не должно быть больше {maxValue}!");
        }

        return this;
    }

    public ValidationResult Validate()
    {
        return _validationResult;
    }
}