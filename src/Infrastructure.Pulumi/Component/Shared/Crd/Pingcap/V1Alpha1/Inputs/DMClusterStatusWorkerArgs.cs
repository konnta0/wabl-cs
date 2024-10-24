// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterStatusWorkerArgs : global::Pulumi.ResourceArgs
    {
        [Input("conditions")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterStatusWorkerConditionsArgs>? _conditions;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterStatusWorkerConditionsArgs> Conditions
        {
            get => _conditions ?? (_conditions = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterStatusWorkerConditionsArgs>());
            set => _conditions = value;
        }

        [Input("failoverUID")]
        public Input<string>? FailoverUID { get; set; }

        [Input("failureMembers")]
        private InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterStatusWorkerFailureMembersArgs>? _failureMembers;
        public InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterStatusWorkerFailureMembersArgs> FailureMembers
        {
            get => _failureMembers ?? (_failureMembers = new InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterStatusWorkerFailureMembersArgs>());
            set => _failureMembers = value;
        }

        [Input("image")]
        public Input<string>? Image { get; set; }

        [Input("members")]
        private InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterStatusWorkerMembersArgs>? _members;
        public InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterStatusWorkerMembersArgs> Members
        {
            get => _members ?? (_members = new InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterStatusWorkerMembersArgs>());
            set => _members = value;
        }

        [Input("phase")]
        public Input<string>? Phase { get; set; }

        [Input("statefulSet")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterStatusWorkerStatefulSetArgs>? StatefulSet { get; set; }

        [Input("synced")]
        public Input<bool>? Synced { get; set; }

        [Input("volumes")]
        private InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterStatusWorkerVolumesArgs>? _volumes;
        public InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterStatusWorkerVolumesArgs> Volumes
        {
            get => _volumes ?? (_volumes = new InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterStatusWorkerVolumesArgs>());
            set => _volumes = value;
        }

        public DMClusterStatusWorkerArgs()
        {
        }
        public static new DMClusterStatusWorkerArgs Empty => new DMClusterStatusWorkerArgs();
    }
}
