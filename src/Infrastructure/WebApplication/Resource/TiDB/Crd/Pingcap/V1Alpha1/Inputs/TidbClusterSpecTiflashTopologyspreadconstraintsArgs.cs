// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTiflashTopologyspreadconstraintsArgs : Pulumi.ResourceArgs
    {
        [Input("topologyKey", required: true)]
        public Input<string> TopologyKey { get; set; } = null!;

        public TidbClusterSpecTiflashTopologyspreadconstraintsArgs()
        {
        }
    }
}
