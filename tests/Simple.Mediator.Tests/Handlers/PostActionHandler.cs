namespace Simple.Mediator.Tests.Handlers
{
    using System.Threading.Tasks;
    using Interfaces;

    public static class PostActionHandler
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

        public class RequestRequestPostProcessor : IRequestPostProcessor<Request, Response>, IAsyncRequestPostProcessor<Request, Response>
        {
            public int Order => 1;
            void IRequestPostProcessor<Request, Response>.Process(Request request, Response response)
            {
                response.Value = nameof(RequestRequestPostProcessor);
            }

            Task IAsyncRequestPostProcessor<Request, Response>.Process(Request request, Response response)
            {
                response.Value = nameof(RequestRequestPostProcessor);
                return Task.CompletedTask;
            }
        }
    }
}
