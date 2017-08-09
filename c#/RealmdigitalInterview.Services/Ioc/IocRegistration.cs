using RealmdigitalInterview.Core.Ioc;
using RealmdigitalInterview.Services.Product;

namespace RealmdigitalInterview.Services.Ioc
{
    public static class IocRegistration
    {
        public static void Register()
        {
            IocContainer.RegisterType<ProductService, IProductService>();
        }
    }
}
