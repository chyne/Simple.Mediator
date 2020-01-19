namespace Simple.Mediator.Interfaces
{
    using System.Threading.Tasks;

    public interface IMediator
    {
        TResponse Dispatch<TResponse>(IRequest<TResponse> request);

        Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request);
    }
}
