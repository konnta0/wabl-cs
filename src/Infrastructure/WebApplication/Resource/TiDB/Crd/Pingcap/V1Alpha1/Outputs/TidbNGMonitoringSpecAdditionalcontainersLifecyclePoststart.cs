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
    public sealed class TidbNGMonitoringSpecAdditionalcontainersLifecyclePoststart
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalcontainersLifecyclePoststartExec Exec;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalcontainersLifecyclePoststartHttpget HttpGet;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalcontainersLifecyclePoststartTcpsocket TcpSocket;

        [OutputConstructor]
        private TidbNGMonitoringSpecAdditionalcontainersLifecyclePoststart(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalcontainersLifecyclePoststartExec exec,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalcontainersLifecyclePoststartHttpget httpGet,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalcontainersLifecyclePoststartTcpsocket tcpSocket)
        {
            Exec = exec;
            HttpGet = httpGet;
            TcpSocket = tcpSocket;
        }
    }
}
