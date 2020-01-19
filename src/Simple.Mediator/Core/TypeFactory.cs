namespace Simple.Mediator.Core
{
    using System;
    using System.Collections.Generic;

    public delegate object TypeFactory(Type serviceType);

    public static class TypeFactoryExtensions
    {
        public static T GetInstance<T>(this TypeFactory factory)
        {
            return (T)factory(typeof(T));
        }

        public static IEnumerable<T> GetInstances<T>(this TypeFactory factory)
        {
            return (IEnumerable<T>)factory(typeof(IEnumerable<T>));
        }
    }
}
