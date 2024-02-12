using Tool.Make.Common;

namespace Tool.Make;

public sealed class Migration : ConsoleAppBase
{
    [Command("add", "add migration")]
    public Task Add([Option("name", "migration name")] string name)
    {
        var target = new Targets();

        AddDotnetCommand(ref target, $"ef migrations add {name}");
        return target.RunWithoutExitingAsync(["docker-run"]);
    }

    private void AddDotnetCommand(ref Targets target, string command)
    {
        DirectoryUtil.TryGetSolutionDirectoryInfo(out var directoryInfo);
        target.Add("docker-build",
            () => RunAsync("docker",
                $"build -f {directoryInfo.FullName}/Dockerfile.Tool.DatabaseMigration -t database_migration ../../../"));
        target.Add("docker-run", DependsOn("docker-build"), () => RunAsync("docker",
            $"run -it " +
            $"-v {directoryInfo.FullName}/src/Tool.DatabaseMigration:/src/Tool.DatabaseMigration " +
            $"-v {directoryInfo.FullName}/src/WebApplication:/src/WebApplication " +
            $"-v {directoryInfo.FullName}/src/Tool.DatabaseMigration/Seed:/src/Seed " +
            $"-v {directoryInfo.FullName}/src/WebApplication.Domain.SourceGenerator:/src/WebApplication.Domain.SourceGenerator " +
            $"-v {directoryInfo.FullName}/src/Infrastructure.Pulumi.SourceGenerator:/src/Infrastructure.Pulumi.SourceGenerator " +
            $"--env-file={directoryInfo.FullName}/.env " +
            $"--name=database_migration " +
            $"--rm " +
            $"-w /src/Tool.DatabaseMigration " +
            $"database_migration " +
            $"dotnet {command}"
        ));
    }

    [Command("update", "update database")]
    public Task Update()
    {
        var target = new Targets();

        AddDotnetCommand(ref target, "ef database update");
        return target.RunWithoutExitingAsync(["docker-run"]);
    }

    [Command("seed-import", "import seed data")]
    public Task ImportSeed()
    {
        var target = new Targets();

        AddDotnetCommand(ref target, "run -- seed-import");
        return target.RunWithoutExitingAsync(["docker-run"]);
    }
}