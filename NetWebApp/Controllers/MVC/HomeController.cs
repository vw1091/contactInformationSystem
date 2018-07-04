using System.Web.Mvc;

namespace NetWebApp.Controllers.API
{
    public class HomeController : Controller
    {
        protected log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public ActionResult Index()
        {
            return View();
        }
    }
}
