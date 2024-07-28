using HashiCorp.Cdktf;

namespace Infrastructure.CDKTF.Construct;

public interface IApplicableConstruct<out T1> where T1 : TerraformResource
{
    T1 Apply();
}