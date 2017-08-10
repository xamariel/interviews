using System.Web;

namespace Realmdigital_Interview.Services.JsonClient
{
    public interface IJsonClient
    {
        TResponse Get<TResponse>(string url);
        TResponse Post<TResponse>(string url, object parameters);
    }
}