// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTidbAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs : global::Pulumi.ResourceArgs
    {
        [Input("nodeSelectorTerms", required: true)]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTermsArgs>? _nodeSelectorTerms;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTermsArgs> NodeSelectorTerms
        {
            get => _nodeSelectorTerms ?? (_nodeSelectorTerms = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTermsArgs>());
            set => _nodeSelectorTerms = value;
        }

        public TidbClusterSpecTidbAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs()
        {
        }
        public static new TidbClusterSpecTidbAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs Empty => new TidbClusterSpecTidbAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs();
    }
}
