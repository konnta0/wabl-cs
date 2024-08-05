using System.Linq;

namespace Infrastructure.CDKTF.Extension;

internal static class StringExtension
{
    public static string PascalToKebabCase(this string value)
    {
        return string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "-" + x : x.ToString())).ToLower();
    }
    
}