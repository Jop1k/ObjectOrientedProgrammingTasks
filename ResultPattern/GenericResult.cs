namespace ResultPattern;

public class Result<T>
{
    public bool IsSuccess { get; }

    public T? Value { get; }

    public Error? Error { get; }

    public string? ErrorMessage { get; }

    private Result(bool isSuccess, T? value, Error? error, string? errorMessage)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
        ErrorMessage = errorMessage;
    }

    public static Result<T> Success(T value) => new(true, value, null, null);

    public static Result<T> Failure(Error error, string errorMessage) => new(false, default, error, errorMessage);
}
