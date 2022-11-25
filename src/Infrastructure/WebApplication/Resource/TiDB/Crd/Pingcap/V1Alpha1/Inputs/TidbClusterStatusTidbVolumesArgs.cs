// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterStatusTidbVolumesArgs : Pulumi.ResourceArgs
    {
        [Input("boundCount")]
        public Input<int>? BoundCount { get; set; }

        [Input("currentCapacity", required: true)]
        public InputUnion<int, string> CurrentCapacity { get; set; } = null!;

        [Input("currentCount")]
        public Input<int>? CurrentCount { get; set; }

        [Input("name", required: true)]
        public Input<string> Name { get; set; } = null!;

        [Input("resizedCapacity", required: true)]
        public InputUnion<int, string> ResizedCapacity { get; set; } = null!;

        [Input("resizedCount")]
        public Input<int>? ResizedCount { get; set; }

        public TidbClusterStatusTidbVolumesArgs()
        {
        }
    }
}
