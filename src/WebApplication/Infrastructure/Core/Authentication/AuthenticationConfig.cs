namespace Infrastructure.Core.Authentication;

public sealed class AuthenticationConfig
{
    public string AuthorityBaseUrl { get; init; } = Environment.GetEnvironmentVariable("AUTHENTICATION_BASE_URL")!;
    public string Realm { get; init; } = Environment.GetEnvironmentVariable("AUTHENTICATION_REALM")!;
    public string Issuer { get; init; } = Environment.GetEnvironmentVariable("AUTHENTICATION_ISSUER")!;
    public string Audience { get; init; } = Environment.GetEnvironmentVariable("AUTHENTICATION_AUDIENCE")!;
    public string Secret { get; init; } = Environment.GetEnvironmentVariable("AUTHENTICATION_SECRET")!;
    public string AdminUserName { get; init; } = Environment.GetEnvironmentVariable("AUTHENTICATION_ADMIN_USERNAME")!;
    public string AdminPassword { get; init; } = Environment.GetEnvironmentVariable("AUTHENTICATION_ADMIN_PASSWORD")!;
    public string AdminBaseUrl { get; init; } = Environment.GetEnvironmentVariable("AUTHENTICATION_ADMIN_BASE_URL")!;
}