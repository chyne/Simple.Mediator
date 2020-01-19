namespace Simple.Mediator.Tests.Utility
{
    using Autofac;
    using Autofac.Core;

    public abstract class DependencyInjectionSupportedTest<TModule> where TModule : IModule, new()
    {
        private readonly IContainer _container;

        protected DependencyInjectionSupportedTest()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new TModule());

            _container = builder.Build();
        }

        protected TEntity Resolve<TEntity>()
        {
            return _container.Resolve<TEntity>();
        }

        protected void CleanupDependencyInjection()
        {
            _container.Dispose();
        }
    }
}
