// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbInitializerSpecArgs : global::Pulumi.ResourceArgs
    {
        [Input("cluster", required: true)]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbInitializerSpecClusterArgs> Cluster { get; set; } = null!;

        [Input("image", required: true)]
        public Input<string> Image { get; set; } = null!;

        [Input("imagePullPolicy")]
        public Input<string>? ImagePullPolicy { get; set; }

        [Input("imagePullSecrets")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbInitializerSpecImagePullSecretsArgs>? _imagePullSecrets;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbInitializerSpecImagePullSecretsArgs> ImagePullSecrets
        {
            get => _imagePullSecrets ?? (_imagePullSecrets = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbInitializerSpecImagePullSecretsArgs>());
            set => _imagePullSecrets = value;
        }

        [Input("initSql")]
        public Input<string>? InitSql { get; set; }

        [Input("initSqlConfigMap")]
        public Input<string>? InitSqlConfigMap { get; set; }

        [Input("passwordSecret")]
        public Input<string>? PasswordSecret { get; set; }

        [Input("permitHost")]
        public Input<string>? PermitHost { get; set; }

        [Input("podSecurityContext")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbInitializerSpecPodSecurityContextArgs>? PodSecurityContext { get; set; }

        [Input("resources")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbInitializerSpecResourcesArgs>? Resources { get; set; }

        [Input("timezone")]
        public Input<string>? Timezone { get; set; }

        [Input("tlsClientSecretName")]
        public Input<string>? TlsClientSecretName { get; set; }

        [Input("tolerations")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbInitializerSpecTolerationsArgs>? _tolerations;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbInitializerSpecTolerationsArgs> Tolerations
        {
            get => _tolerations ?? (_tolerations = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbInitializerSpecTolerationsArgs>());
            set => _tolerations = value;
        }

        public TidbInitializerSpecArgs()
        {
        }
        public static new TidbInitializerSpecArgs Empty => new TidbInitializerSpecArgs();
    }
}
