using System.Collections.Generic;
using System.Text.Json;

namespace Infrastructure.CDKTF.Construct.Kubernetes.Config;

internal sealed record Metadata : IKubernetesConfig
{
    public Dictionary<string, string> Annotations { get; init; } = new();

    public string? ClusterName { get; init; }

    public string? CreationTimestamp { get; init; }

    public int? DeletionGracePeriodSeconds { get; init; }

    public string? DeletionTimestamp { get; init; }

    public List<string> Finalizers { get; init; } = [];

    public string? GenerateName { get; init; }

    public int? Generation { get; init; }
    
    public Dictionary<string, string> Labels { get; init; } = new ();

    // TODO
    // [Input("managedFields")]
    // private InputList<Pulumi.Kubernetes.Types.Inputs.Meta.V1.ManagedFieldsEntryArgs>? _managedFields;
    //
    // /// <summary>
    // /// ManagedFields maps workflow-id and version to the set of fields that are managed by that workflow. This is mostly for internal housekeeping, and users typically shouldn't need to set or understand this field. A workflow can be the user's name, a controller's name, or the name of a specific apply path like "ci-cd". The set of fields is always in the version that the workflow used when modifying the object.
    // /// </summary>
    // public InputList<Pulumi.Kubernetes.Types.Inputs.Meta.V1.ManagedFieldsEntryArgs> ManagedFields
    // {
    //     get => _managedFields ??
    //            (_managedFields = new InputList<Pulumi.Kubernetes.Types.Inputs.Meta.V1.ManagedFieldsEntryArgs>());
    //     set => _managedFields = value;
    // }

    public string? Name { get; init; }

    public string? Namespace { get; init; }

    // TODO
    // [Input("ownerReferences")]
    // private InputList<Pulumi.Kubernetes.Types.Inputs.Meta.V1.OwnerReferenceArgs>? _ownerReferences;
    //
    // /// <summary>
    // /// List of objects depended by this object. If ALL objects in the list have been deleted, this object will be garbage collected. If this object is managed by a controller, then an entry in this list will point to this controller, with the controller field set to true. There cannot be more than one managing controller.
    // /// </summary>
    // public InputList<Pulumi.Kubernetes.Types.Inputs.Meta.V1.OwnerReferenceArgs> OwnerReferences
    // {
    //     get => _ownerReferences ??
    //            (_ownerReferences = new InputList<Pulumi.Kubernetes.Types.Inputs.Meta.V1.OwnerReferenceArgs>());
    //     set => _ownerReferences = value;
    // }

    public string? ResourceVersion { get; init; }

    public string? SelfLink { get; init; }

    public string? Uid { get; init; }

    public KeyValuePair<string, string> ToPair()
    {
        return new KeyValuePair<string, string>("metadata", JsonSerializer.Serialize(this, JsonSerializerOption.Default));
    }
}

internal interface IKubernetesConfig
{
    public KeyValuePair<string, string> ToPair();
}