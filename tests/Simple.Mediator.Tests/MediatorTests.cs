namespace Simple.Mediator.Tests
{
    using Interface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MediatorTests : IoCSupportedTest<MediatorTestModule>
    {
        private IMediator _mediator;

        [TestInitialize]
        public void Initialize()
        {
            _mediator = Resolve<IMediator>();
        }

        [TestCleanup]
        public void CleanUp()
        {
            ShutdownIoC();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var request = new Sample.Request { Value = "Hello!" };

            var result = _mediator.Dispatch(request);

            Assert.AreEqual(request.Value, result.Value);
        }
    }
}
