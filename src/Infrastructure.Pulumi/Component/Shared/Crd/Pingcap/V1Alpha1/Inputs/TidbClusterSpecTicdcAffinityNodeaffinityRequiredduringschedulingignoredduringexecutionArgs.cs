// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTicdcAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs : global::Pulumi.ResourceArgs
    {
        [Input("nodeSelectorTerms", required: true)]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTermsArgs>? _nodeSelectorTerms;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTermsArgs> NodeSelectorTerms
        {
            get => _nodeSelectorTerms ?? (_nodeSelectorTerms = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTermsArgs>());
            set => _nodeSelectorTerms = value;
        }

        public TidbClusterSpecTicdcAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs()
        {
        }
        public static new TidbClusterSpecTicdcAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs Empty => new TidbClusterSpecTicdcAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs();
    }
}
