using DHRM.WebHelper;
using System.Web.Mvc;
using DHRM.DataAccess;

namespace DHRM.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            UserContext context = new UserContext();
            var userInfo = context.GetUserInfo(username, password);
            if (userInfo != null)
            {
                AppSessionManager.UserInformation = userInfo;
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewData["_errorMsg_"] = "Invalid Username / Password";
                return View("Index");
            }
        }
    }
}
