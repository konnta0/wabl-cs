// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTiproxyAffinityArgs : global::Pulumi.ResourceArgs
    {
        [Input("nodeAffinity")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAffinityNodeAffinityArgs>? NodeAffinity { get; set; }

        [Input("podAffinity")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAffinityPodAffinityArgs>? PodAffinity { get; set; }

        [Input("podAntiAffinity")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAffinityPodAntiAffinityArgs>? PodAntiAffinity { get; set; }

        public TidbClusterSpecTiproxyAffinityArgs()
        {
        }
        public static new TidbClusterSpecTiproxyAffinityArgs Empty => new TidbClusterSpecTiproxyAffinityArgs();
    }
}
