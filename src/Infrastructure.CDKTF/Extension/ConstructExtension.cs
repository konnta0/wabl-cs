namespace Infrastructure.CDKTF.Extension;

internal static class ConstructExtension
{
    public static string ToKebabCase(this Constructs.Construct resource)
    {
        return resource.GetType().Name.PascalToKebabCase();
    }
    
    public static string ToKebabCase<T>() where T : Constructs.Construct
    {
        return typeof(T).Name.PascalToKebabCase();
    }
}