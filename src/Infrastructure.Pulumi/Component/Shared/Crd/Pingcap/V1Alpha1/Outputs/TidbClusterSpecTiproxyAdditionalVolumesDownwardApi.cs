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
    public sealed class TidbClusterSpecTiproxyAdditionalVolumesDownwardApi
    {
        public readonly int DefaultMode;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesDownwardApiItems> Items;

        [OutputConstructor]
        private TidbClusterSpecTiproxyAdditionalVolumesDownwardApi(
            int defaultMode,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesDownwardApiItems> items)
        {
            DefaultMode = defaultMode;
            Items = items;
        }
    }
}