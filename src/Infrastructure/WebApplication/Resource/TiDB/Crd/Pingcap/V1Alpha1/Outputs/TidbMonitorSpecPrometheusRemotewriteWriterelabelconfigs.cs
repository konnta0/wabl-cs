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
    public sealed class TidbMonitorSpecPrometheusRemotewriteWriterelabelconfigs
    {
        public readonly string Action;
        public readonly int Modulus;
        public readonly string Regex;
        public readonly string Replacement;
        public readonly string Separator;
        public readonly ImmutableArray<string> SourceLabels;
        public readonly string TargetLabel;

        [OutputConstructor]
        private TidbMonitorSpecPrometheusRemotewriteWriterelabelconfigs(
            string action,

            int modulus,

            string regex,

            string replacement,

            string separator,

            ImmutableArray<string> sourceLabels,

            string targetLabel)
        {
            Action = action;
            Modulus = modulus;
            Regex = regex;
            Replacement = replacement;
            Separator = separator;
            SourceLabels = sourceLabels;
            TargetLabel = targetLabel;
        }
    }
}
