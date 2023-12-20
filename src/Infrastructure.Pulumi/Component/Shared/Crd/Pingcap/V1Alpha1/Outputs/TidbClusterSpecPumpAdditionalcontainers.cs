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
    public sealed class TidbClusterSpecPumpAdditionalcontainers
    {
        public readonly ImmutableArray<string> Args;
        public readonly ImmutableArray<string> Command;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersEnv> Env;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersEnvfrom> EnvFrom;
        public readonly string Image;
        public readonly string ImagePullPolicy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersLifecycle Lifecycle;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersLivenessprobe LivenessProbe;
        public readonly string Name;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersPorts> Ports;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersReadinessprobe ReadinessProbe;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersResources Resources;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersSecuritycontext SecurityContext;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersStartupprobe StartupProbe;
        public readonly bool Stdin;
        public readonly bool StdinOnce;
        public readonly string TerminationMessagePath;
        public readonly string TerminationMessagePolicy;
        public readonly bool Tty;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersVolumedevices> VolumeDevices;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersVolumemounts> VolumeMounts;
        public readonly string WorkingDir;

        [OutputConstructor]
        private TidbClusterSpecPumpAdditionalcontainers(
            ImmutableArray<string> args,

            ImmutableArray<string> command,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersEnv> env,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersEnvfrom> envFrom,

            string image,

            string imagePullPolicy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersLifecycle lifecycle,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersLivenessprobe livenessProbe,

            string name,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersPorts> ports,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersReadinessprobe readinessProbe,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersResources resources,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersSecuritycontext securityContext,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersStartupprobe startupProbe,

            bool stdin,

            bool stdinOnce,

            string terminationMessagePath,

            string terminationMessagePolicy,

            bool tty,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersVolumedevices> volumeDevices,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalcontainersVolumemounts> volumeMounts,

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