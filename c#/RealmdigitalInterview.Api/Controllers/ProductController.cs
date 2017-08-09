using Microsoft.Web.Http;
using RealmdigitalInterview.Models;
using RealmdigitalInterview.Repos.Product;
using RealmdigitalInterview.Services.Product;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RealmdigitalInterview.Api.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/products")]
    public class ProductController : ApiController
    {
        private IProductService _productService;
        private IProductRepo _productRepo;

        public ProductController(IProductService productService, IProductRepo productRepo)
        {
            _productService = productService;
            _productRepo = productRepo;
        }
        
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(ProductModel model)
        {
            var result = _productRepo.Add(model);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("search")]
        public HttpResponseMessage GetProductsByName(string itemName)
        {
            var result = _productService.GetProductsByName(itemName);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetProducts()
        {
            var result = _productService.GetProducts();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetProductsById(int id) {

            var result = _productService.GetProductById(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
