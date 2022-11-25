// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1
{

    [OutputType]
    public sealed class DMClusterStatusMasterStatefulset
    {
        public readonly int CollisionCount;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterStatusMasterStatefulsetConditions> Conditions;
        public readonly int CurrentReplicas;
        public readonly string CurrentRevision;
        public readonly int ObservedGeneration;
        public readonly int ReadyReplicas;
        public readonly int Replicas;
        public readonly string UpdateRevision;
        public readonly int UpdatedReplicas;

        [OutputConstructor]
        private DMClusterStatusMasterStatefulset(
            int collisionCount,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterStatusMasterStatefulsetConditions> conditions,

            int currentReplicas,

            string currentRevision,

            int observedGeneration,

            int readyReplicas,

            int replicas,

            string updateRevision,

            int updatedReplicas)
        {
            CollisionCount = collisionCount;
            Conditions = conditions;
            CurrentReplicas = currentReplicas;
            CurrentRevision = currentRevision;
            ObservedGeneration = observedGeneration;
            ReadyReplicas = readyReplicas;
            Replicas = replicas;
            UpdateRevision = updateRevision;
            UpdatedReplicas = updatedReplicas;
        }
    }
}
