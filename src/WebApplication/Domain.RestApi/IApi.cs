namespace Domain.RestApi;

public interface IApi<TRequest, TResponse> where TRequest : IRequestData where TResponse : IResponseData
{
    public HttpMethod HttpMethod { get; }
    public string Endpoint { get; }
    public TRequest? RequestData { get; init; }
    public TResponse? ResponseData { get; init; }
}