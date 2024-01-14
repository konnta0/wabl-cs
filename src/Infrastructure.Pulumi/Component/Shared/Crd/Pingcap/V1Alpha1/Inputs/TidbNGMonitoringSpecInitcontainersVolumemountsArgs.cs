// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbNGMonitoringSpecInitContainersVolumeMountsArgs : global::Pulumi.ResourceArgs
    {
        [Input("mountPath", required: true)]
        public Input<string> MountPath { get; set; } = null!;

        [Input("mountPropagation")]
        public Input<string>? MountPropagation { get; set; }

        [Input("name", required: true)]
        public Input<string> Name { get; set; } = null!;

        [Input("readOnly")]
        public Input<bool>? ReadOnly { get; set; }

        [Input("subPath")]
        public Input<string>? SubPath { get; set; }

        [Input("subPathExpr")]
        public Input<string>? SubPathExpr { get; set; }

        public TidbNGMonitoringSpecInitContainersVolumeMountsArgs()
        {
        }
        public static new TidbNGMonitoringSpecInitContainersVolumeMountsArgs Empty => new TidbNGMonitoringSpecInitContainersVolumeMountsArgs();
    }
}
