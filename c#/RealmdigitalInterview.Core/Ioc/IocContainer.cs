using Autofac;

namespace RealmdigitalInterview.Core.Ioc
{
    public static class IocContainer
    {
        private static ContainerBuilder containerBuilder = new ContainerBuilder();
        private static IContainer container;

        public static void RegisterInstance<Type>(object instance)
        {
            containerBuilder.RegisterInstance(instance).As<Type>();
        }

        public static void RegisterType<TImplementer, Type>()
        {
            containerBuilder.RegisterType<TImplementer>().As<Type>();
        }

        public static TService Resolve<TService>()
        {
            return container.Resolve<TService>();
        }

        public static void Build() {
            container = containerBuilder.Build();
        }

        public static int MultiplyBy(this int value, int mulitiplier)
        {
            // Uses a second parameter after the instance parameter.
            return value * mulitiplier;
        }
    }
}
