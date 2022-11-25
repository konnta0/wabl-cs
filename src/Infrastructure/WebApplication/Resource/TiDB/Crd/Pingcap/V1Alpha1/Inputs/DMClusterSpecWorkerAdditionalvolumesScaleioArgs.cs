// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecWorkerAdditionalvolumesScaleioArgs : Pulumi.ResourceArgs
    {
        [Input("fsType")]
        public Input<string>? FsType { get; set; }

        [Input("gateway", required: true)]
        public Input<string> Gateway { get; set; } = null!;

        [Input("protectionDomain")]
        public Input<string>? ProtectionDomain { get; set; }

        [Input("readOnly")]
        public Input<bool>? ReadOnly { get; set; }

        [Input("secretRef", required: true)]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalvolumesScaleioSecretrefArgs> SecretRef { get; set; } = null!;

        [Input("sslEnabled")]
        public Input<bool>? SslEnabled { get; set; }

        [Input("storageMode")]
        public Input<string>? StorageMode { get; set; }

        [Input("storagePool")]
        public Input<string>? StoragePool { get; set; }

        [Input("system", required: true)]
        public Input<string> System { get; set; } = null!;

        [Input("volumeName")]
        public Input<string>? VolumeName { get; set; }

        public DMClusterSpecWorkerAdditionalvolumesScaleioArgs()
        {
        }
    }
}
