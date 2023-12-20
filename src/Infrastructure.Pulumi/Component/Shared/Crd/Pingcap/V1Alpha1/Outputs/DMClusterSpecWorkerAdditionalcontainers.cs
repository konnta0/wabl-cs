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
    public sealed class DMClusterSpecWorkerAdditionalcontainers
    {
        public readonly ImmutableArray<string> Args;
        public readonly ImmutableArray<string> Command;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersEnv> Env;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersEnvfrom> EnvFrom;
        public readonly string Image;
        public readonly string ImagePullPolicy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersLifecycle Lifecycle;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersLivenessprobe LivenessProbe;
        public readonly string Name;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersPorts> Ports;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersReadinessprobe ReadinessProbe;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersResources Resources;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersSecuritycontext SecurityContext;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersStartupprobe StartupProbe;
        public readonly bool Stdin;
        public readonly bool StdinOnce;
        public readonly string TerminationMessagePath;
        public readonly string TerminationMessagePolicy;
        public readonly bool Tty;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersVolumedevices> VolumeDevices;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersVolumemounts> VolumeMounts;
        public readonly string WorkingDir;

        [OutputConstructor]
        private DMClusterSpecWorkerAdditionalcontainers(
            ImmutableArray<string> args,

            ImmutableArray<string> command,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersEnv> env,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersEnvfrom> envFrom,

            string image,

            string imagePullPolicy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersLifecycle lifecycle,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersLivenessprobe livenessProbe,

            string name,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersPorts> ports,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersReadinessprobe readinessProbe,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersResources resources,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersSecuritycontext securityContext,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersStartupprobe startupProbe,

            bool stdin,

            bool stdinOnce,

            string terminationMessagePath,

            string terminationMessagePolicy,

            bool tty,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersVolumedevices> volumeDevices,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersVolumemounts> volumeMounts,

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