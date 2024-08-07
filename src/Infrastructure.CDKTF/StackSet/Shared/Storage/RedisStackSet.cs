using System.Collections.Generic;
using System.Text.Json;
using HashiCorp.Cdktf;
using Infrastructure.CDKTF.Construct.Storage;

namespace Infrastructure.CDKTF.StackSet.Shared.Storage;

internal sealed class RedisStackSet : TerraformResource
{
    public RedisStackSet(Constructs.Construct scope) : 
        base(scope, ConstructExtension.ToKebabCase<RedisStackSet>(), new TerraformResourceConfig
        {
            TerraformResourceType = "stack-set",
        })
    {
        var values = new Dictionary<string, object>
        {
            ["replicas"] = 1,
            ["hardAntiAffinity"] = false,
            ["haproxy"] = new Dictionary<string, object>
            {
                ["hardAntiAffinity"] = false
            }
        };

        _ = new Redis(scope, "shared-redis", "shared", [JsonSerializer.Serialize(values)]);
    }
}