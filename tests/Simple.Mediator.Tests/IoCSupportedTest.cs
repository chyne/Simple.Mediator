namespace Simple.Mediator.Tests
{
    using Autofac;
    using Autofac.Core;

    public class IoCSupportedTest<TModule> where TModule : IModule, new()
    {
        private readonly IContainer _container;

        protected IoCSupportedTest()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new TModule());

            _container = builder.Build();
        }

        protected TEntity Resolve<TEntity>()
        {
            return _container.Resolve<TEntity>();
        }

        protected void ShutdownIoC()
        {
            _container.Dispose();
        }
    }
}
