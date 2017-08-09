using Newtonsoft.Json;
using Realmdigital_Interview.Global;
using System.Net;

namespace Realmdigital_Interview.Services.JsonClient
{
    public class JsonClient : IJsonClient
    {
        public TResponse Get<TResponse>(string url)
        {
            string response = "";
            
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                response = client.DownloadString(url);
            }
            var reponseObject = JsonConvert.DeserializeObject<TResponse>(response);

            return reponseObject;
        }

        public TResponse Post<TResponse>(string url, object parameters)
        {
            string response = "";

            var jsonPars = JsonConvert.SerializeObject(parameters);

            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                response = client.UploadString(url, "POST", jsonPars);
            }
            var reponseObject = JsonConvert.DeserializeObject<TResponse>(response);

            return reponseObject;
        }
    }
}