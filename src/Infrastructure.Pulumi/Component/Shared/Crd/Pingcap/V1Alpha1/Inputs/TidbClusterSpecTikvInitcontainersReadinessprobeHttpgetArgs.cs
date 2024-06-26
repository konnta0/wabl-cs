// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTikvInitContainersReadinessProbeHttpGetArgs : global::Pulumi.ResourceArgs
    {
        [Input("host")]
        public Input<string>? Host { get; set; }

        [Input("httpHeaders")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTikvInitContainersReadinessProbeHttpGetHttpHeadersArgs>? _httpHeaders;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTikvInitContainersReadinessProbeHttpGetHttpHeadersArgs> HttpHeaders
        {
            get => _httpHeaders ?? (_httpHeaders = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTikvInitContainersReadinessProbeHttpGetHttpHeadersArgs>());
            set => _httpHeaders = value;
        }

        [Input("path")]
        public Input<string>? Path { get; set; }

        [Input("port", required: true)]
        public InputUnion<int, string> Port { get; set; } = null!;

        [Input("scheme")]
        public Input<string>? Scheme { get; set; }

        public TidbClusterSpecTikvInitContainersReadinessProbeHttpGetArgs()
        {
        }
        public static new TidbClusterSpecTikvInitContainersReadinessProbeHttpGetArgs Empty => new TidbClusterSpecTikvInitContainersReadinessProbeHttpGetArgs();
    }
}
