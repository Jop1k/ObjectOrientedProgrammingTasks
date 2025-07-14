namespace ValidatorLibrary;

public static class ConsoleLogger
{
    public static void LogValidationErrors(ValidationResult result)
    {
        result.Errors.ForEach(error => Console.WriteLine($"Validation error: {error.error} | Error message: {error.errorMessage}"));
    }
}
