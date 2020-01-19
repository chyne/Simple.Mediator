namespace Simple.Mediator.Internal.Interfaces
{
    using System.Threading.Tasks;
    using Core;
    using Mediator.Interfaces;

    internal interface IAsyncRequestHandlerWrapper<TResponse>
    {
        Task<TResponse> Handle(IRequest<TResponse> request, TypeFactory typeFactory);
    }
}
