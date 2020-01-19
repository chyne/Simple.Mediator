namespace Simple.Mediator.Interfaces
{
    public interface IRequestPreProcessor<in TRequest, in TResponse> : IOrderedProcessor where TRequest : IRequest<TResponse>
    {
        void Process(TRequest request);
    }
}
