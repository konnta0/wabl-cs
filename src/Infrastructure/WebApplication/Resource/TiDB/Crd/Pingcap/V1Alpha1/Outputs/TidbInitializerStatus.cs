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
    public sealed class TidbInitializerStatus
    {
        public readonly int Active;
        public readonly string CompletionTime;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbInitializerStatusConditions> Conditions;
        public readonly int Failed;
        public readonly string Phase;
        public readonly string StartTime;
        public readonly int Succeeded;

        [OutputConstructor]
        private TidbInitializerStatus(
            int active,

            string completionTime,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbInitializerStatusConditions> conditions,

            int failed,

            string phase,

            string startTime,

            int succeeded)
        {
            Active = active;
            CompletionTime = completionTime;
            Conditions = conditions;
            Failed = failed;
            Phase = phase;
            StartTime = startTime;
            Succeeded = succeeded;
        }
    }
}
