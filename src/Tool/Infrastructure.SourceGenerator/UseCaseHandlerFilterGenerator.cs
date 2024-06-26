﻿using Microsoft.CodeAnalysis;

namespace Infrastructure.SourceGenerator
{
    [Generator(LanguageNames.CSharp)]
    public class UseCaseHandlerFilterGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {

            context.RegisterPostInitializationOutput(static context =>
            {
                context.AddSource("SampleGeneratorAttribute.cs",
                    """
                            namespace WebApplication.Infrastructure.SourceGenerator;

                            using System;

                            [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
                            internal sealed class GenerateToAsyncUseCaseHandlerFilterAttribute : Attribute
                            {
                                public Type RequestType { get; }
                                public Type ResponseType { get; }

                                internal GenerateToAsyncUseCaseHandlerFilterAttribute(Type requestType, Type responseType)
                                {
                                    RequestType = requestType;
                                    ResponseType = responseType;
                                }
                            }
                        """);
            });

            var source = context.SyntaxProvider.ForAttributeWithMetadataName(
                    "System.ComponentModel.DataAnnotations.Schema.TableAttribute",
                    static (_, _) => true,
                    static (context, _) => context);
            context.RegisterSourceOutput(source, static (sourceProductionContext, s) =>
            {
            });
        }

        private static void Execute(SourceProductionContext context, GeneratorAttributeSyntaxContext source)
        {
            var typeSymbol = (INamedTypeSymbol)source.TargetSymbol;
        }

        private static void Emit(SourceProductionContext context, GeneratorAttributeSyntaxContext source)
        {
            var typeSymbol = (INamedTypeSymbol)source.TargetSymbol;
    // INamedTypeSymbol? enumAttribute = compilation.GetTypeByMetadataName("NetEscapades.EnumGenerators.EnumExtensionsAttribute");
    //
    //         var attributes = typeSymbol.GetAttributes();
    //         foreach (var attributeData in attributes)
    //         {
    //                 if (!enumAttribute.Equals(attributeData.AttributeClass, SymbolEqualityComparer.Default))
    // {
    //     // This isn't the [EnumExtensions] attribute
    //     continue;
    // }
    //         }
            
            var ns = typeSymbol.ContainingNamespace.IsGlobalNamespace
            ? ""
            : $"namespace {typeSymbol.ContainingNamespace};";

            var fullType = typeSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)
                .Replace("global::", "")
                .Replace("<", "_")
                .Replace(">", "_");

            var code = $$"""
// <auto-generated/>
// This file was generated by {{nameof(UseCaseHandlerFilterGenerator)}}.

using MessagePipe;
using WebApplication.Application.Core.RequestHandler;

{{ns}}

internal partial class {{typeSymbol.Name}} : AsyncRequestHandlerFilter<IDepartmentsInputData, IDepartmentsOutputData>, IAsyncUseCaseHandlerFilter<ListDepartmentsInputData, ListDepartmentsOutputData>
{
    public override async ValueTask<IDepartmentsOutputData> InvokeAsync(IDepartmentsInputData request, CancellationToken cancellationToken, Func<IDepartmentsInputData, CancellationToken, ValueTask<IDepartmentsOutputData>> next)
    {
        if (request is not ListDepartmentsInputData data)
        {
            return await next(request, cancellationToken);
        }

        return await HandleAsync(data);
    }
}
""";

            context.AddSource($"{fullType}.g.cs", code);
        }
    }
}