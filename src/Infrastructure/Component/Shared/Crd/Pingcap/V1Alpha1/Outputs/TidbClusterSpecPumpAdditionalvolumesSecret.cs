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
    public sealed class TidbClusterSpecPumpAdditionalvolumesSecret
    {
        public readonly int DefaultMode;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalvolumesSecretItems> Items;
        public readonly bool Optional;
        public readonly string SecretName;

        [OutputConstructor]
        private TidbClusterSpecPumpAdditionalvolumesSecret(
            int defaultMode,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalvolumesSecretItems> items,

            bool optional,

            string secretName)
        {
            DefaultMode = defaultMode;
            Items = items;
            Optional = optional;
            SecretName = secretName;
        }
    }
}