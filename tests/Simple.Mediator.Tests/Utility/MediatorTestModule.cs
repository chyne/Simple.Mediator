namespace Simple.Mediator.Tests.Utility
{
    using Autofac;
    using Core;
    using Interface;

    public class MediatorTestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            builder.Register<TypeFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterAssemblyTypes(GetType().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(GetType().Assembly).AsClosedTypesOf(typeof(IAsyncRequestHandler<,>));
        }
    }
}
