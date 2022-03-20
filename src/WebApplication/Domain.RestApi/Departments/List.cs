namespace Domain.RestApi.Departments;

public class List : IApi<ListRequestData, ListResponseData>
{
    public HttpMethod HttpMethod => HttpMethod.Get;
    public string Endpoint => "departments/list";
    public ListRequestData? RequestData { get; init; }
    public ListResponseData? ResponseData { get; init; }
}

public class ListRequestData : IRequestData
{
}

public class ListResponseData : IResponseData
{
    public IEnumerable<Object.Department>? Departments;
}