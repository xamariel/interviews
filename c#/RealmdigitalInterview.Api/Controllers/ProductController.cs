using Microsoft.Web.Http;
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

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        [Route("search")]
        public HttpResponseMessage GetProductsByName(string name)
        {
            var result = _productService.GetProductsByName(name);
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
