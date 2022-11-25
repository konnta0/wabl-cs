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
    public sealed class TidbMonitorSpecPrometheusRemotewrite
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemotewriteBasicauth BasicAuth;
        public readonly string BearerToken;
        public readonly string BearerTokenFile;
        public readonly string ProxyUrl;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemotewriteQueueconfig QueueConfig;
        public readonly int RemoteTimeout;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemotewriteTlsconfig TlsConfig;
        public readonly string Url;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemotewriteWriterelabelconfigs> WriteRelabelConfigs;

        [OutputConstructor]
        private TidbMonitorSpecPrometheusRemotewrite(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemotewriteBasicauth basicAuth,

            string bearerToken,

            string bearerTokenFile,

            string proxyUrl,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemotewriteQueueconfig queueConfig,

            int remoteTimeout,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemotewriteTlsconfig tlsConfig,

            string url,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemotewriteWriterelabelconfigs> writeRelabelConfigs)
        {
            BasicAuth = basicAuth;
            BearerToken = bearerToken;
            BearerTokenFile = bearerTokenFile;
            ProxyUrl = proxyUrl;
            QueueConfig = queueConfig;
            RemoteTimeout = remoteTimeout;
            TlsConfig = tlsConfig;
            Url = url;
            WriteRelabelConfigs = writeRelabelConfigs;
        }
    }
}
