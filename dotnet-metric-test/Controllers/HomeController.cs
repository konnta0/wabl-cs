using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnet_metric_test.Models;
using dotnet_metric_test.Monitoring.Metrics.Counter;

namespace dotnet_metric_test.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMyCounter _myCounter;

    public HomeController(ILogger<HomeController> logger, IMyCounter myCounter)
    {
        _logger = logger;
        _myCounter = myCounter;
    }

    public IActionResult Index()
    {
        _myCounter.Counter.Add(1);
        using (var activity = new ActivitySource(
                   "TEST_PRODUCT").StartActivity("SayHello"))
        {
            activity?.SetTag("foo", 1);
            activity?.SetTag("bar", "Hello, World!");
            activity?.SetTag("baz", new int[] { 1, 2, 3 });
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
