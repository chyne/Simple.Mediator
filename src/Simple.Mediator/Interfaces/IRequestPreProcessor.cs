namespace Simple.Mediator.Interfaces
{
    public interface IRequestPreProcessor<in TRequest, in TResponse> where TRequest : IRequest<TResponse>
    {
        int Order { get; }
        void Process(TRequest request);
    }
}
