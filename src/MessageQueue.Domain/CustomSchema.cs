using MessageQueue.Domain.DataTransferObject;

namespace MessageQueue.Domain;

public static class CustomSchema
{
    static CustomSchema()
    {
        KpiLogSchema = new KpiLogSchema();
    }
    public static KpiLogSchema KpiLogSchema { get; }
}