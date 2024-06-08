using WebApplication.Application.Core.RequestHandler;
using WebApplication.Domain.RestApi;

namespace WebApplication.Presentation.Extension.ResponseDataFactory;

internal interface IResponseDataFactory<out T, in TIn> where T : IResponseData where TIn : IUseCaseOutput
{
    static abstract T Create(TIn useCaseOutput);
}