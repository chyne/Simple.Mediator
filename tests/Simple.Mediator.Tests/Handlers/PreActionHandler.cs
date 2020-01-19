namespace Simple.Mediator.Tests.Handlers
{
    using System.Threading.Tasks;
    using Interfaces;

    public static class PreActionHandler
    {
        public class Request : IRequest<Response>
        {
            public string Value { get; set; }
        }

        public class Response
        {
            public string Value { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>, IAsyncRequestHandler<Request, Response>
        {
            Response IRequestHandler<Request, Response>.Handle(Request request)
            {
                return new Response { Value = request.Value };
            }

            Task<Response> IAsyncRequestHandler<Request, Response>.Handle(Request request)
            {
                return Task.FromResult(new Response { Value = request.Value });
            }
        }

        public class RequestRequestPreProcessor : IRequestPreProcessor<Request, Response>, IAsyncRequestPreProcessor<Request, Response>
        {
            public int Order => 1;
            void IRequestPreProcessor<Request, Response>.Process(Request request)
            {
                request.Value = nameof(RequestRequestPreProcessor);
            }

            Task IAsyncRequestPreProcessor<Request, Response>.Process(Request request)
            {
                request.Value = nameof(RequestRequestPreProcessor);
                return Task.CompletedTask;
            }
        }
    }
}
