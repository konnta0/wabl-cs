namespace WebApplication.Application.Core.Authentication;

public enum SignUpResultType
{
    Success,
    Failed,
    UserNameAlreadyExists,
    PasswordTooShort,
}