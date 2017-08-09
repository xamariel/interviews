using Realmdigital_Interview.Services.JsonClient;
using RealmdigitalInterview.Core.Ioc;

namespace Realmdigital_Interview
{
    public static class IocRegistration
    {
        public static void Register()
        {
            IocContainer.RegisterType<JsonClient, IJsonClient>();
        }
    }
}