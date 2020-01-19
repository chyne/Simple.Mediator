namespace Simple.Mediator.Internal
{
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Interfaces;
    using Mediator.Interfaces;

    internal class RequestHandlerWrapper<TRequest, TResponse> : IRequestHandlerWrapper<TResponse> where TRequest : IRequest<TResponse>
    {
        public TResponse Handle(IRequest<TResponse> request, TypeFactory typeFactory)
        {
            foreach (var action in ((IEnumerable<IRequestPreProcessor<TRequest, TResponse>>)typeFactory(typeof(IEnumerable<IRequestPreProcessor<TRequest, TResponse>>))).OrderBy(a => a.Order))
            {
                action.Process((TRequest)request);
            }

            var response = ((IRequestHandler<TRequest, TResponse>)typeFactory(typeof(IRequestHandler<TRequest, TResponse>)))
                .Handle((TRequest)request);

            foreach (var action in ((IEnumerable<IRequestPostProcessor<TRequest, TResponse>>)typeFactory(typeof(IEnumerable<IRequestPostProcessor<TRequest, TResponse>>))).OrderBy(a => a.Order))
            {
                action.Process((TRequest)request, response);
            }

            return response;
        }
    }
}
