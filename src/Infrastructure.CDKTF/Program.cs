using System;
using HashiCorp.Cdktf;
using Infrastructure.CDKTF.Stack;

namespace Infrastructure.CDKTF;

sealed class Program
{
    public static void Main(string[] args)
    {
        var environment = System.Environment.GetEnvironmentVariable("APPLICATION_ENVIRONMENT");
        if (string.IsNullOrEmpty(environment))
        {
            throw new ApplicationException("should set APPLICATION_ENVIRONMENT");
        }

        var app = new App();
        _ = environment.ToLower() switch
        {
            "local" => new LocalStack(app, "Infrastructure.CDKTF"),
            _ => throw new ArgumentException("unknown environment")
        };

        app.Synth();
        Console.WriteLine("EnvironmentApp synth complete");
    }
}