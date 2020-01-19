namespace Simple.Mediator.Tests.Utility
{
    using Autofac;
    using Core;
    using Interfaces;

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

            builder.RegisterAssemblyTypes(GetType().Assembly).AsClosedTypesOf(typeof(IRequestPreProcessor<,>));
            builder.RegisterAssemblyTypes(GetType().Assembly).AsClosedTypesOf(typeof(IAsyncRequestPreProcessor<,>));

            builder.RegisterAssemblyTypes(GetType().Assembly).AsClosedTypesOf(typeof(IRequestPostProcessor<,>));
            builder.RegisterAssemblyTypes(GetType().Assembly).AsClosedTypesOf(typeof(IAsyncRequestPostProcessor<,>));
        }
    }
}
