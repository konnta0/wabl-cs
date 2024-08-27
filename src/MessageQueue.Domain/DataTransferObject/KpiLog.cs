using System.Buffers;
using System.Collections.Immutable;
using System.Text;
using System.Text.Json;
using DotPulsar;
using DotPulsar.Abstractions;

namespace MessageQueue.Domain.DataTransferObject;

public sealed record KpiLog(string LogType, object Message);

public sealed class KpiLogSchema : ISchema<KpiLog>
{
    public KpiLogSchema()
    {
        SchemaInfo = new SchemaInfo("KpiLog", [], SchemaType.String, ImmutableDictionary<string, string>.Empty);
    }

    public KpiLog Decode(ReadOnlySequence<byte> bytes, byte[]? schemaVersion = null)
    {
        var str = Encoding.UTF8.GetString(bytes.ToArray());
        if (str is "") return new KpiLog("Unknown", "");
        return JsonSerializer.Deserialize<KpiLog>(str)!;
    } 

    public ReadOnlySequence<byte> Encode(KpiLog message)
    {
        var m = JsonSerializer.Serialize(message);
        var bytes = Encoding.UTF8.GetBytes(m);
        return new(bytes);
    }

    public SchemaInfo SchemaInfo { get; }
}