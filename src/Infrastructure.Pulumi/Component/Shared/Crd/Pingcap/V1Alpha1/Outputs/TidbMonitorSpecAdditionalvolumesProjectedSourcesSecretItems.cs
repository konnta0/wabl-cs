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
    public sealed class TidbMonitorSpecAdditionalVolumesProjectedSourcesSecretItems
    {
        public readonly string Key;
        public readonly int Mode;
        public readonly string Path;

        [OutputConstructor]
        private TidbMonitorSpecAdditionalVolumesProjectedSourcesSecretItems(
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
