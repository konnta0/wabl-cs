namespace Application.Core.Authentication;

public interface IAuthenticationProvider
{
    ValueTask<SignUpResult> SignUpAsync(string userName, string password, CancellationToken cancellationToken = new ());
    ValueTask<AuthenticationResult> SignInAsync(string userName, string password, CancellationToken cancellationToken = new ());
}