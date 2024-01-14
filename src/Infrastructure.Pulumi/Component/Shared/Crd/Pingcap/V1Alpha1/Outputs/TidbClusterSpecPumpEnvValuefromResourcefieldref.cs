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
    public sealed class TidbClusterSpecPumpEnvValueFromResourceFieldRef
    {
        public readonly string ContainerName;
        public readonly Union<int, string> Divisor;
        public readonly string Resource;

        [OutputConstructor]
        private TidbClusterSpecPumpEnvValueFromResourceFieldRef(
            string containerName,

            Union<int, string> divisor,

            string resource)
        {
            ContainerName = containerName;
            Divisor = divisor;
            Resource = resource;
        }
    }
}
