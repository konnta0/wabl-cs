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
    public sealed class TidbClusterSpecPumpAdditionalVolumesEphemeralVolumeClaimTemplateSpecDataSource
    {
        public readonly string ApiGroup;
        public readonly string Kind;
        public readonly string Name;

        [OutputConstructor]
        private TidbClusterSpecPumpAdditionalVolumesEphemeralVolumeClaimTemplateSpecDataSource(
            string apiGroup,

            string kind,

            string name)
        {
            ApiGroup = apiGroup;
            Kind = kind;
            Name = name;
        }
    }
}
