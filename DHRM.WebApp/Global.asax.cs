using System.Web.Mvc;
using System.Web.Routing;
using DHRM.WebHelper;
using System.Configuration;

namespace DHRM.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ViewEngines.Engines.Add(new HelperViewEngine());

            #region Application Settings

            ApplicationMapper.Load();
            GlobalSettings.Load();

            // grid global setting
            GlobalSettings.LoadGirdSettings(25, "No records found.");



            #region Email Settings

            string emailAttachementPath = ConfigurationManager.AppSettings["EMail:AttachmentPath"].ToString();
            string emailConnectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["DBConnectionName"]].ConnectionString;
            GlobalSettings.EmailNotificationSettings(emailAttachementPath, emailConnectionString);
            #endregion

            #endregion
        }
    }
}
