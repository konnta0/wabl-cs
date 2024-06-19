using ConsoleAppFramework;
using Tool.Make.Common;

namespace Tool.Make;

internal sealed class Migration
{
    /// <summary>
    /// add migration
    /// </summary>
    /// <param name="name">migration name</param>
    /// <returns></returns>
    [Command("add")]
    public Task Add(string name)
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

    /// <summary>
    /// update database
    /// </summary>
    /// <returns></returns>
    [Command("update")]
    public Task Update()
    {
        var target = new Targets();

        AddDotnetCommand(ref target, "ef database update");
        return target.RunWithoutExitingAsync(["docker-run"]);
    }

    /// <summary>
    /// import seed data
    /// </summary>
    /// <returns></returns>
    [Command("seed-import")]
    public Task ImportSeed()
    {
        var target = new Targets();

        AddDotnetCommand(ref target, "run -- seed-import");
        return target.RunWithoutExitingAsync(["docker-run"]);
    }
}