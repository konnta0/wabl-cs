// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbMonitorSpecPrometheusIngressArgs : Pulumi.ResourceArgs
    {
        [Input("annotations")]
        private InputMap<string>? _annotations;
        public InputMap<string> Annotations
        {
            get => _annotations ?? (_annotations = new InputMap<string>());
            set => _annotations = value;
        }

        [Input("hosts", required: true)]
        private InputList<string>? _hosts;
        public InputList<string> Hosts
        {
            get => _hosts ?? (_hosts = new InputList<string>());
            set => _hosts = value;
        }

        [Input("tls")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusIngressTlsArgs>? _tls;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusIngressTlsArgs> Tls
        {
            get => _tls ?? (_tls = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusIngressTlsArgs>());
            set => _tls = value;
        }

        public TidbMonitorSpecPrometheusIngressArgs()
        {
        }
    }
}