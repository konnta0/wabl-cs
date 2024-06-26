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
    public sealed class TidbMonitorSpecPrometheusIngress
    {
        public readonly ImmutableDictionary<string, string> Annotations;
        public readonly ImmutableArray<string> Hosts;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusIngressTls> Tls;

        [OutputConstructor]
        private TidbMonitorSpecPrometheusIngress(
            ImmutableDictionary<string, string> annotations,

            ImmutableArray<string> hosts,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusIngressTls> tls)
        {
            Annotations = annotations;
            Hosts = hosts;
            Tls = tls;
        }
    }
}
