namespace Simple.Mediator.Interfaces
{
    using System.Threading.Tasks;

    public interface IAsyncRequestPreProcessor<in TRequest, in TResponse> : IOrderedProcessor where TRequest : IRequest<TResponse>
    {
        Task Process(TRequest request);
    }
}
