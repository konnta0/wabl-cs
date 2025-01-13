using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Kubernetes.Namespace;
using Infrastructure.CDKTF.StackSet.Shared.Storage;

namespace Infrastructure.CDKTF.StackSet.Shared;

internal sealed class SharedStackSet : TerraformResource
{
    public SharedStackSet(Constructs.Construct construct) :
        base(construct, ConstructExtension.ToKebabCase<SharedStackSet>(), new TerraformResourceConfig
    {
        TerraformResourceType = "stack-set",
    })
    {
        const string namespaceId = "namespace-shared";
        var ns = new Namespace(construct, namespaceId, new NamespaceConfig { Metadata = new NamespaceMetadata { Name = "shared"}});
        var minio = new MinIoStackSet(construct)
        {
            DependsOn = [namespaceId]
        };
        var tidb = new TiDbStackSet(construct)
        {
            DependsOn = [namespaceId]
        };
        var redis = new RedisStackSet(construct)
        {
            DependsOn = [namespaceId]
        };
        
    }
}