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
    public sealed class TidbDashboardSpecInitContainers
    {
        public readonly ImmutableArray<string> Args;
        public readonly ImmutableArray<string> Command;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersEnv> Env;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersEnvFrom> EnvFrom;
        public readonly string Image;
        public readonly string ImagePullPolicy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersLifecycle Lifecycle;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersLivenessProbe LivenessProbe;
        public readonly string Name;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersPorts> Ports;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersReadinessProbe ReadinessProbe;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersResources Resources;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersSecurityContext SecurityContext;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersStartupProbe StartupProbe;
        public readonly bool Stdin;
        public readonly bool StdinOnce;
        public readonly string TerminationMessagePath;
        public readonly string TerminationMessagePolicy;
        public readonly bool Tty;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersVolumeDevices> VolumeDevices;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersVolumeMounts> VolumeMounts;
        public readonly string WorkingDir;

        [OutputConstructor]
        private TidbDashboardSpecInitContainers(
            ImmutableArray<string> args,

            ImmutableArray<string> command,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersEnv> env,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersEnvFrom> envFrom,

            string image,

            string imagePullPolicy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersLifecycle lifecycle,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersLivenessProbe livenessProbe,

            string name,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersPorts> ports,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersReadinessProbe readinessProbe,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersResources resources,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersSecurityContext securityContext,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersStartupProbe startupProbe,

            bool stdin,

            bool stdinOnce,

            string terminationMessagePath,

            string terminationMessagePolicy,

            bool tty,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersVolumeDevices> volumeDevices,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersVolumeMounts> volumeMounts,

            string workingDir)
        {
            Args = args;
            Command = command;
            Env = env;
            EnvFrom = envFrom;
            Image = image;
            ImagePullPolicy = imagePullPolicy;
            Lifecycle = lifecycle;
            LivenessProbe = livenessProbe;
            Name = name;
            Ports = ports;
            ReadinessProbe = readinessProbe;
            Resources = resources;
            SecurityContext = securityContext;
            StartupProbe = startupProbe;
            Stdin = stdin;
            StdinOnce = stdinOnce;
            TerminationMessagePath = terminationMessagePath;
            TerminationMessagePolicy = terminationMessagePolicy;
            Tty = tty;
            VolumeDevices = volumeDevices;
            VolumeMounts = volumeMounts;
            WorkingDir = workingDir;
        }
    }
}
