namespace Simple.Mediator.Tests.Basic
{
    using System.Threading.Tasks;
    using Interface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Sample;
    using Utility;

    [TestClass]
    public class BasicTests : DependencyInjectionSupportedTest<MediatorTestModule>
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
            var request = new Sample.Request { Value = "Hello!" };

            var result = _mediator.Dispatch(request);

            Assert.AreEqual(request.Value, result.Value);
        }

        [TestMethod]
        public async Task BasicAsyncTest()
        {
            var request = new Sample.Request { Value = "Async Hello!" };

            var result =  await _mediator.DispatchAsync(request);

            Assert.AreEqual(request.Value, result.Value);
        }
    }
}
