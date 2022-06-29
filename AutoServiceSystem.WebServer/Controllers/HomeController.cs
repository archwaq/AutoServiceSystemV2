using System.Web.Mvc;

namespace AutoServiceSystem.WebServer.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Home/Index")]
        public ActionResult IndexRouteRedirector()
        {
            return RedirectToAction("Index");
        }
    }
}