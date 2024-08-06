using System.Collections.Generic;
using System.Text.Json;
using HashiCorp.Cdktf;
using Infrastructure.CDKTF.Construct.Storage;

namespace Infrastructure.CDKTF.StackSet.Shared.Storage;

internal sealed class MinIoStackSet : TerraformResource
{
    public MinIoStackSet(Constructs.Construct scope) : base(scope, ConstructExtension.ToKebabCase<MinIoStackSet>(), new TerraformResourceConfig
    {
        TerraformResourceType = "stack-set",
    })
    {
        // ref: https://github.com/minio/minio/blob/master/helm/minio/values.yaml
        var values = new Dictionary<string, object>
        {
            ["replicas"] = 2,
            ["persistence"] = new Dictionary<string, object>
            {
                ["size"] = "1Gi"
            },
            ["ingress"] = new Dictionary<string, object>
            {
                ["enabled"] = true,
                ["hosts"] = new List<object>
                {
                    "api.minio.storage.test"
                }
            },
            ["consoleIngress"] = new Dictionary<string, object>
            {
                ["enabled"] = true,
                ["hosts"] = new List<string>
                {
                    "console.minio.storage.test"
                }
            },
            ["resources"] = new Dictionary<string, object>
            {
                ["requests"] = new Dictionary<string, object>
                {
                    ["memory"] = "200Mi"
                }
            },
            ["rootUser"] = "minioadmin",
            ["rootPassword"] = "minioadmin",
            ["users"] = new List<object>
            {
                new Dictionary<string, object>
                {
                    ["accessKey"] = "o11yuser",
                    ["secretKey"] = "o11ypassword",
                    ["policy"] = "readwrite"
                },
                new Dictionary<string, object>
                {
                    ["accessKey"] = "mimir",
                    ["secretKey"] = "mimirsecret",
                    ["policy"] = "readwrite"
                }
            },
            ["buckets"] = new List<object>
            {
                new Dictionary<string, object>
                {
                    ["name"] = "tempo",
                    ["policy"] = "public",
                    ["purge"] = false,
                    ["versioning"] = false
                },
                new Dictionary<string, object>
                {
                    ["name"] = "mimir-ruler",
                    ["policy"] = "public",
                    ["purge"] = false,
                    ["versioning"] = false
                },
                new Dictionary<string, object>
                {
                    ["name"] = "mimir-tsdb",
                    ["policy"] = "public",
                    ["purge"] = false,
                    ["versioning"] = false
                },
                new Dictionary<string, object>
                {
                    ["name"] = "pyroscope",
                    ["policy"] = "public",
                    ["purge"] = false,
                    ["versioning"] = false
                }
            }
        };

        _ = new MinIo(scope, "shared-minio", "shared", [JsonSerializer.Serialize(values)]);
    }
}