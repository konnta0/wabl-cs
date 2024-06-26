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
    public sealed class DMClusterStatusWorkerMembers
    {
        public readonly string Addr;
        public readonly string LastTransitionTime;
        public readonly string Name;
        public readonly string Stage;

        [OutputConstructor]
        private DMClusterStatusWorkerMembers(
            string addr,

            string lastTransitionTime,

            string name,

            string stage)
        {
            Addr = addr;
            LastTransitionTime = lastTransitionTime;
            Name = name;
            Stage = stage;
        }
    }
}
