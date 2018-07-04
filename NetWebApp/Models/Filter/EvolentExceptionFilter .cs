using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace NetWebApp.App_Start.Filter
{
    public class EvolentExceptionFilter : ExceptionFilterAttribute
    {
        protected log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnException(HttpActionExecutedContext context)
        {
            log.Error(context.Exception);
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}