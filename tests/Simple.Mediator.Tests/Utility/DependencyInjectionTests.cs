using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simple.Mediator.Tests.Utility
{
    using Autofac.Builder;
    using Core;
    using Interface;
    using Sample;

    [TestClass]
    public class DependencyInjectionTests
    {
        private readonly IContainer _container;

        public DependencyInjectionTests()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<MediatorTestModule>();

            _container = containerBuilder.Build(ContainerBuildOptions.IgnoreStartableComponents);
        }

        [TestMethod]
        public void MediatorIsRegistered()
        {
            Assert.IsTrue(_container.IsRegistered<IMediator>());
            Assert.IsInstanceOfType(_container.Resolve<IMediator>(), typeof(Mediator));
        }

        [TestMethod]
        public void TypeFactoryIsRegistered()
        {
            Assert.IsTrue(_container.IsRegistered<TypeFactory>());
            Assert.IsNotNull(_container.Resolve<TypeFactory>());
        }

        [TestMethod]
        public void SampleHandlerIsRegistered()
        {
            Assert.IsTrue(_container.IsRegistered<IRequestHandler<Sample.Request, Sample.Response>>());
            Assert.IsInstanceOfType(_container.Resolve<IRequestHandler<Sample.Request, Sample.Response>>(), typeof(Sample.Handler));
            Assert.IsTrue(_container.IsRegistered<IAsyncRequestHandler<Sample.Request, Sample.Response>>());
            Assert.IsInstanceOfType(_container.Resolve<IAsyncRequestHandler<Sample.Request, Sample.Response>>(), typeof(Sample.Handler));
        }
    }
}
