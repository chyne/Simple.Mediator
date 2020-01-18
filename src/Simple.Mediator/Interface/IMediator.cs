namespace Simple.Mediator.Interface
{
    public interface IMediator
    {
        TResponse Dispatch<TResponse>(IRequest<TResponse> request);
    }
}
