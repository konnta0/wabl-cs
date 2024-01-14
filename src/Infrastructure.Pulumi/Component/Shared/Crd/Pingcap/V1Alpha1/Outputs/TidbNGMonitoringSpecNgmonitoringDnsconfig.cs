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
    public sealed class TidbNGMonitoringSpecNgMonitoringDnsConfig
    {
        public readonly ImmutableArray<string> Nameservers;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringDnsConfigOptions> Options;
        public readonly ImmutableArray<string> Searches;

        [OutputConstructor]
        private TidbNGMonitoringSpecNgMonitoringDnsConfig(
            ImmutableArray<string> nameservers,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringDnsConfigOptions> options,

            ImmutableArray<string> searches)
        {
            Nameservers = nameservers;
            Options = options;
            Searches = searches;
        }
    }
}
