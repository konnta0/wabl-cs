namespace Infrastructure.CDKTF;

internal static class JsonSerializerOption
{
    public static System.Text.Json.JsonSerializerOptions Default => new()
    {
        PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
    };
}