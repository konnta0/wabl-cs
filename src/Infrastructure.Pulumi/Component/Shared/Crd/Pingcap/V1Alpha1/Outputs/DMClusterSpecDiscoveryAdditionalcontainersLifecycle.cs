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
    public sealed class DMClusterSpecDiscoveryAdditionalContainersLifecycle
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalContainersLifecyclePostStart PostStart;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalContainersLifecyclePreStop PreStop;

        [OutputConstructor]
        private DMClusterSpecDiscoveryAdditionalContainersLifecycle(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalContainersLifecyclePostStart postStart,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalContainersLifecyclePreStop preStop)
        {
            PostStart = postStart;
            PreStop = preStop;
        }
    }
}
