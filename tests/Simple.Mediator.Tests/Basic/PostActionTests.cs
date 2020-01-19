namespace Simple.Mediator.Tests.Basic
{
    using System.Threading.Tasks;
    using Handlers;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Utility;

    [TestClass]
    public class PostActionTests : DependencyInjectionSupportedTest<MediatorTestModule>
    {
        private IMediator _mediator;

        [TestInitialize]
        public void Initialize()
        {
            _mediator = Resolve<IMediator>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            CleanupDependencyInjection();
        }

        [TestMethod]
        public void BasicTest()
        {
            var request = new PostActionHandler.Request { Value = "Hello!" };

            var result = _mediator.Dispatch(request);

            Assert.AreEqual(nameof(PostActionHandler.RequestRequestPostProcessor), result.Value);
        }

        [TestMethod]
        public async Task BasicAsyncTest()
        {
            var request = new PostActionHandler.Request { Value = "Async Hello!" };

            var result = await _mediator.DispatchAsync(request);

            Assert.AreEqual(nameof(PostActionHandler.RequestRequestPostProcessor), result.Value);
        }
    }
}
