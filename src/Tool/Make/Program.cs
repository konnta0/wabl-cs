ConsoleApp
    .Create(args)
    .AddAllCommandType()
    .AddCommand("example", "one shot example command", () =>
    {
        var target = new Targets();
        target.Add("test", () => RunAsync("ls", "-al"));
        return target.RunWithoutExitingAsync(new[] { "test" });
    })
    .Run();