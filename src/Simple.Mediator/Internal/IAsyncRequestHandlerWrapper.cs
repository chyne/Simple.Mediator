namespace Simple.Mediator.Internal
{
    using System.Threading.Tasks;
    using Core;
    using Interface;

    internal interface IAsyncRequestHandlerWrapper<TResponse>
    {
        Task<TResponse> Handle(IRequest<TResponse> request, TypeFactory typeFactory);
    }
}