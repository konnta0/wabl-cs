using MessagePack;

namespace WebApplication.Domain.RestApi.HealthCheck;

public class GetSystemInfo : IApi<GetSystemInfoRequest, GetSystemInfoResponse>
{
    public HttpMethod HttpMethod => HttpMethod.Get;
    public string Endpoint => "health";
    public GetSystemInfoRequest? RequestData { get; init; }
    public GetSystemInfoResponse? ResponseData { get; init; }
}

[MessagePackObject]
public class GetSystemInfoRequest : IRequestData;

[MessagePackObject]
public class GetSystemInfoResponse : IResponseData;
