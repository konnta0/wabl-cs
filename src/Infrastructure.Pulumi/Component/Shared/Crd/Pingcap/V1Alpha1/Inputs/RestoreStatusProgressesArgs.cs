// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class RestoreStatusProgressesArgs : global::Pulumi.ResourceArgs
    {
        [Input("lastTransitionTime")]
        public Input<string>? LastTransitionTime { get; set; }

        [Input("progress")]
        public Input<double>? Progress { get; set; }

        [Input("step")]
        public Input<string>? Step { get; set; }

        public RestoreStatusProgressesArgs()
        {
        }
        public static new RestoreStatusProgressesArgs Empty => new RestoreStatusProgressesArgs();
    }
}
