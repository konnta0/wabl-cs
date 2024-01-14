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
    public sealed class TidbNGMonitoringSpecPodSecurityContext
    {
        public readonly int FsGroup;
        public readonly string FsGroupChangePolicy;
        public readonly int RunAsGroup;
        public readonly bool RunAsNonRoot;
        public readonly int RunAsUser;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecPodSecurityContextSeLinuxOptions SeLinuxOptions;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecPodSecurityContextSeccompProfile SeccompProfile;
        public readonly ImmutableArray<int> SupplementalGroups;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecPodSecurityContextSysctls> Sysctls;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecPodSecurityContextWindowsOptions WindowsOptions;

        [OutputConstructor]
        private TidbNGMonitoringSpecPodSecurityContext(
            int fsGroup,

            string fsGroupChangePolicy,

            int runAsGroup,

            bool runAsNonRoot,

            int runAsUser,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecPodSecurityContextSeLinuxOptions seLinuxOptions,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecPodSecurityContextSeccompProfile seccompProfile,

            ImmutableArray<int> supplementalGroups,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecPodSecurityContextSysctls> sysctls,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecPodSecurityContextWindowsOptions windowsOptions)
        {
            FsGroup = fsGroup;
            FsGroupChangePolicy = fsGroupChangePolicy;
            RunAsGroup = runAsGroup;
            RunAsNonRoot = runAsNonRoot;
            RunAsUser = runAsUser;
            SeLinuxOptions = seLinuxOptions;
            SeccompProfile = seccompProfile;
            SupplementalGroups = supplementalGroups;
            Sysctls = sysctls;
            WindowsOptions = windowsOptions;
        }
    }
}
