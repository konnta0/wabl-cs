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
    public sealed class TidbNGMonitoringSpecNgMonitoringAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTerms
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTermsMatchExpressions> MatchExpressions;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTermsMatchFields> MatchFields;

        [OutputConstructor]
        private TidbNGMonitoringSpecNgMonitoringAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTerms(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTermsMatchExpressions> matchExpressions,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTermsMatchFields> matchFields)
        {
            MatchExpressions = matchExpressions;
            MatchFields = matchFields;
        }
    }
}
