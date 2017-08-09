using RealmdigitalInterview.Core.Implementations;
using RealmdigitalInterview.Core.Interfaces;
using RealmdigitalInterview.Core.Ioc;
using RealmdigitalInterview.Repos.Price;
using RealmdigitalInterview.Repos.Product;

namespace RealmdigitalInterview.Repos.Ioc
{
    public static class IocRegistration
    {
        public static void Register()
        {

            IocContainer.RegisterType<Connection, IConnection>();
            IocContainer.RegisterType<SqlRepo, IRepoService>();

            IocContainer.RegisterType<ProductRepo, IProductRepo>();
            //IocContainer.Register<PriceRepo, IPriceRepo>();
        }
    }
}
