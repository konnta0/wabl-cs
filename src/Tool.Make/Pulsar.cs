namespace Tool.Make;

internal sealed class Pulsar
{
    /// <summary>
    /// up
    /// </summary>
    /// <returns></returns>
    [Command("up")]
    public Task Up()
    {
        const string command = "run -itd --rm -p 6650:6650 -p 8080:8080 --mount source=pulsardata,target=/pulsar/data --mount source=pulsarconf,target=/pulsar/conf --name pulsar apachepulsar/pulsar:3.3.1 bin/pulsar standalone";
        
        var target = new Targets();
        target.Add("up", () => RunAsync("docker", command));
        return target.RunWithoutExitingAsync(["up"]);
    }

    /// <summary>
    /// down
    /// </summary>
    /// <returns></returns>
    [Command("down")]
    public Task Down()
    {
        const string command = """
                stop pulsar
                """;
        
        var target = new Targets();
        target.Add("down", () => RunAsync("docker", command));
        return target.RunWithoutExitingAsync(["down"]);
    }
}