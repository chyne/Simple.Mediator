namespace Simple.Mediator.Tests
{
    using Interface;

    public abstract class Sample
    {
        public class Request : IRequest<Response>
        {
            public string Value { get; set; }
        }

        public class Response
        {
            public string Value { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public Response Handle(Request request)
            {
                return new Response { Value = request.Value };
            }
        }
    }
}
