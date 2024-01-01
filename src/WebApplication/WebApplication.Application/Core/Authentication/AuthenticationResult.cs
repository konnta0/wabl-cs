namespace WebApplication.Application.Core.Authentication;

public class AuthenticationResult
{
    public required AuthenticationResultType ResultType { get; init; }
    public required string AccessToken { get; init; } = string.Empty;
}