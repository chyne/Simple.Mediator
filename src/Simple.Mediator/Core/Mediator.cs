namespace Simple.Mediator.Core
{
    using System;
    using Interface;
    using Internal;

    public class Mediator : IMediator
    {
        private readonly TypeFactory _typeFactory;

        public Mediator(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

        public TResponse Dispatch<TResponse>(IRequest<TResponse> request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var requestType = request.GetType();

            var handler = (IRequestHandlerWrapper<TResponse>)Activator.CreateInstance(typeof(RequestHandlerWrapper<,>).MakeGenericType(requestType, typeof(TResponse)));

            return handler.Handle(request, _typeFactory);
        }
    }
}
