using Microsoft.Web.Http;
using RealmdigitalInterview.Api.CustomAttributes;
using RealmdigitalInterview.Filters;
using RealmdigitalInterview.Models;
using RealmdigitalInterview.Repos.Price;
using RealmdigitalInterview.Repos.Product;
using RealmdigitalInterview.Services.Product;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RealmdigitalInterview.Api.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/products/{productId}/prices")]
    [GeneralExceptionFilter]
    public class ProductPriceController : ApiController
    {
        private IProductService _productService;
        private IProductRepo _productRepo;
        private IPriceRepo _priceRepo;

        public ProductPriceController(IProductService productService, IProductRepo productRepo, IPriceRepo priceRepo)
        {
            _productService = productService;
            _productRepo = productRepo;
            _priceRepo = priceRepo;
        }
        
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get(int productId)
        {
            var result = _priceRepo.GetCollection(new PriceFilter {
                ProductId = productId
            });
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(PriceModel model)
        {
            var result = _priceRepo.Add(model);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

    }
}
