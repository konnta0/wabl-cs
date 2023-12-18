namespace Infrastructure.Pulumi.Component
{
    internal interface IComponent<in TInput, out TOutput> where TInput : IComponentInput where TOutput : IComponentOutput
    {
        TOutput Apply(TInput input);
    }

    internal interface IComponentInput
    {
    }

    internal interface IComponentOutput
    {
    }
}