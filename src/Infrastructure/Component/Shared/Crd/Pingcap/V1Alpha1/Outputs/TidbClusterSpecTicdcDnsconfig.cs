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
    public sealed class TidbClusterSpecTicdcDnsconfig
    {
        public readonly ImmutableArray<string> Nameservers;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcDnsconfigOptions> Options;
        public readonly ImmutableArray<string> Searches;

        [OutputConstructor]
        private TidbClusterSpecTicdcDnsconfig(
            ImmutableArray<string> nameservers,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcDnsconfigOptions> options,

            ImmutableArray<string> searches)
        {
            Nameservers = nameservers;
            Options = options;
            Searches = searches;
        }
    }
}