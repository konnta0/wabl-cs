// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Certmanager.V1
{

    /// <summary>
    /// A node selector requirement is a selector that contains values, a key, and an operator that relates the key and values.
    /// </summary>
    [OutputType]
    public sealed class ClusterIssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchexpressions
    {
        /// <summary>
        /// The label key that the selector applies to.
        /// </summary>
        public readonly string Key;
        /// <summary>
        /// Represents a key's relationship to a set of values. Valid operators are In, NotIn, Exists, DoesNotExist. Gt, and Lt.
        /// </summary>
        public readonly string Operator;
        /// <summary>
        /// An array of string values. If the operator is In or NotIn, the values array must be non-empty. If the operator is Exists or DoesNotExist, the values array must be empty. If the operator is Gt or Lt, the values array must have a single element, which will be interpreted as an integer. This array is replaced during a strategic merge patch.
        /// </summary>
        public readonly ImmutableArray<string> Values;

        [OutputConstructor]
        private ClusterIssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchexpressions(
            string key,

            string @operator,

            ImmutableArray<string> values)
        {
            Key = key;
            Operator = @operator;
            Values = values;
        }
    }
}
