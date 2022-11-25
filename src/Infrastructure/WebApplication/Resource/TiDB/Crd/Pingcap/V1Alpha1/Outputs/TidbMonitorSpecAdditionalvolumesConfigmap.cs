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
    public sealed class TidbMonitorSpecAdditionalvolumesConfigmap
    {
        public readonly int DefaultMode;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecAdditionalvolumesConfigmapItems> Items;
        public readonly string Name;
        public readonly bool Optional;

        [OutputConstructor]
        private TidbMonitorSpecAdditionalvolumesConfigmap(
            int defaultMode,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecAdditionalvolumesConfigmapItems> items,

            string name,

            bool optional)
        {
            DefaultMode = defaultMode;
            Items = items;
            Name = name;
            Optional = optional;
        }
    }
}
