using DHRM.WebHelper;
using System.Web.Mvc;
using DHRM.DataAccess;

namespace DHRM.Controllers
{
    public class DashboardController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}