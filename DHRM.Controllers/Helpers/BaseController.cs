using DHRM.WebHelper;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DHRM.Controllers
{
    public class BaseController : Controller
    {
        protected string SourceUrl
        {
            get { return Request.UrlReferrer == null ? Url.Action("Index", "Dashboard") : Request.UrlReferrer.AbsoluteUri; }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {


            if (AppSessionManager.UserInformation == null)
            {
                if (HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new HttpUnauthorizedResult("Unauthorized / Your session has been logout.");
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Alert/FailAuthentication");
                }
            }
            else if (AppSessionManager.UserInformation.MEM_IsActive == false)
            {
                filterContext.Result = new RedirectResult("~/Alert/InActiveAuthentication");
            }
            else
            {
                ViewData["_UserInfo"] = AppSessionManager.UserInformation;
                ViewBag.SourceUrl = SourceUrl;
                base.OnActionExecuting(filterContext);
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (HttpContext.Request.IsAjaxRequest())
            {
                Response.ContentType = "application/json";
                Response.StatusCode = 500;
                Response.Write(
                    new JavaScriptSerializer().Serialize(
                        new
                        {
                            isAjaxError = true,
                            exception = new
                            {
                                message = filterContext.Exception.Message,
                                innerException = filterContext.Exception.InnerException,
                                stackTrace = filterContext.Exception.StackTrace
                            }
                        }
                    )
                );
                Response.End();
            }
            else
            {
                base.OnException(filterContext);
            }

            //filterContext.ExceptionHandled = true;
        }
    }
}
