// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Opentelemetry.V1Alpha1
{

    /// <summary>
    /// Java defines configuration for java auto-instrumentation.
    /// </summary>
    [OutputType]
    public sealed class InstrumentationSpecJava
    {
        /// <summary>
        /// Env defines java specific env vars. There are four layers for env vars' definitions and the precedence order is: `original container env vars` &gt; `language specific env vars` &gt; `common env vars` &gt; `instrument spec configs' vars`. If the former var had been defined, then the other vars would be ignored.
        /// </summary>
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Opentelemetry.V1Alpha1.InstrumentationSpecJavaEnv> Env;
        /// <summary>
        /// Image is a container image with javaagent auto-instrumentation JAR.
        /// </summary>
        public readonly string Image;

        [OutputConstructor]
        private InstrumentationSpecJava(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Opentelemetry.V1Alpha1.InstrumentationSpecJavaEnv> env,

            string image)
        {
            Env = env;
            Image = image;
        }
    }
}
