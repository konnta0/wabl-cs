// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecPumpAdditionalVolumesProjectedSourcesArgs : global::Pulumi.ResourceArgs
    {
        [Input("configMap")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalVolumesProjectedSourcesConfigMapArgs>? ConfigMap { get; set; }

        [Input("downwardAPI")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalVolumesProjectedSourcesDownwardApiArgs>? DownwardAPI { get; set; }

        [Input("secret")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalVolumesProjectedSourcesSecretArgs>? Secret { get; set; }

        [Input("serviceAccountToken")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalVolumesProjectedSourcesServiceAccountTokenArgs>? ServiceAccountToken { get; set; }

        public TidbClusterSpecPumpAdditionalVolumesProjectedSourcesArgs()
        {
        }
        public static new TidbClusterSpecPumpAdditionalVolumesProjectedSourcesArgs Empty => new TidbClusterSpecPumpAdditionalVolumesProjectedSourcesArgs();
    }
}
