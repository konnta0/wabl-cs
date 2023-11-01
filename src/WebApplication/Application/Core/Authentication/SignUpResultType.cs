namespace Application.Core.Authentication;

public enum SignUpResultType
{
    Success,
    Failed,
    UserNameAlreadyExists,
    PasswordTooShort,
}