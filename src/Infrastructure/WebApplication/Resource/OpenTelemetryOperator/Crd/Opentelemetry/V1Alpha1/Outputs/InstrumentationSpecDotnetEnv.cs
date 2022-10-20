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
    /// EnvVar represents an environment variable present in a Container.
    /// </summary>
    [OutputType]
    public sealed class InstrumentationSpecDotnetEnv
    {
        /// <summary>
        /// Name of the environment variable. Must be a C_IDENTIFIER.
        /// </summary>
        public readonly string Name;
        /// <summary>
        /// Variable references $(VAR_NAME) are expanded using the previously defined environment variables in the container and any service environment variables. If a variable cannot be resolved, the reference in the input string will be unchanged. Double $$ are reduced to a single $, which allows for escaping the $(VAR_NAME) syntax: i.e. "$$(VAR_NAME)" will produce the string literal "$(VAR_NAME)". Escaped references will never be expanded, regardless of whether the variable exists or not. Defaults to "".
        /// </summary>
        public readonly string Value;
        /// <summary>
        /// Source for the environment variable's value. Cannot be used if value is not empty.
        /// </summary>
        public readonly Pulumi.Kubernetes.Types.Outputs.Opentelemetry.V1Alpha1.InstrumentationSpecDotnetEnvValuefrom ValueFrom;

        [OutputConstructor]
        private InstrumentationSpecDotnetEnv(
            string name,

            string value,

            Pulumi.Kubernetes.Types.Outputs.Opentelemetry.V1Alpha1.InstrumentationSpecDotnetEnvValuefrom valueFrom)
        {
            Name = name;
            Value = value;
            ValueFrom = valueFrom;
        }
    }
}
