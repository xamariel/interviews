using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace RealmdigitalInterview.Api.CustomAttributes
{
    public class GeneralExceptionFilter : ExceptionFilterAttribute
    {
        //implement a very basic exception handler
        public override void OnException(HttpActionExecutedContext context)
        {            
            context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, context.Exception.Message.ToString());            
        }
    }
}