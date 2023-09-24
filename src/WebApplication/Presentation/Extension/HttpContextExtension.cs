using System.Text.Json;
using Application.Core.Exception;
using Microsoft.AspNetCore.Diagnostics;

namespace Presentation.Extension;

internal static class HttpContextExtension
{
    public static Task HandleExceptionIfNeededAsync(this HttpContext context)
    {
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

        if (contextFeature is null)
        {
            return Task.CompletedTask;
        }
        
        var statusCode = contextFeature.Error switch
        {
            ErrorMessageException => StatusCodes.Status422UnprocessableEntity,
            BadRequestException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };

        var response = context.Response;
        response.ContentType = "application/json";
        response.StatusCode = statusCode;
        var error = new ErrorDetails
        {
            StatusCode = statusCode,
            Message = contextFeature.Error.Message
        };
        return response.WriteAsync(error.ToString());
    }
}

internal record ErrorDetails
{
    public required int StatusCode { get; init; }
    public required string Message { get; init; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}