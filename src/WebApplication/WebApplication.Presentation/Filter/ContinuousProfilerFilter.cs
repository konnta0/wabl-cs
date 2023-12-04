using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication.Presentation.Filter;

internal sealed class ContinuousProfilerFilter : IAsyncActionFilter
{
    public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var labels = Pyroscope.LabelSet.Empty.BuildUpon()
        .Add("ContinuousProfilerFilter", "ActionExecutionAsync")
        .Build();

        Pyroscope.LabelsWrapper.Do(labels, Action);
        return Task.CompletedTask;

        async void Action()
        {
            await next();
        }
    }
}