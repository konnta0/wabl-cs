
namespace Infrastructure.Database;

public class DatabaseConfig
{
    public string ServerHost { get; init; } = Environment.GetEnvironmentVariable("DB_SERVER_HOST")!;
    public string ServerPort { get; init; } = Environment.GetEnvironmentVariable("DB_SERVER_PORT")!;
    public string ServerUser { get; init; } = Environment.GetEnvironmentVariable("DB_SERVER_USER")!;
    public string ServerPassword { get; init; } = Environment.GetEnvironmentVariable("DB_SERVER_PASSWORD")!;
    
}