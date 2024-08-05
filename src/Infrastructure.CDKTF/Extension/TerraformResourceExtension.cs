using HashiCorp.Cdktf;

namespace Infrastructure.CDKTF.Extension;

internal static class TerraformResourceExtension
{
    public static string GetId(this TerraformResource resource)
    {
        return resource.GetStringAttribute("Id");
    }
}