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
    public sealed class TidbInitializerSpec
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbInitializerSpecCluster Cluster;
        public readonly string Image;
        public readonly string ImagePullPolicy;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbInitializerSpecImagepullsecrets> ImagePullSecrets;
        public readonly string InitSql;
        public readonly string InitSqlConfigMap;
        public readonly string PasswordSecret;
        public readonly string PermitHost;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbInitializerSpecPodsecuritycontext PodSecurityContext;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbInitializerSpecResources Resources;
        public readonly string Timezone;
        public readonly string TlsClientSecretName;

        [OutputConstructor]
        private TidbInitializerSpec(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbInitializerSpecCluster cluster,

            string image,

            string imagePullPolicy,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbInitializerSpecImagepullsecrets> imagePullSecrets,

            string initSql,

            string initSqlConfigMap,

            string passwordSecret,

            string permitHost,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbInitializerSpecPodsecuritycontext podSecurityContext,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbInitializerSpecResources resources,

            string timezone,

            string tlsClientSecretName)
        {
            Cluster = cluster;
            Image = image;
            ImagePullPolicy = imagePullPolicy;
            ImagePullSecrets = imagePullSecrets;
            InitSql = initSql;
            InitSqlConfigMap = initSqlConfigMap;
            PasswordSecret = passwordSecret;
            PermitHost = permitHost;
            PodSecurityContext = podSecurityContext;
            Resources = resources;
            Timezone = timezone;
            TlsClientSecretName = tlsClientSecretName;
        }
    }
}
