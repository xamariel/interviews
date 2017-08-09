using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RealmdigitalInterview.Api.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/products")]
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id) {

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
