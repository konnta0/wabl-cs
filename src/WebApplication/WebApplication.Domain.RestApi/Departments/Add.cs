using MessagePack;

namespace WebApplication.Domain.RestApi.Departments;

public class Add : IApi<AddRequest, AddResponse>
{
    public HttpMethod HttpMethod => HttpMethod.Post;
    public string Endpoint => "departments/add";
    public AddRequest? RequestData { get; init; }
    public AddResponse? ResponseData { get; init; }
}

[MessagePackObject]
public class AddRequest : IRequestData
{
    [Key(0)] public string DepotNo { get; init; } = string.Empty;
    [Key(1)] public string DeptName { get; init; } = string.Empty;
}

[MessagePackObject]
public class AddResponse : IResponseData
{
}