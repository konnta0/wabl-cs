// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTiproxyAdditionalVolumesProjectedSourcesArgs : global::Pulumi.ResourceArgs
    {
        [Input("configMap")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesProjectedSourcesConfigMapArgs>? ConfigMap { get; set; }

        [Input("downwardAPI")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesProjectedSourcesDownwardApiArgs>? DownwardAPI { get; set; }

        [Input("secret")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesProjectedSourcesSecretArgs>? Secret { get; set; }

        [Input("serviceAccountToken")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesProjectedSourcesServiceAccountTokenArgs>? ServiceAccountToken { get; set; }

        public TidbClusterSpecTiproxyAdditionalVolumesProjectedSourcesArgs()
        {
        }
        public static new TidbClusterSpecTiproxyAdditionalVolumesProjectedSourcesArgs Empty => new TidbClusterSpecTiproxyAdditionalVolumesProjectedSourcesArgs();
    }
}