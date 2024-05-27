using MessagePack;

namespace WebApplication.Domain.RestApi.Departments;

public class List : IApi<ListRequest, ListResponse>
{
    public HttpMethod HttpMethod => HttpMethod.Get;
    public string Endpoint => "departments/list";
    public ListRequest? RequestData { get; init; }
    public ListResponse? ResponseData { get; init; }
}

[MessagePackObject]
public class ListRequest : IRequestData;

[MessagePackObject]
public class ListResponse : IResponseData
{
    [Key(0)]
    public IEnumerable<Object.Department>? Departments { get; set; }
}