// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbNGMonitoringSpecTolerationsArgs : global::Pulumi.ResourceArgs
    {
        [Input("effect")]
        public Input<string>? Effect { get; set; }

        [Input("key")]
        public Input<string>? Key { get; set; }

        [Input("operator")]
        public Input<string>? Operator { get; set; }

        [Input("tolerationSeconds")]
        public Input<int>? TolerationSeconds { get; set; }

        [Input("value")]
        public Input<string>? Value { get; set; }

        public TidbNGMonitoringSpecTolerationsArgs()
        {
        }
        public static new TidbNGMonitoringSpecTolerationsArgs Empty => new TidbNGMonitoringSpecTolerationsArgs();
    }
}
