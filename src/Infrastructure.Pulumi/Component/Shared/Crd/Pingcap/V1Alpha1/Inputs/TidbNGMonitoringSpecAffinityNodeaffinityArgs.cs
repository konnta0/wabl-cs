// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbNGMonitoringSpecAffinityNodeAffinityArgs : global::Pulumi.ResourceArgs
    {
        [Input("preferredDuringSchedulingIgnoredDuringExecution")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAffinityNodeAffinityPreferredDuringSchedulingIgnoredDuringExecutionArgs>? _preferredDuringSchedulingIgnoredDuringExecution;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAffinityNodeAffinityPreferredDuringSchedulingIgnoredDuringExecutionArgs> PreferredDuringSchedulingIgnoredDuringExecution
        {
            get => _preferredDuringSchedulingIgnoredDuringExecution ?? (_preferredDuringSchedulingIgnoredDuringExecution = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAffinityNodeAffinityPreferredDuringSchedulingIgnoredDuringExecutionArgs>());
            set => _preferredDuringSchedulingIgnoredDuringExecution = value;
        }

        [Input("requiredDuringSchedulingIgnoredDuringExecution")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAffinityNodeAffinityRequiredDuringSchedulingIgnoredDuringExecutionArgs>? RequiredDuringSchedulingIgnoredDuringExecution { get; set; }

        public TidbNGMonitoringSpecAffinityNodeAffinityArgs()
        {
        }
        public static new TidbNGMonitoringSpecAffinityNodeAffinityArgs Empty => new TidbNGMonitoringSpecAffinityNodeAffinityArgs();
    }
}
