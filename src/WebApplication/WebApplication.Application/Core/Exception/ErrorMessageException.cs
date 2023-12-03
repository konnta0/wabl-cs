namespace WebApplication.Application.Core.Exception;

public class ErrorMessageException : System.Exception
{
    public ErrorMessageException(string? message) : base(message)
    {
    }
}