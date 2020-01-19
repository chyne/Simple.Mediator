namespace Simple.Mediator.Internal
{
    using Core;
    using Interface;

    internal class RequestHandlerWrapper<TRequest, TResponse> : IRequestHandlerWrapper<TResponse> where TRequest : IRequest<TResponse>
    {
        public TResponse Handle(IRequest<TResponse> request, TypeFactory typeFactory)
        {
            return ((IRequestHandler<TRequest, TResponse>)typeFactory(typeof(IRequestHandler<TRequest, TResponse>)))
                .Handle((TRequest)request);
        }
    }
}
