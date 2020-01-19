namespace Simple.Mediator.Interfaces
{
    using System.Threading.Tasks;

    public interface IAsyncRequestPostProcessor<in TRequest, in TResponse> where TRequest : IRequest<TResponse>
    {
        Task Process(TRequest request, TResponse response);
    }
}
