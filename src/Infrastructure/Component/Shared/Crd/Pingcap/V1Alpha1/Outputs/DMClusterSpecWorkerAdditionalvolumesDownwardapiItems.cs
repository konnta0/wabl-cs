// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1
{

    [OutputType]
    public sealed class DMClusterSpecWorkerAdditionalvolumesDownwardapiItems
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalvolumesDownwardapiItemsFieldref FieldRef;
        public readonly int Mode;
        public readonly string Path;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalvolumesDownwardapiItemsResourcefieldref ResourceFieldRef;

        [OutputConstructor]
        private DMClusterSpecWorkerAdditionalvolumesDownwardapiItems(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalvolumesDownwardapiItemsFieldref fieldRef,

            int mode,

            string path,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalvolumesDownwardapiItemsResourcefieldref resourceFieldRef)
        {
            FieldRef = fieldRef;
            Mode = mode;
            Path = path;
            ResourceFieldRef = resourceFieldRef;
        }
    }
}