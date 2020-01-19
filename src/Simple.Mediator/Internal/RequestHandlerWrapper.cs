namespace Simple.Mediator.Internal
{
    using System.Linq;
    using Core;
    using Interfaces;
    using Mediator.Interfaces;

    internal class RequestHandlerWrapper<TRequest, TResponse> : IRequestHandlerWrapper<TResponse> where TRequest : IRequest<TResponse>
    {
        public TResponse Handle(IRequest<TResponse> request, TypeFactory typeFactory)
        {
            foreach (var action in typeFactory.GetInstances<IRequestPreProcessor<TRequest, TResponse>>().OrderBy(a => a.Order))
            {
                action.Process((TRequest)request);
            }

            var response = typeFactory.GetInstance<IRequestHandler<TRequest, TResponse>>().Handle((TRequest)request);

            foreach (var action in typeFactory.GetInstances<IRequestPostProcessor<TRequest, TResponse>>().OrderBy(a => a.Order))
            {
                action.Process((TRequest)request, response);
            }

            return response;
        }
    }
}
