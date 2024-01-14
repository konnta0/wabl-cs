// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterStatusTidbArgs : global::Pulumi.ResourceArgs
    {
        [Input("conditions")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTidbConditionsArgs>? _conditions;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTidbConditionsArgs> Conditions
        {
            get => _conditions ?? (_conditions = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTidbConditionsArgs>());
            set => _conditions = value;
        }

        [Input("failureMembers")]
        private InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTidbFailureMembersArgs>? _failureMembers;
        public InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTidbFailureMembersArgs> FailureMembers
        {
            get => _failureMembers ?? (_failureMembers = new InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTidbFailureMembersArgs>());
            set => _failureMembers = value;
        }

        [Input("image")]
        public Input<string>? Image { get; set; }

        [Input("members")]
        private InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTidbMembersArgs>? _members;
        public InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTidbMembersArgs> Members
        {
            get => _members ?? (_members = new InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTidbMembersArgs>());
            set => _members = value;
        }

        [Input("passwordInitialized")]
        public Input<bool>? PasswordInitialized { get; set; }

        [Input("phase")]
        public Input<string>? Phase { get; set; }

        [Input("resignDDLOwnerRetryCount")]
        public Input<int>? ResignDDLOwnerRetryCount { get; set; }

        [Input("statefulSet")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTidbStatefulSetArgs>? StatefulSet { get; set; }

        [Input("volumes")]
        private InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTidbVolumesArgs>? _volumes;
        public InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTidbVolumesArgs> Volumes
        {
            get => _volumes ?? (_volumes = new InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTidbVolumesArgs>());
            set => _volumes = value;
        }

        public TidbClusterStatusTidbArgs()
        {
        }
        public static new TidbClusterStatusTidbArgs Empty => new TidbClusterStatusTidbArgs();
    }
}
