// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecDiscoveryAffinityPodantiaffinityArgs : Pulumi.ResourceArgs
    {
        [Input("preferredDuringSchedulingIgnoredDuringExecution")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAffinityPodantiaffinityPreferredduringschedulingignoredduringexecutionArgs>? _preferredDuringSchedulingIgnoredDuringExecution;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAffinityPodantiaffinityPreferredduringschedulingignoredduringexecutionArgs> PreferredDuringSchedulingIgnoredDuringExecution
        {
            get => _preferredDuringSchedulingIgnoredDuringExecution ?? (_preferredDuringSchedulingIgnoredDuringExecution = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAffinityPodantiaffinityPreferredduringschedulingignoredduringexecutionArgs>());
            set => _preferredDuringSchedulingIgnoredDuringExecution = value;
        }

        [Input("requiredDuringSchedulingIgnoredDuringExecution")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAffinityPodantiaffinityRequiredduringschedulingignoredduringexecutionArgs>? _requiredDuringSchedulingIgnoredDuringExecution;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAffinityPodantiaffinityRequiredduringschedulingignoredduringexecutionArgs> RequiredDuringSchedulingIgnoredDuringExecution
        {
            get => _requiredDuringSchedulingIgnoredDuringExecution ?? (_requiredDuringSchedulingIgnoredDuringExecution = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAffinityPodantiaffinityRequiredduringschedulingignoredduringexecutionArgs>());
            set => _requiredDuringSchedulingIgnoredDuringExecution = value;
        }

        public TidbClusterSpecDiscoveryAffinityPodantiaffinityArgs()
        {
        }
    }
}
