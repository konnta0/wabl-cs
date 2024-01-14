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
    public sealed class TidbMonitorSpecPrometheusRemoteWrite
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemoteWriteBasicAuth BasicAuth;
        public readonly string BearerToken;
        public readonly string BearerTokenFile;
        public readonly ImmutableDictionary<string, string> Headers;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemoteWriteMetadataConfig MetadataConfig;
        public readonly string Name;
        public readonly string ProxyUrl;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemoteWriteQueueConfig QueueConfig;
        public readonly int RemoteTimeout;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemoteWriteTlsConfig TlsConfig;
        public readonly string Url;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemoteWriteWriteRelabelConfigs> WriteRelabelConfigs;

        [OutputConstructor]
        private TidbMonitorSpecPrometheusRemoteWrite(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemoteWriteBasicAuth basicAuth,

            string bearerToken,

            string bearerTokenFile,

            ImmutableDictionary<string, string> headers,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemoteWriteMetadataConfig metadataConfig,

            string name,

            string proxyUrl,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemoteWriteQueueConfig queueConfig,

            int remoteTimeout,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemoteWriteTlsConfig tlsConfig,

            string url,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemoteWriteWriteRelabelConfigs> writeRelabelConfigs)
        {
            BasicAuth = basicAuth;
            BearerToken = bearerToken;
            BearerTokenFile = bearerTokenFile;
            Headers = headers;
            MetadataConfig = metadataConfig;
            Name = name;
            ProxyUrl = proxyUrl;
            QueueConfig = queueConfig;
            RemoteTimeout = remoteTimeout;
            TlsConfig = tlsConfig;
            Url = url;
            WriteRelabelConfigs = writeRelabelConfigs;
        }
    }
}
