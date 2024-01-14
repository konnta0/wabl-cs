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
    public sealed class TidbClusterSpecTidbInitContainers
    {
        public readonly ImmutableArray<string> Args;
        public readonly ImmutableArray<string> Command;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersEnv> Env;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersEnvFrom> EnvFrom;
        public readonly string Image;
        public readonly string ImagePullPolicy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersLifecycle Lifecycle;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersLivenessProbe LivenessProbe;
        public readonly string Name;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersPorts> Ports;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersReadinessProbe ReadinessProbe;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersResources Resources;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersSecurityContext SecurityContext;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersStartupProbe StartupProbe;
        public readonly bool Stdin;
        public readonly bool StdinOnce;
        public readonly string TerminationMessagePath;
        public readonly string TerminationMessagePolicy;
        public readonly bool Tty;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersVolumeDevices> VolumeDevices;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersVolumeMounts> VolumeMounts;
        public readonly string WorkingDir;

        [OutputConstructor]
        private TidbClusterSpecTidbInitContainers(
            ImmutableArray<string> args,

            ImmutableArray<string> command,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersEnv> env,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersEnvFrom> envFrom,

            string image,

            string imagePullPolicy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersLifecycle lifecycle,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersLivenessProbe livenessProbe,

            string name,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersPorts> ports,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersReadinessProbe readinessProbe,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersResources resources,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersSecurityContext securityContext,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersStartupProbe startupProbe,

            bool stdin,

            bool stdinOnce,

            string terminationMessagePath,

            string terminationMessagePolicy,

            bool tty,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersVolumeDevices> volumeDevices,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersVolumeMounts> volumeMounts,

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
