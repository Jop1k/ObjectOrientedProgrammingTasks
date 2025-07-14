namespace ValidatorLibrary;

public class ValidationResult
{
    internal List<(ValidationError error, string errorMessage)> Errors { get; } = [];

    public bool IsValid { get; private set; } = true;

    internal void AddError(ValidationError validationError ,string errorMessage)
    {
        Errors.Add((validationError ,errorMessage));

        IsValid = false;
    }
}
