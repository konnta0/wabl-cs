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
    public sealed class TidbClusterSpecTicdcAffinityPodAntiAffinityPreferredDuringSchedulingIgnoredDuringExecutionPodAffinityTermLabelSelectorMatchExpressions
    {
        public readonly string Key;
        public readonly string Operator;
        public readonly ImmutableArray<string> Values;

        [OutputConstructor]
        private TidbClusterSpecTicdcAffinityPodAntiAffinityPreferredDuringSchedulingIgnoredDuringExecutionPodAffinityTermLabelSelectorMatchExpressions(
            string key,

            string @operator,

            ImmutableArray<string> values)
        {
            Key = key;
            Operator = @operator;
            Values = values;
        }
    }
}
