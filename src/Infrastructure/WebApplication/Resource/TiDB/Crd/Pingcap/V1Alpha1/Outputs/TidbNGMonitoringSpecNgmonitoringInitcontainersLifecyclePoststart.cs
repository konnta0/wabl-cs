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
    public sealed class TidbNGMonitoringSpecNgmonitoringInitcontainersLifecyclePoststart
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgmonitoringInitcontainersLifecyclePoststartExec Exec;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgmonitoringInitcontainersLifecyclePoststartHttpget HttpGet;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgmonitoringInitcontainersLifecyclePoststartTcpsocket TcpSocket;

        [OutputConstructor]
        private TidbNGMonitoringSpecNgmonitoringInitcontainersLifecyclePoststart(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgmonitoringInitcontainersLifecyclePoststartExec exec,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgmonitoringInitcontainersLifecyclePoststartHttpget httpGet,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgmonitoringInitcontainersLifecyclePoststartTcpsocket tcpSocket)
        {
            Exec = exec;
            HttpGet = httpGet;
            TcpSocket = tcpSocket;
        }
    }
}
