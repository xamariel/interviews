using System.Collections.Generic;
using Realmdigital_Interview.Services.JsonClient;
using System.Web.Mvc;
using Realmdigital_Interview.Global;
using Realmdigital_Interview.Models;

namespace Retiremate_Integration_Services.Controllers
{
    //I'm purposefully using an mvc controller here in order to demonstrate plain remote procedure calls that don't adhere to REST standards.
    //Check the code in the RealmdigitalInterview.Api project to see the apicontroller implementation.
    //All business logic now sits behind the api.
    //The Realmdigital Interview.Web project is now only concerned about doing RP calls to the api and getting the data back.
    //I also can't use POSTs for these calls, because the API adheres to REST standards, and thus I have to use GETs
    public class ProductController : Controller
    {
        private IJsonClient _jsonClient;

        public ProductController(IJsonClient jsonClient)
        {
            _jsonClient = jsonClient;
        }

        public ActionResult GetProductById(string productId)
        {
            var result = _jsonClient.Get<ApiResponseProduct>(ApiEndpoint.DefaultApi + "api/v1/products/" + productId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProductsByName(string productName)
        {
            var result = _jsonClient.Get<List<ApiResponseProduct>>(ApiEndpoint.DefaultApi + "api/v1/products/search?itemName=" + productName);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}