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
    public sealed class TidbClusterSpecTiflashPodsecuritycontext
    {
        public readonly int FsGroup;
        public readonly string FsGroupChangePolicy;
        public readonly int RunAsGroup;
        public readonly bool RunAsNonRoot;
        public readonly int RunAsUser;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashPodsecuritycontextSelinuxoptions SeLinuxOptions;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashPodsecuritycontextSeccompprofile SeccompProfile;
        public readonly ImmutableArray<int> SupplementalGroups;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashPodsecuritycontextSysctls> Sysctls;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashPodsecuritycontextWindowsoptions WindowsOptions;

        [OutputConstructor]
        private TidbClusterSpecTiflashPodsecuritycontext(
            int fsGroup,

            string fsGroupChangePolicy,

            int runAsGroup,

            bool runAsNonRoot,

            int runAsUser,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashPodsecuritycontextSelinuxoptions seLinuxOptions,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashPodsecuritycontextSeccompprofile seccompProfile,

            ImmutableArray<int> supplementalGroups,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashPodsecuritycontextSysctls> sysctls,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashPodsecuritycontextWindowsoptions windowsOptions)
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