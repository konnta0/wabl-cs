// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecWorkerAdditionalVolumesPhotonPersistentDiskArgs : global::Pulumi.ResourceArgs
    {
        [Input("fsType")]
        public Input<string>? FsType { get; set; }

        [Input("pdID", required: true)]
        public Input<string> PdID { get; set; } = null!;

        public DMClusterSpecWorkerAdditionalVolumesPhotonPersistentDiskArgs()
        {
        }
        public static new DMClusterSpecWorkerAdditionalVolumesPhotonPersistentDiskArgs Empty => new DMClusterSpecWorkerAdditionalVolumesPhotonPersistentDiskArgs();
    }
}
