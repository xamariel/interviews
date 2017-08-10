using Newtonsoft.Json;
using System.Net;
using System.Web;

namespace Realmdigital_Interview.Services.JsonClient
{
    public class JsonClient : HttpContextBase, IJsonClient
    {
        public TResponse Get<TResponse>(string url)
        {
            try
            {
                string response = "";
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    response = client.DownloadString(url);
                    var reponseObject = JsonConvert.DeserializeObject<TResponse>(response);
                    return reponseObject;
                }
            }
            catch (System.Exception e)
            {
                //Implement exception logging service

                //create error response
                HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                HttpContext.Current.Response.StatusDescription = e.Message;

                return default(TResponse);
            }
        }

        public TResponse Post<TResponse>(string url, object parameters)
        {
            try
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
            catch (System.Exception e)
            {
                //Implement exception logging service

                //create error response
                HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                HttpContext.Current.Response.StatusDescription = e.Message;

                return default(TResponse);
            }
        }
    }
}