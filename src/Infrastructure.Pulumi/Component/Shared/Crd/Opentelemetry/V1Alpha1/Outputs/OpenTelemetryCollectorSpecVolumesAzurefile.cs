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
    /// azureFile represents an Azure File Service mount on the host and bind mount to the pod.
    /// </summary>
    [OutputType]
    public sealed class OpenTelemetryCollectorSpecVolumesAzurefile
    {
        /// <summary>
        /// readOnly defaults to false (read/write). ReadOnly here will force the ReadOnly setting in VolumeMounts.
        /// </summary>
        public readonly bool ReadOnly;
        /// <summary>
        /// secretName is the  name of secret that contains Azure Storage Account Name and Key
        /// </summary>
        public readonly string SecretName;
        /// <summary>
        /// shareName is the azure share Name
        /// </summary>
        public readonly string ShareName;

        [OutputConstructor]
        private OpenTelemetryCollectorSpecVolumesAzurefile(
            bool readOnly,

            string secretName,

            string shareName)
        {
            ReadOnly = readOnly;
            SecretName = secretName;
            ShareName = shareName;
        }
    }
}
