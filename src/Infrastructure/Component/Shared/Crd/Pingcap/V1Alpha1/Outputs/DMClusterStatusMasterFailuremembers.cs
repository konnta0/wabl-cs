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
    public sealed class DMClusterStatusMasterFailuremembers
    {
        public readonly string CreatedAt;
        public readonly bool MemberDeleted;
        public readonly string MemberID;
        public readonly string PodName;
        public readonly string PvcUID;

        [OutputConstructor]
        private DMClusterStatusMasterFailuremembers(
            string createdAt,

            bool memberDeleted,

            string memberID,

            string podName,

            string pvcUID)
        {
            CreatedAt = createdAt;
            MemberDeleted = memberDeleted;
            MemberID = memberID;
            PodName = podName;
            PvcUID = pvcUID;
        }
    }
}