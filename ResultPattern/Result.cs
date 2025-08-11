namespace ResultPattern;

public class Result
{
    public bool IsSuccess { get; }

    public Error? Error { get; }

    public string? ErrorMessage { get; }

    private Result(bool isSuccess, Error? error, string? errorMessage)
    {
        IsSuccess = isSuccess;
        Error = error;
        ErrorMessage = errorMessage;
    }

    public static Result Success() => new(true, null, null);

    public static Result Failure(Error error, string errorMessage) => new(false, error, errorMessage);
}
