// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class RestoreSpecAffinityNodeaffinityArgs : Pulumi.ResourceArgs
    {
        [Input("preferredDuringSchedulingIgnoredDuringExecution")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionArgs>? _preferredDuringSchedulingIgnoredDuringExecution;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionArgs> PreferredDuringSchedulingIgnoredDuringExecution
        {
            get => _preferredDuringSchedulingIgnoredDuringExecution ?? (_preferredDuringSchedulingIgnoredDuringExecution = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionArgs>());
            set => _preferredDuringSchedulingIgnoredDuringExecution = value;
        }

        [Input("requiredDuringSchedulingIgnoredDuringExecution")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionArgs>? RequiredDuringSchedulingIgnoredDuringExecution { get; set; }

        public RestoreSpecAffinityNodeaffinityArgs()
        {
        }
    }
}
