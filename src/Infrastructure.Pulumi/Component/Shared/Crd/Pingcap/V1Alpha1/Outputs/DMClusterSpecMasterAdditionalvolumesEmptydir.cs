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
    public sealed class DMClusterSpecMasterAdditionalVolumesEmptyDir
    {
        public readonly string Medium;
        public readonly Union<int, string> SizeLimit;

        [OutputConstructor]
        private DMClusterSpecMasterAdditionalVolumesEmptyDir(
            string medium,

            Union<int, string> sizeLimit)
        {
            Medium = medium;
            SizeLimit = sizeLimit;
        }
    }
}
