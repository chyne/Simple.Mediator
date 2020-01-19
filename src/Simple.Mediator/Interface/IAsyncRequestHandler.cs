namespace Simple.Mediator.Interface
{
    using System.Threading.Tasks;

    public interface IAsyncRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}