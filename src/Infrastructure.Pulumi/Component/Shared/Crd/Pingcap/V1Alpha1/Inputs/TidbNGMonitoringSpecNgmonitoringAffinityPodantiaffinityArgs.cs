// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbNGMonitoringSpecNgMonitoringAffinityPodAntiAffinityArgs : global::Pulumi.ResourceArgs
    {
        [Input("preferredDuringSchedulingIgnoredDuringExecution")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAffinityPodAntiAffinityPreferredDuringSchedulingIgnoredDuringExecutionArgs>? _preferredDuringSchedulingIgnoredDuringExecution;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAffinityPodAntiAffinityPreferredDuringSchedulingIgnoredDuringExecutionArgs> PreferredDuringSchedulingIgnoredDuringExecution
        {
            get => _preferredDuringSchedulingIgnoredDuringExecution ?? (_preferredDuringSchedulingIgnoredDuringExecution = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAffinityPodAntiAffinityPreferredDuringSchedulingIgnoredDuringExecutionArgs>());
            set => _preferredDuringSchedulingIgnoredDuringExecution = value;
        }

        [Input("requiredDuringSchedulingIgnoredDuringExecution")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAffinityPodAntiAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs>? _requiredDuringSchedulingIgnoredDuringExecution;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAffinityPodAntiAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs> RequiredDuringSchedulingIgnoredDuringExecution
        {
            get => _requiredDuringSchedulingIgnoredDuringExecution ?? (_requiredDuringSchedulingIgnoredDuringExecution = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAffinityPodAntiAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs>());
            set => _requiredDuringSchedulingIgnoredDuringExecution = value;
        }

        public TidbNGMonitoringSpecNgMonitoringAffinityPodAntiAffinityArgs()
        {
        }
        public static new TidbNGMonitoringSpecNgMonitoringAffinityPodAntiAffinityArgs Empty => new TidbNGMonitoringSpecNgMonitoringAffinityPodAntiAffinityArgs();
    }
}
