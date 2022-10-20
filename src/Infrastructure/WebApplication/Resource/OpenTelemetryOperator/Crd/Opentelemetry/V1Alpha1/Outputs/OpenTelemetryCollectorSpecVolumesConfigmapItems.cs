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
    /// Maps a string key to a path within a volume.
    /// </summary>
    [OutputType]
    public sealed class OpenTelemetryCollectorSpecVolumesConfigmapItems
    {
        /// <summary>
        /// key is the key to project.
        /// </summary>
        public readonly string Key;
        /// <summary>
        /// mode is Optional: mode bits used to set permissions on this file. Must be an octal value between 0000 and 0777 or a decimal value between 0 and 511. YAML accepts both octal and decimal values, JSON requires decimal values for mode bits. If not specified, the volume defaultMode will be used. This might be in conflict with other options that affect the file mode, like fsGroup, and the result can be other mode bits set.
        /// </summary>
        public readonly int Mode;
        /// <summary>
        /// path is the relative path of the file to map the key to. May not be an absolute path. May not contain the path element '..'. May not start with the string '..'.
        /// </summary>
        public readonly string Path;

        [OutputConstructor]
        private OpenTelemetryCollectorSpecVolumesConfigmapItems(
            string key,

            int mode,

            string path)
        {
            Key = key;
            Mode = mode;
            Path = path;
        }
    }
}
