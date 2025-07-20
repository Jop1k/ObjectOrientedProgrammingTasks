namespace ValidatorLibrary;

public class ValidationResult
{
    private List<(ValidationError error, string errorMessage)> _errors = [];

    public bool IsValid { get; private set; } = true;

    public IReadOnlyList<(ValidationError error, string errorMessage)> Errors 
    {
        get => _errors.AsReadOnly();
    }

    internal void AddError(ValidationError validationError ,string errorMessage)
    {
        _errors.Add((validationError ,errorMessage));

        IsValid = false;
    }
}
