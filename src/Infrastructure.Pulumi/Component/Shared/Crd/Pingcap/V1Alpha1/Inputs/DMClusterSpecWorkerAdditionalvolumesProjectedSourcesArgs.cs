// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecWorkerAdditionalVolumesProjectedSourcesArgs : global::Pulumi.ResourceArgs
    {
        [Input("configMap")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalVolumesProjectedSourcesConfigMapArgs>? ConfigMap { get; set; }

        [Input("downwardAPI")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalVolumesProjectedSourcesDownwardApiArgs>? DownwardAPI { get; set; }

        [Input("secret")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalVolumesProjectedSourcesSecretArgs>? Secret { get; set; }

        [Input("serviceAccountToken")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalVolumesProjectedSourcesServiceAccountTokenArgs>? ServiceAccountToken { get; set; }

        public DMClusterSpecWorkerAdditionalVolumesProjectedSourcesArgs()
        {
        }
        public static new DMClusterSpecWorkerAdditionalVolumesProjectedSourcesArgs Empty => new DMClusterSpecWorkerAdditionalVolumesProjectedSourcesArgs();
    }
}
