using System.Buffers;
using System.Collections.Immutable;
using DotPulsar;
using DotPulsar.Abstractions;

namespace MessageQueue.Domain.DataTransferObject;

public sealed record KpiLog(string LogType, object Message);

public sealed class KpiLogSchema : ISchema<KpiLog>
{
    public KpiLogSchema()
    {
        SchemaInfo = new SchemaInfo("KpiLog", [], SchemaType.Json, ImmutableDictionary<string, string>.Empty);
    }
    
    public KpiLog Decode(ReadOnlySequence<byte> bytes, byte[]? schemaVersion = null)
    {
        throw new NotImplementedException();
    }

    public ReadOnlySequence<byte> Encode(KpiLog message)
    {
        throw new NotImplementedException();
    }

    public SchemaInfo SchemaInfo { get; }
}