namespace Simple.Mediator.Internal
{
    using Core;
    using Interface;

    internal interface IRequestHandlerWrapper<TResponse>
    {
        TResponse Handle(IRequest<TResponse> request, TypeFactory typeFactory);
    }
}