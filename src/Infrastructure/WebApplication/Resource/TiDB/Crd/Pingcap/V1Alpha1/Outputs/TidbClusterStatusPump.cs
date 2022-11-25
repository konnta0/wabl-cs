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
    public sealed class TidbClusterStatusPump
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusPumpConditions> Conditions;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusPumpMembers> Members;
        public readonly string Phase;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusPumpStatefulset StatefulSet;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusPumpVolumes> Volumes;

        [OutputConstructor]
        private TidbClusterStatusPump(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusPumpConditions> conditions,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusPumpMembers> members,

            string phase,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusPumpStatefulset statefulSet,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusPumpVolumes> volumes)
        {
            Conditions = conditions;
            Members = members;
            Phase = phase;
            StatefulSet = statefulSet;
            Volumes = volumes;
        }
    }
}
