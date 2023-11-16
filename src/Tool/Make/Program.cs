ConsoleApp
    .Create(args)
    .AddAllCommandType()
    .AddCommand("example", "one shot example command", () =>
    {
        var target = new Targets();
        Make.Common.DirectoryUtil.TryGetSolutionDirectoryInfo(out var directory);
        target.Add("test", async () => await $"echo {directory.FullName}" );

        return target.RunWithoutExitingAsync(new[] { "test" });
    })
    .Run();