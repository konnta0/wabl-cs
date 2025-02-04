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
    public sealed class TidbNGMonitoringSpecNgMonitoringTolerations
    {
        public readonly string Effect;
        public readonly string Key;
        public readonly string Operator;
        public readonly int TolerationSeconds;
        public readonly string Value;

        [OutputConstructor]
        private TidbNGMonitoringSpecNgMonitoringTolerations(
            string effect,

            string key,

            string @operator,

            int tolerationSeconds,

            string value)
        {
            Effect = effect;
            Key = key;
            Operator = @operator;
            TolerationSeconds = tolerationSeconds;
            Value = value;
        }
    }
}
