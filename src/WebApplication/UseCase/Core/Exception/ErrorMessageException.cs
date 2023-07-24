namespace UseCase.Core.Exception;

public class ErrorMessageException : System.Exception
{
    public ErrorMessageException(string? message) : base(message)
    {
    }
}