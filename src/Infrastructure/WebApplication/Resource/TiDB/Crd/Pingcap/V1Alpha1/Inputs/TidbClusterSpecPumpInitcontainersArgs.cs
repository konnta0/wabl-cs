// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecPumpInitcontainersArgs : Pulumi.ResourceArgs
    {
        [Input("args")]
        private InputList<string>? _args;
        public InputList<string> Args
        {
            get => _args ?? (_args = new InputList<string>());
            set => _args = value;
        }

        [Input("command")]
        private InputList<string>? _command;
        public InputList<string> Command
        {
            get => _command ?? (_command = new InputList<string>());
            set => _command = value;
        }

        [Input("env")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersEnvArgs>? _env;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersEnvArgs> Env
        {
            get => _env ?? (_env = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersEnvArgs>());
            set => _env = value;
        }

        [Input("envFrom")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersEnvfromArgs>? _envFrom;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersEnvfromArgs> EnvFrom
        {
            get => _envFrom ?? (_envFrom = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersEnvfromArgs>());
            set => _envFrom = value;
        }

        [Input("image")]
        public Input<string>? Image { get; set; }

        [Input("imagePullPolicy")]
        public Input<string>? ImagePullPolicy { get; set; }

        [Input("lifecycle")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersLifecycleArgs>? Lifecycle { get; set; }

        [Input("livenessProbe")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersLivenessprobeArgs>? LivenessProbe { get; set; }

        [Input("name", required: true)]
        public Input<string> Name { get; set; } = null!;

        [Input("ports")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersPortsArgs>? _ports;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersPortsArgs> Ports
        {
            get => _ports ?? (_ports = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersPortsArgs>());
            set => _ports = value;
        }

        [Input("readinessProbe")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersReadinessprobeArgs>? ReadinessProbe { get; set; }

        [Input("resources")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersResourcesArgs>? Resources { get; set; }

        [Input("securityContext")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersSecuritycontextArgs>? SecurityContext { get; set; }

        [Input("startupProbe")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersStartupprobeArgs>? StartupProbe { get; set; }

        [Input("stdin")]
        public Input<bool>? Stdin { get; set; }

        [Input("stdinOnce")]
        public Input<bool>? StdinOnce { get; set; }

        [Input("terminationMessagePath")]
        public Input<string>? TerminationMessagePath { get; set; }

        [Input("terminationMessagePolicy")]
        public Input<string>? TerminationMessagePolicy { get; set; }

        [Input("tty")]
        public Input<bool>? Tty { get; set; }

        [Input("volumeDevices")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersVolumedevicesArgs>? _volumeDevices;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersVolumedevicesArgs> VolumeDevices
        {
            get => _volumeDevices ?? (_volumeDevices = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersVolumedevicesArgs>());
            set => _volumeDevices = value;
        }

        [Input("volumeMounts")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersVolumemountsArgs>? _volumeMounts;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersVolumemountsArgs> VolumeMounts
        {
            get => _volumeMounts ?? (_volumeMounts = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitcontainersVolumemountsArgs>());
            set => _volumeMounts = value;
        }

        [Input("workingDir")]
        public Input<string>? WorkingDir { get; set; }

        public TidbClusterSpecPumpInitcontainersArgs()
        {
        }
    }
}
