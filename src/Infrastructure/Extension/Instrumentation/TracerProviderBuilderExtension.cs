using OpenTelemetry.Trace;

namespace Infrastructure.Extension.Instrumentation;

internal static class TracerProviderBuilderExtension
{
    internal static TracerProviderBuilder AddRepositoryInstrumentation(this TracerProviderBuilder builder, Action<RepositoryInstrumentationOptions>? configureOptions = null)
    {
        if (builder is null)
        {
            throw new ArgumentException(null, nameof(builder));
        }

        var options = new RepositoryInstrumentationOptions();
        configureOptions?.Invoke(options);

        builder.AddInstrumentation(() => new RepositoryInstrumentation(options));
        builder.AddSource(RepositoryInstrumentationHelper.ActivitySourceName);
        return builder;
    }

    public static TracerProviderBuilder AddUseCaseInstrumentation(this TracerProviderBuilder builder, Action<UseCaseInstrumentationOptions>? configureOptions = null)
    {
        if (builder is null)
        {
            throw new ArgumentException(null, nameof(builder));
        }

        var options = new UseCaseInstrumentationOptions();
        configureOptions?.Invoke(options);

        builder.AddInstrumentation(() => new UseCaseInstrumentation(options));
        builder.AddSource(UseCaseInstrumentationHelper.ActivitySourceName);
        return builder;
    }
}

public class RepositoryInstrumentationOptions
{
}


public class UseCaseInstrumentationOptions
{
}