using System;
using HashiCorp.Cdktf;

namespace Infrastructure.CDKTF;

class Program
{
    public static void Main(string[] args)
    {
        App app = new App();
        new MainStack(app, "Infrastructure.CDKTF");
        app.Synth();
        Console.WriteLine("App synth complete");
    }
}