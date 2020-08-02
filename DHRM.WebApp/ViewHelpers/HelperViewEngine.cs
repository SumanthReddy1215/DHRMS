using System.Linq;
using System.Web.Mvc;

namespace DHRM.WebApp
{
    public class HelperViewEngine : RazorViewEngine
    {
        private static readonly string[] NewPartialViewFormats =
    {
        "~/Views/{1}/Partials/{0}.cshtml",
        "~/Views/Shared/Partials/{0}.cshtml"
    };

        public HelperViewEngine()
        {
            base.PartialViewLocationFormats = base.PartialViewLocationFormats.Union(NewPartialViewFormats).ToArray();
        }
    }
}