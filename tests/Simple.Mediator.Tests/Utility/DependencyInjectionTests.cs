namespace Simple.Mediator.Tests.Utility
{
    using Autofac;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Autofac.Builder;
    using Core;
    using Handlers;
    using Interfaces;

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
        public void BasicHandlerIsRegistered()
        {
            Assert.IsTrue(_container.IsRegistered<IRequestHandler<BasicHandler.Request, BasicHandler.Response>>());
            Assert.IsInstanceOfType(_container.Resolve<IRequestHandler<BasicHandler.Request, BasicHandler.Response>>(), typeof(BasicHandler.Handler));
            Assert.IsTrue(_container.IsRegistered<IAsyncRequestHandler<BasicHandler.Request, BasicHandler.Response>>());
            Assert.IsInstanceOfType(_container.Resolve<IAsyncRequestHandler<BasicHandler.Request, BasicHandler.Response>>(), typeof(BasicHandler.Handler));
        }

        [TestMethod]
        public void PreActionHandlerIsRegistered()
        {
            Assert.IsTrue(_container.IsRegistered<IRequestHandler<PreActionHandler.Request, PreActionHandler.Response>>());
            Assert.IsInstanceOfType(_container.Resolve<IRequestHandler<PreActionHandler.Request, PreActionHandler.Response>>(), typeof(PreActionHandler.Handler));

            Assert.IsTrue(_container.IsRegistered<IAsyncRequestHandler<PreActionHandler.Request, PreActionHandler.Response>>());
            Assert.IsInstanceOfType(_container.Resolve<IAsyncRequestHandler<PreActionHandler.Request, PreActionHandler.Response>>(), typeof(PreActionHandler.Handler));

            Assert.IsTrue(_container.IsRegistered<IRequestPreProcessor<PreActionHandler.Request, PreActionHandler.Response>>());
            Assert.IsInstanceOfType(_container.Resolve<IRequestPreProcessor<PreActionHandler.Request, PreActionHandler.Response>>(), typeof(PreActionHandler.RequestRequestPreProcessor));

            Assert.IsTrue(_container.IsRegistered<IAsyncRequestPreProcessor<PreActionHandler.Request, PreActionHandler.Response>>());
            Assert.IsInstanceOfType(_container.Resolve<IAsyncRequestPreProcessor<PreActionHandler.Request, PreActionHandler.Response>>(), typeof(PreActionHandler.RequestRequestPreProcessor));
        }

        [TestMethod]
        public void PostActionHandlerIsRegistered()
        {
            Assert.IsTrue(_container.IsRegistered<IRequestHandler<PostActionHandler.Request, PostActionHandler.Response>>());
            Assert.IsInstanceOfType(_container.Resolve<IRequestHandler<PostActionHandler.Request, PostActionHandler.Response>>(), typeof(PostActionHandler.Handler));

            Assert.IsTrue(_container.IsRegistered<IAsyncRequestHandler<PostActionHandler.Request, PostActionHandler.Response>>());
            Assert.IsInstanceOfType(_container.Resolve<IAsyncRequestHandler<PostActionHandler.Request, PostActionHandler.Response>>(), typeof(PostActionHandler.Handler));

            Assert.IsTrue(_container.IsRegistered<IRequestPostProcessor<PostActionHandler.Request, PostActionHandler.Response>>());
            Assert.IsInstanceOfType(_container.Resolve<IRequestPostProcessor<PostActionHandler.Request, PostActionHandler.Response>>(), typeof(PostActionHandler.RequestRequestPostProcessor));

            Assert.IsTrue(_container.IsRegistered<IAsyncRequestPostProcessor<PostActionHandler.Request, PostActionHandler.Response>>());
            Assert.IsInstanceOfType(_container.Resolve<IAsyncRequestPostProcessor<PostActionHandler.Request, PostActionHandler.Response>>(), typeof(PostActionHandler.RequestRequestPostProcessor));
        }
    }
}
