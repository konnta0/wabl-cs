namespace Infrastructure.Pulumi.Component.WebApplication;

public struct WebApplicationConfig
{
    public string Namespace { get; init; }
    public bool Deploy { get; init; }
    public string Tag { get; init; }
}