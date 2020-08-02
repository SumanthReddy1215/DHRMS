using System.IO;
using System.Web;

namespace DHRM.Controllers
{
    public static class TemplateFiles
    {
        static string rootPath = HttpContext.Current.Server.MapPath(@"~\Templates\");
        static string emailPath = Path.Combine(rootPath, @"EmailTemplates\");
        public static class Email
        {
            public static string DYNAMICACCESSCODE = emailPath + "DynamicAccessCode.html";
        }
    }

    public class TemplateManager
    {
        public static string GetTemplate(string templateName)
        {
            return File.ReadAllText(templateName);
        }
    }
}
