using System.Web.Mvc;

namespace DHRM.Controllers
{
    public class AlertController : Controller
    {
        public ActionResult FailAuthentication()
        {
            return View();
        }
        public ActionResult InActiveAuthentication()
        {
            return View();
        }
        public ActionResult Error404()
        {
            return View();
        }
        public ActionResult Error500()
        {
            return View();
        }
    }
}
