using MessagePack;

namespace Domain.RestApi.Departments;

public class List : IApi<ListRequestData, ListResponseData>
{
    public HttpMethod HttpMethod => HttpMethod.Get;
    public string Endpoint => "departments/list";
    public ListRequestData? RequestData { get; init; }
    public ListResponseData? ResponseData { get; init; }
}

[MessagePackObject]
public class ListRequestData : IRequestData
{
}

[MessagePackObject]
public class ListResponseData : IResponseData
{
    [Key(0)]
    public IEnumerable<Object.Department>? Departments { get; set; }
}