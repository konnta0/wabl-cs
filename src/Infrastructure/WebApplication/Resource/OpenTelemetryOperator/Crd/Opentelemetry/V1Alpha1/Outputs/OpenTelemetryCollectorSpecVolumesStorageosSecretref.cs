// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Opentelemetry.V1Alpha1
{

    /// <summary>
    /// secretRef specifies the secret to use for obtaining the StorageOS API credentials.  If not specified, default values will be attempted.
    /// </summary>
    [OutputType]
    public sealed class OpenTelemetryCollectorSpecVolumesStorageosSecretref
    {
        /// <summary>
        /// Name of the referent. More info: https://kubernetes.io/docs/concepts/overview/working-with-objects/names/#names TODO: Add other useful fields. apiVersion, kind, uid?
        /// </summary>
        public readonly string Name;

        [OutputConstructor]
        private OpenTelemetryCollectorSpecVolumesStorageosSecretref(string name)
        {
            Name = name;
        }
    }
}
