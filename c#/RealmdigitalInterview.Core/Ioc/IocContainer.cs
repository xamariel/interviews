using Autofac;

namespace RealmdigitalInterview.Core.Ioc
{
    public static class IocContainer
    {
        public static ContainerBuilder ContainerBuilder = new ContainerBuilder();
        public static IContainer Container;

        public static void RegisterInstance<Type>(object instance)
        {
            ContainerBuilder.RegisterInstance(instance).As<Type>();
        }

        public static void RegisterType<TImplementer, Type>()
        {
            ContainerBuilder.RegisterType<TImplementer>().As<Type>();
        }

        public static TService Resolve<TService>()
        {
            return Container.Resolve<TService>();
        }

        public static void Build() {
            if (Container == null)
                Container = ContainerBuilder.Build();
        }        
    }
}
