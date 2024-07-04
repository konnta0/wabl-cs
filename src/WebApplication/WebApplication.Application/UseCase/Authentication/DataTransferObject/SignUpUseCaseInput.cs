namespace WebApplication.Application.UseCase.Authentication.DataTransferObject;

public sealed class SignUpUseCaseInput : ISignUpUseCaseInput
{
    public required string UserName { get; set; } = null!;
    public required string Password { get; set; } = null!;
}