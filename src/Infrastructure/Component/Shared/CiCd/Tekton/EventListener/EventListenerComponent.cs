using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Pulumi;

namespace Infrastructure.Component.Shared.CiCd.Tekton.EventListener
{
    public class EventListenerComponent : IComponent<EventListenerComponentInput, EventListenerComponentOutput>
    {
        public EventListenerComponentOutput Apply(EventListenerComponentInput input)
        {

            _ = new Pulumi.Crds.Triggers.V1Alpha1.EventListener("build-image-listener", new Dictionary<string, object>
            {
                ["apiVersion"] = "triggers.tekton.dev/v1alpha1",
                ["kind"] = "EventListener",
                ["metadata"] = new Dictionary<string, object>
                {
                    ["name"] = "build-image-listener",
                    ["namespace"] = "tekton-pipelines"
                }.ToImmutableDictionary(),
                ["spec"] = new Dictionary<string, object>
                {
                    ["serviceAccountName"] = input.ServiceAccount.Metadata.Apply(x => x.Name),
                    ["triggers"] = new List<ImmutableDictionary<string, object>>
                    {
                        new Dictionary<string, object>
                        {
                            ["name"] = "build-image-trigger",
                            ["bindings"] = new List<ImmutableDictionary<string, object>>
                            {
                                new Dictionary<string, object>
                                {
                                    ["ref"] = "build-image-pipeline-binding"
                                }.ToImmutableDictionary()
                            }.ToImmutableArray(),
                            ["template"] = new Dictionary<string, object>
                            {
                                ["ref"] = "build-image-pipeline-template"
                            }.ToImmutableDictionary()
                        }.ToImmutableDictionary()
                    }.ToImmutableArray()
                }.ToImmutableDictionary()
            }.ToImmutableDictionary()!, new CustomResourceOptions {DependsOn = {input.TektonRelease, input.TektonTrigger, input.ServiceAccount}});
            
            return new EventListenerComponentOutput();
        }
    }
}