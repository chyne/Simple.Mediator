namespace Simple.Mediator.Internal
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core;
    using Interfaces;
    using Mediator.Interfaces;

    internal class AsyncRequestHandlerWrapper<TRequest, TResponse> : IAsyncRequestHandlerWrapper<TResponse> where TRequest : IRequest<TResponse>
    {

        public async Task<TResponse> Handle(IRequest<TResponse> request, TypeFactory typeFactory)
        {
            foreach (var action in (IEnumerable<IAsyncRequestPreProcessor<TRequest, TResponse>>)typeFactory(typeof(IEnumerable<IAsyncRequestPreProcessor<TRequest, TResponse>>)))
            {
                await action.Process((TRequest)request);
            }

            var response = await ((IAsyncRequestHandler<TRequest, TResponse>)typeFactory(typeof(IAsyncRequestHandler<TRequest, TResponse>))).Handle((TRequest)request);

            foreach (var action in (IEnumerable<IAsyncRequestPostProcessor<TRequest, TResponse>>)typeFactory(typeof(IEnumerable<IAsyncRequestPostProcessor<TRequest, TResponse>>)))
            {
                await action.Process((TRequest)request, response);
            }

            return response;
        }
    }
}
