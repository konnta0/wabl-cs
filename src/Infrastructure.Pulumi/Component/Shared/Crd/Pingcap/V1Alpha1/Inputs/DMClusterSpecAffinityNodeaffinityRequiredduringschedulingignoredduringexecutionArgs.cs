// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs : global::Pulumi.ResourceArgs
    {
        [Input("nodeSelectorTerms", required: true)]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTermsArgs>? _nodeSelectorTerms;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTermsArgs> NodeSelectorTerms
        {
            get => _nodeSelectorTerms ?? (_nodeSelectorTerms = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTermsArgs>());
            set => _nodeSelectorTerms = value;
        }

        public DMClusterSpecAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs()
        {
        }
        public static new DMClusterSpecAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs Empty => new DMClusterSpecAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs();
    }
}
