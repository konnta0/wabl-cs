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
    public sealed class TidbClusterAutoScalerSpecTidbRules
    {
        public readonly double Max_threshold;
        public readonly double Min_threshold;
        public readonly ImmutableArray<string> Resource_types;

        [OutputConstructor]
        private TidbClusterAutoScalerSpecTidbRules(
            double max_threshold,

            double min_threshold,

            ImmutableArray<string> resource_types)
        {
            Max_threshold = max_threshold;
            Min_threshold = min_threshold;
            Resource_types = resource_types;
        }
    }
}
