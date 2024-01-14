// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterStatusMasterStatefulSetArgs : global::Pulumi.ResourceArgs
    {
        [Input("collisionCount")]
        public Input<int>? CollisionCount { get; set; }

        [Input("conditions")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterStatusMasterStatefulSetConditionsArgs>? _conditions;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterStatusMasterStatefulSetConditionsArgs> Conditions
        {
            get => _conditions ?? (_conditions = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterStatusMasterStatefulSetConditionsArgs>());
            set => _conditions = value;
        }

        [Input("currentReplicas")]
        public Input<int>? CurrentReplicas { get; set; }

        [Input("currentRevision")]
        public Input<string>? CurrentRevision { get; set; }

        [Input("observedGeneration")]
        public Input<int>? ObservedGeneration { get; set; }

        [Input("readyReplicas")]
        public Input<int>? ReadyReplicas { get; set; }

        [Input("replicas", required: true)]
        public Input<int> Replicas { get; set; } = null!;

        [Input("updateRevision")]
        public Input<string>? UpdateRevision { get; set; }

        [Input("updatedReplicas")]
        public Input<int>? UpdatedReplicas { get; set; }

        public DMClusterStatusMasterStatefulSetArgs()
        {
        }
        public static new DMClusterStatusMasterStatefulSetArgs Empty => new DMClusterStatusMasterStatefulSetArgs();
    }
}
