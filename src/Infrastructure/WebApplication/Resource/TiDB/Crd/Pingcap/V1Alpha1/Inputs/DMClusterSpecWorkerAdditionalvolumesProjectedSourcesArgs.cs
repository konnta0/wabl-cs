// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecWorkerAdditionalvolumesProjectedSourcesArgs : Pulumi.ResourceArgs
    {
        [Input("configMap")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalvolumesProjectedSourcesConfigmapArgs>? ConfigMap { get; set; }

        [Input("downwardAPI")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalvolumesProjectedSourcesDownwardapiArgs>? DownwardAPI { get; set; }

        [Input("secret")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalvolumesProjectedSourcesSecretArgs>? Secret { get; set; }

        [Input("serviceAccountToken")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalvolumesProjectedSourcesServiceaccounttokenArgs>? ServiceAccountToken { get; set; }

        public DMClusterSpecWorkerAdditionalvolumesProjectedSourcesArgs()
        {
        }
    }
}
