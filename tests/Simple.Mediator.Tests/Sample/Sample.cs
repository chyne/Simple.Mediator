namespace Simple.Mediator.Tests.Sample
{
    using System.Threading.Tasks;
    using Interface;

    public static class Sample
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
    }
}
