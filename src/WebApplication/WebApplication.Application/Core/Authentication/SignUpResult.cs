namespace WebApplication.Application.Core.Authentication;

public sealed class SignUpResult
{
    public required SignUpResultType ResultType { get; init; }
    
    public required string AccessToken { get; init; } = string.Empty;
}