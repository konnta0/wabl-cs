// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecWorkerAdditionalcontainersArgs : Pulumi.ResourceArgs
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
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersEnvArgs>? _env;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersEnvArgs> Env
        {
            get => _env ?? (_env = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersEnvArgs>());
            set => _env = value;
        }

        [Input("envFrom")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersEnvfromArgs>? _envFrom;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersEnvfromArgs> EnvFrom
        {
            get => _envFrom ?? (_envFrom = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersEnvfromArgs>());
            set => _envFrom = value;
        }

        [Input("image")]
        public Input<string>? Image { get; set; }

        [Input("imagePullPolicy")]
        public Input<string>? ImagePullPolicy { get; set; }

        [Input("lifecycle")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersLifecycleArgs>? Lifecycle { get; set; }

        [Input("livenessProbe")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersLivenessprobeArgs>? LivenessProbe { get; set; }

        [Input("name", required: true)]
        public Input<string> Name { get; set; } = null!;

        [Input("ports")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersPortsArgs>? _ports;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersPortsArgs> Ports
        {
            get => _ports ?? (_ports = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersPortsArgs>());
            set => _ports = value;
        }

        [Input("readinessProbe")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersReadinessprobeArgs>? ReadinessProbe { get; set; }

        [Input("resources")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersResourcesArgs>? Resources { get; set; }

        [Input("securityContext")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersSecuritycontextArgs>? SecurityContext { get; set; }

        [Input("startupProbe")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersStartupprobeArgs>? StartupProbe { get; set; }

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
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersVolumedevicesArgs>? _volumeDevices;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersVolumedevicesArgs> VolumeDevices
        {
            get => _volumeDevices ?? (_volumeDevices = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersVolumedevicesArgs>());
            set => _volumeDevices = value;
        }

        [Input("volumeMounts")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersVolumemountsArgs>? _volumeMounts;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersVolumemountsArgs> VolumeMounts
        {
            get => _volumeMounts ?? (_volumeMounts = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainersVolumemountsArgs>());
            set => _volumeMounts = value;
        }

        [Input("workingDir")]
        public Input<string>? WorkingDir { get; set; }

        public DMClusterSpecWorkerAdditionalcontainersArgs()
        {
        }
    }
}