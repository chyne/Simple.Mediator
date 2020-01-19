namespace Simple.Mediator.Interfaces
{
    public interface IRequestPostProcessor<in TRequest, in TResponse> : IOrderedProcessor where TRequest : IRequest<TResponse>
    {
        void Process(TRequest request, TResponse response);
    }

    public interface IOrderedProcessor
    {
        int Order { get; }
    }
}
