// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbNGMonitoringSpecNgMonitoringInitContainersEnvFromArgs : global::Pulumi.ResourceArgs
    {
        [Input("configMapRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringInitContainersEnvFromConfigMapRefArgs>? ConfigMapRef { get; set; }

        [Input("prefix")]
        public Input<string>? Prefix { get; set; }

        [Input("secretRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringInitContainersEnvFromSecretRefArgs>? SecretRef { get; set; }

        public TidbNGMonitoringSpecNgMonitoringInitContainersEnvFromArgs()
        {
        }
        public static new TidbNGMonitoringSpecNgMonitoringInitContainersEnvFromArgs Empty => new TidbNGMonitoringSpecNgMonitoringInitContainersEnvFromArgs();
    }
}
