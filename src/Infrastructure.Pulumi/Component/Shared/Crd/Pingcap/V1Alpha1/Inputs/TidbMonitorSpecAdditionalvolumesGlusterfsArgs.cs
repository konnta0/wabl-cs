// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbMonitorSpecAdditionalVolumesGlusterfsArgs : global::Pulumi.ResourceArgs
    {
        [Input("endpoints", required: true)]
        public Input<string> Endpoints { get; set; } = null!;

        [Input("path", required: true)]
        public Input<string> Path { get; set; } = null!;

        [Input("readOnly")]
        public Input<bool>? ReadOnly { get; set; }

        public TidbMonitorSpecAdditionalVolumesGlusterfsArgs()
        {
        }
        public static new TidbMonitorSpecAdditionalVolumesGlusterfsArgs Empty => new TidbMonitorSpecAdditionalVolumesGlusterfsArgs();
    }
}
