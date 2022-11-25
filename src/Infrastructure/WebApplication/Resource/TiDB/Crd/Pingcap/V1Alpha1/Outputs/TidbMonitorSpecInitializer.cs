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
    public sealed class TidbMonitorSpecInitializer
    {
        public readonly string BaseImage;
        public readonly ImmutableDictionary<string, string> Envs;
        public readonly string ImagePullPolicy;
        public readonly ImmutableDictionary<string, Union<int, string>> Limits;
        public readonly ImmutableDictionary<string, Union<int, string>> Requests;
        public readonly string Version;

        [OutputConstructor]
        private TidbMonitorSpecInitializer(
            string baseImage,

            ImmutableDictionary<string, string> envs,

            string imagePullPolicy,

            ImmutableDictionary<string, Union<int, string>> limits,

            ImmutableDictionary<string, Union<int, string>> requests,

            string version)
        {
            BaseImage = baseImage;
            Envs = envs;
            ImagePullPolicy = imagePullPolicy;
            Limits = limits;
            Requests = requests;
            Version = version;
        }
    }
}
