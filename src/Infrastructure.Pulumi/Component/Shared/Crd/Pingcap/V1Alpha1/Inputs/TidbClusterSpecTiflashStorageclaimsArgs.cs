// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTiflashStorageclaimsArgs : Pulumi.ResourceArgs
    {
        [Input("resources")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashStorageclaimsResourcesArgs>? Resources { get; set; }

        [Input("storageClassName")]
        public Input<string>? StorageClassName { get; set; }

        public TidbClusterSpecTiflashStorageclaimsArgs()
        {
        }
    }
}