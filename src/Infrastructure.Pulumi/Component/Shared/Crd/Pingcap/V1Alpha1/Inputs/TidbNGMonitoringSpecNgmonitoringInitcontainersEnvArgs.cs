// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbNGMonitoringSpecNgMonitoringInitContainersEnvArgs : global::Pulumi.ResourceArgs
    {
        [Input("name", required: true)]
        public Input<string> Name { get; set; } = null!;

        [Input("value")]
        public Input<string>? Value { get; set; }

        [Input("valueFrom")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringInitContainersEnvValueFromArgs>? ValueFrom { get; set; }

        public TidbNGMonitoringSpecNgMonitoringInitContainersEnvArgs()
        {
        }
        public static new TidbNGMonitoringSpecNgMonitoringInitContainersEnvArgs Empty => new TidbNGMonitoringSpecNgMonitoringInitContainersEnvArgs();
    }
}
