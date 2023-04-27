namespace Infrastructure.Cache;

public class CacheConfig
{
    public string Host { get; init; } = Environment.GetEnvironmentVariable("CACHE_SERVER_HOST")!;
    public string Port { get; init; } = Environment.GetEnvironmentVariable("CACHE_SERVER_PORT")!;
    public string User { get; init; } = Environment.GetEnvironmentVariable("CACHE_SERVER_USER")!;
    public string Password { get; init; } = Environment.GetEnvironmentVariable("CACHE_SERVER_PASSWORD")!;
}