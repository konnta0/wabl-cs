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
    public sealed class DMClusterSpecDiscoveryAdditionalContainersLifecyclePreStop
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalContainersLifecyclePreStopExec Exec;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalContainersLifecyclePreStopHttpGet HttpGet;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalContainersLifecyclePreStopTcpSocket TcpSocket;

        [OutputConstructor]
        private DMClusterSpecDiscoveryAdditionalContainersLifecyclePreStop(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalContainersLifecyclePreStopExec exec,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalContainersLifecyclePreStopHttpGet httpGet,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalContainersLifecyclePreStopTcpSocket tcpSocket)
        {
            Exec = exec;
            HttpGet = httpGet;
            TcpSocket = tcpSocket;
        }
    }
}
