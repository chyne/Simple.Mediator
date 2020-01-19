namespace Simple.Mediator.Internal
{
    using System.Linq;
    using System.Threading.Tasks;
    using Core;
    using Interfaces;
    using Mediator.Interfaces;

    internal class AsyncRequestHandlerWrapper<TRequest, TResponse> : IAsyncRequestHandlerWrapper<TResponse> where TRequest : IRequest<TResponse>
    {

        public async Task<TResponse> Handle(IRequest<TResponse> request, TypeFactory typeFactory)
        {
            foreach (var action in typeFactory.GetInstances<IAsyncRequestPreProcessor<TRequest, TResponse>>().OrderBy(a => a.Order))
            {
                await action.Process((TRequest)request);
            }

            var response = await typeFactory.GetInstance<IAsyncRequestHandler<TRequest, TResponse>>().Handle((TRequest)request);

            foreach (var action in typeFactory.GetInstances<IAsyncRequestPostProcessor<TRequest, TResponse>>().OrderBy(a =>  a.Order))
            {
                await action.Process((TRequest)request, response);
            }

            return response;
        }
    }
}
