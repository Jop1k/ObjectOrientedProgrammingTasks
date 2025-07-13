namespace ValidatorLibrary;

public class ValidationResult
{
    private List<string> Errors { get; } = [];

    public bool IsValid { get; private set; } = true;

    internal void ErrorValidate(string errorMessage)
    {
        Errors.Add(errorMessage);

        IsValid = false;
    }

    public void PrintErrors() // завязывается на консоли + за это может отвечать логгер!
    {
        Errors.ForEach(error => Console.WriteLine(error));
    }
}
