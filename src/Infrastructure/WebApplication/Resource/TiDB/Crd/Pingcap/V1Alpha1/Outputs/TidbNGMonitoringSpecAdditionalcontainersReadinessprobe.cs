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
    public sealed class TidbNGMonitoringSpecAdditionalcontainersReadinessprobe
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalcontainersReadinessprobeExec Exec;
        public readonly int FailureThreshold;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalcontainersReadinessprobeHttpget HttpGet;
        public readonly int InitialDelaySeconds;
        public readonly int PeriodSeconds;
        public readonly int SuccessThreshold;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalcontainersReadinessprobeTcpsocket TcpSocket;
        public readonly int TimeoutSeconds;

        [OutputConstructor]
        private TidbNGMonitoringSpecAdditionalcontainersReadinessprobe(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalcontainersReadinessprobeExec exec,

            int failureThreshold,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalcontainersReadinessprobeHttpget httpGet,

            int initialDelaySeconds,

            int periodSeconds,

            int successThreshold,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalcontainersReadinessprobeTcpsocket tcpSocket,

            int timeoutSeconds)
        {
            Exec = exec;
            FailureThreshold = failureThreshold;
            HttpGet = httpGet;
            InitialDelaySeconds = initialDelaySeconds;
            PeriodSeconds = periodSeconds;
            SuccessThreshold = successThreshold;
            TcpSocket = tcpSocket;
            TimeoutSeconds = timeoutSeconds;
        }
    }
}
