// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTiproxyDnsConfigArgs : global::Pulumi.ResourceArgs
    {
        [Input("nameservers")]
        private InputList<string>? _nameservers;
        public InputList<string> Nameservers
        {
            get => _nameservers ?? (_nameservers = new InputList<string>());
            set => _nameservers = value;
        }

        [Input("options")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyDnsConfigOptionsArgs>? _options;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyDnsConfigOptionsArgs> Options
        {
            get => _options ?? (_options = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyDnsConfigOptionsArgs>());
            set => _options = value;
        }

        [Input("searches")]
        private InputList<string>? _searches;
        public InputList<string> Searches
        {
            get => _searches ?? (_searches = new InputList<string>());
            set => _searches = value;
        }

        public TidbClusterSpecTiproxyDnsConfigArgs()
        {
        }
        public static new TidbClusterSpecTiproxyDnsConfigArgs Empty => new TidbClusterSpecTiproxyDnsConfigArgs();
    }
}
