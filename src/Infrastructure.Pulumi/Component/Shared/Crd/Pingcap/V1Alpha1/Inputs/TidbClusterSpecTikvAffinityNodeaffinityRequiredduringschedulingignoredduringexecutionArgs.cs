// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTikvAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs : global::Pulumi.ResourceArgs
    {
        [Input("nodeSelectorTerms", required: true)]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTikvAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTermsArgs>? _nodeSelectorTerms;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTikvAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTermsArgs> NodeSelectorTerms
        {
            get => _nodeSelectorTerms ?? (_nodeSelectorTerms = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTikvAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionNodeSelectorTermsArgs>());
            set => _nodeSelectorTerms = value;
        }

        public TidbClusterSpecTikvAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs()
        {
        }
        public static new TidbClusterSpecTikvAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs Empty => new TidbClusterSpecTikvAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs();
    }
}
