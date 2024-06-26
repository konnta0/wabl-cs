// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbNGMonitoringSpecNgMonitoringAdditionalContainersArgs : global::Pulumi.ResourceArgs
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
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersEnvArgs>? _env;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersEnvArgs> Env
        {
            get => _env ?? (_env = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersEnvArgs>());
            set => _env = value;
        }

        [Input("envFrom")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersEnvFromArgs>? _envFrom;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersEnvFromArgs> EnvFrom
        {
            get => _envFrom ?? (_envFrom = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersEnvFromArgs>());
            set => _envFrom = value;
        }

        [Input("image")]
        public Input<string>? Image { get; set; }

        [Input("imagePullPolicy")]
        public Input<string>? ImagePullPolicy { get; set; }

        [Input("lifecycle")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersLifecycleArgs>? Lifecycle { get; set; }

        [Input("livenessProbe")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersLivenessProbeArgs>? LivenessProbe { get; set; }

        [Input("name", required: true)]
        public Input<string> Name { get; set; } = null!;

        [Input("ports")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersPortsArgs>? _ports;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersPortsArgs> Ports
        {
            get => _ports ?? (_ports = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersPortsArgs>());
            set => _ports = value;
        }

        [Input("readinessProbe")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersReadinessProbeArgs>? ReadinessProbe { get; set; }

        [Input("resources")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersResourcesArgs>? Resources { get; set; }

        [Input("securityContext")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersSecurityContextArgs>? SecurityContext { get; set; }

        [Input("startupProbe")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersStartupProbeArgs>? StartupProbe { get; set; }

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
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersVolumeDevicesArgs>? _volumeDevices;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersVolumeDevicesArgs> VolumeDevices
        {
            get => _volumeDevices ?? (_volumeDevices = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersVolumeDevicesArgs>());
            set => _volumeDevices = value;
        }

        [Input("volumeMounts")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersVolumeMountsArgs>? _volumeMounts;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersVolumeMountsArgs> VolumeMounts
        {
            get => _volumeMounts ?? (_volumeMounts = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoringAdditionalContainersVolumeMountsArgs>());
            set => _volumeMounts = value;
        }

        [Input("workingDir")]
        public Input<string>? WorkingDir { get; set; }

        public TidbNGMonitoringSpecNgMonitoringAdditionalContainersArgs()
        {
        }
        public static new TidbNGMonitoringSpecNgMonitoringAdditionalContainersArgs Empty => new TidbNGMonitoringSpecNgMonitoringAdditionalContainersArgs();
    }
}
