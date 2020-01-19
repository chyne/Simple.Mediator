namespace Simple.Mediator.Internal.Interfaces
{
    using Core;
    using Mediator.Interfaces;

    internal interface IRequestHandlerWrapper<TResponse>
    {
        TResponse Handle(IRequest<TResponse> request, TypeFactory typeFactory);
    }
}