// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecDiscoveryAdditionalVolumesProjectedSourcesArgs : global::Pulumi.ResourceArgs
    {
        [Input("configMap")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalVolumesProjectedSourcesConfigMapArgs>? ConfigMap { get; set; }

        [Input("downwardAPI")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalVolumesProjectedSourcesDownwardApiArgs>? DownwardAPI { get; set; }

        [Input("secret")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalVolumesProjectedSourcesSecretArgs>? Secret { get; set; }

        [Input("serviceAccountToken")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalVolumesProjectedSourcesServiceAccountTokenArgs>? ServiceAccountToken { get; set; }

        public DMClusterSpecDiscoveryAdditionalVolumesProjectedSourcesArgs()
        {
        }
        public static new DMClusterSpecDiscoveryAdditionalVolumesProjectedSourcesArgs Empty => new DMClusterSpecDiscoveryAdditionalVolumesProjectedSourcesArgs();
    }
}
