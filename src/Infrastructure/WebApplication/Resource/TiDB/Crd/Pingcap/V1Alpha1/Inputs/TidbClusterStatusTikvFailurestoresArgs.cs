// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterStatusTikvFailurestoresArgs : Pulumi.ResourceArgs
    {
        [Input("createdAt")]
        public Input<string>? CreatedAt { get; set; }

        [Input("podName")]
        public Input<string>? PodName { get; set; }

        [Input("storeID")]
        public Input<string>? StoreID { get; set; }

        public TidbClusterStatusTikvFailurestoresArgs()
        {
        }
    }
}
