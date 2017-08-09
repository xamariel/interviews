using Microsoft.Web.Http;
using RealmdigitalInterview.Repos.Product;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RealmdigitalInterview.Api.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/products")]
    public class ProductController : ApiController
    {
        private IProductRepo _productRepo; 

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id) {

            var result = _productRepo.GetCollection();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
