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
    public sealed class TidbDashboardSpecReadinessProbe
    {
        public readonly int InitialDelaySeconds;
        public readonly int PeriodSeconds;
        public readonly string Type;

        [OutputConstructor]
        private TidbDashboardSpecReadinessProbe(
            int initialDelaySeconds,

            int periodSeconds,

            string type)
        {
            InitialDelaySeconds = initialDelaySeconds;
            PeriodSeconds = periodSeconds;
            Type = type;
        }
    }
}
