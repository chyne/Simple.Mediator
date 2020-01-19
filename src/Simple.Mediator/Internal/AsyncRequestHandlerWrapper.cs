namespace Simple.Mediator.Internal
{
    using System.Threading.Tasks;
    using Core;
    using Interface;

    internal class AsyncRequestHandlerWrapper<TRequest, TResponse> : IAsyncRequestHandlerWrapper<TResponse> where TRequest : IRequest<TResponse>
    {
        public Task<TResponse> Handle(IRequest<TResponse> request, TypeFactory typeFactory)
        {
            return ((IAsyncRequestHandler<TRequest, TResponse>)typeFactory(typeof(IAsyncRequestHandler<TRequest, TResponse>)))
                .Handle((TRequest)request);
        }
    }
}