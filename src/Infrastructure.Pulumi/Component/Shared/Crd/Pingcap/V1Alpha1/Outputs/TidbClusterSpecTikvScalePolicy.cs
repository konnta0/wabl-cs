// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1
{

    [OutputType]
    public sealed class TidbClusterSpecTikvScalePolicy
    {
        public readonly int ScaleInParallelism;
        public readonly int ScaleOutParallelism;

        [OutputConstructor]
        private TidbClusterSpecTikvScalePolicy(
            int scaleInParallelism,

            int scaleOutParallelism)
        {
            ScaleInParallelism = scaleInParallelism;
            ScaleOutParallelism = scaleOutParallelism;
        }
    }
}
