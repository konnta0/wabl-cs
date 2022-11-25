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
    public sealed class DMClusterStatusMasterConditions
    {
        public readonly string LastTransitionTime;
        public readonly string Message;
        public readonly int ObservedGeneration;
        public readonly string Reason;
        public readonly string Status;
        public readonly string Type;

        [OutputConstructor]
        private DMClusterStatusMasterConditions(
            string lastTransitionTime,

            string message,

            int observedGeneration,

            string reason,

            string status,

            string type)
        {
            LastTransitionTime = lastTransitionTime;
            Message = message;
            ObservedGeneration = observedGeneration;
            Reason = reason;
            Status = status;
            Type = type;
        }
    }
}
