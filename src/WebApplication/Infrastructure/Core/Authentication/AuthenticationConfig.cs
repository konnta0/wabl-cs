namespace Infrastructure.Core.Authentication;

public sealed class AuthenticationConfig
{
    public string Issuer { get; init; } = Environment.GetEnvironmentVariable("AUTHENTICATION_ISSUER")!;
    public string Audience { get; init; } = Environment.GetEnvironmentVariable("AUTHENTICATION_AUDIENCE")!;
    public string Secret { get; init; } = Environment.GetEnvironmentVariable("AUTHENTICATION_SECRET")!;
}