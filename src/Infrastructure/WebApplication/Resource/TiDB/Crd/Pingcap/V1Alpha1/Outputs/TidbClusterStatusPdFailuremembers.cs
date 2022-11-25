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
    public sealed class TidbClusterStatusPdFailuremembers
    {
        public readonly string CreatedAt;
        public readonly bool MemberDeleted;
        public readonly string MemberID;
        public readonly string PodName;
        public readonly string PvcUID;
        public readonly ImmutableDictionary<string, ImmutableDictionary<string, object>> PvcUIDSet;

        [OutputConstructor]
        private TidbClusterStatusPdFailuremembers(
            string createdAt,

            bool memberDeleted,

            string memberID,

            string podName,

            string pvcUID,

            ImmutableDictionary<string, ImmutableDictionary<string, object>> pvcUIDSet)
        {
            CreatedAt = createdAt;
            MemberDeleted = memberDeleted;
            MemberID = memberID;
            PodName = podName;
            PvcUID = pvcUID;
            PvcUIDSet = pvcUIDSet;
        }
    }
}
