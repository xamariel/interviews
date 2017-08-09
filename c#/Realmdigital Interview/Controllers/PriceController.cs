using System.Collections.Generic;
using Realmdigital_Interview.Services.JsonClient;
using System.Web.Mvc;
using Realmdigital_Interview.Global;
using Realmdigital_Interview.Models;

namespace Retiremate_Integration_Services.Controllers
{
    public class PriceController : Controller
    {
        private IJsonClient _jsonClient;

        public PriceController(IJsonClient jsonClient)
        {
            _jsonClient = jsonClient;
        }
        
        public ActionResult AddPriceToProduct(ApiRequestPrice price)
        {
            var model = _jsonClient.Post<ApiResponsePrice>(ApiEndpoint.DefaultApi + "api/v1/products/" + price.ProductId + "/prices", price);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        
    }
}