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
    public sealed class DMClusterSpecPodSecurityContextWindowsOptions
    {
        public readonly string GmsaCredentialSpec;
        public readonly string GmsaCredentialSpecName;
        public readonly string RunAsUserName;

        [OutputConstructor]
        private DMClusterSpecPodSecurityContextWindowsOptions(
            string gmsaCredentialSpec,

            string gmsaCredentialSpecName,

            string runAsUserName)
        {
            GmsaCredentialSpec = gmsaCredentialSpec;
            GmsaCredentialSpecName = gmsaCredentialSpecName;
            RunAsUserName = runAsUserName;
        }
    }
}
