// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterAutoScalerSpecTikvExternalArgs : global::Pulumi.ResourceArgs
    {
        [Input("endpoint")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterAutoScalerSpecTikvExternalEndpointArgs>? Endpoint { get; set; }

        [Input("maxReplicas", required: true)]
        public Input<int> MaxReplicas { get; set; } = null!;

        public TidbClusterAutoScalerSpecTikvExternalArgs()
        {
        }
        public static new TidbClusterAutoScalerSpecTikvExternalArgs Empty => new TidbClusterAutoScalerSpecTikvExternalArgs();
    }
}
