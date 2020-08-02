using DHRM.WebHelper;
using System.Web.Mvc;
using DHRM.DataAccess;
using DHRM.BusinessEntity;

namespace DHRM.Controllers
{
    public class UserListController : BaseController
    {
        public ActionResult Index()
        {
            //SearchResultCriteria<UserInfo> entity = new SearchResultCriteria<UserInfo>();
            return View();
            //var searchResult = new UserContext().GetList(entity);
            //return PartialView("_UserList", searchResult);
        }
    }
}
