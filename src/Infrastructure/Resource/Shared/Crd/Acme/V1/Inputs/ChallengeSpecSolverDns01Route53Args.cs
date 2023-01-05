// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Acme.V1
{

    /// <summary>
    /// Use the AWS Route53 API to manage DNS01 challenge records.
    /// </summary>
    public class ChallengeSpecSolverDns01Route53Args : Pulumi.ResourceArgs
    {
        /// <summary>
        /// The AccessKeyID is used for authentication. If not set we fall-back to using env vars, shared credentials file or AWS Instance metadata see: https://docs.aws.amazon.com/sdk-for-go/v1/developer-guide/configuring-sdk.html#specifying-credentials
        /// </summary>
        [Input("accessKeyID")]
        public Input<string>? AccessKeyID { get; set; }

        /// <summary>
        /// If set, the provider will manage only this zone in Route53 and will not do an lookup using the route53:ListHostedZonesByName api call.
        /// </summary>
        [Input("hostedZoneID")]
        public Input<string>? HostedZoneID { get; set; }

        /// <summary>
        /// Always set the region when using AccessKeyID and SecretAccessKey
        /// </summary>
        [Input("region", required: true)]
        public Input<string> Region { get; set; } = null!;

        /// <summary>
        /// Role is a Role ARN which the Route53 provider will assume using either the explicit credentials AccessKeyID/SecretAccessKey or the inferred credentials from environment variables, shared credentials file or AWS Instance metadata
        /// </summary>
        [Input("role")]
        public Input<string>? Role { get; set; }

        /// <summary>
        /// The SecretAccessKey is used for authentication. If not set we fall-back to using env vars, shared credentials file or AWS Instance metadata https://docs.aws.amazon.com/sdk-for-go/v1/developer-guide/configuring-sdk.html#specifying-credentials
        /// </summary>
        [Input("secretAccessKeySecretRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Acme.V1.ChallengeSpecSolverDns01Route53SecretaccesskeysecretrefArgs>? SecretAccessKeySecretRef { get; set; }

        public ChallengeSpecSolverDns01Route53Args()
        {
        }
    }
}
