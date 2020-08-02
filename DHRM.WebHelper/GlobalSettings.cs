using TSoft.AppConfiguration;
using TSoft.AppConfiguration.Helper;
using DHRM.BusinessEntity;
using System;

namespace DHRM.WebHelper
{
    public class GlobalSettings
    {
        //public static IProxyCache ProcyCache { get; internal set; }
        //public static ISessionManager SessionManager { get; internal set; }
        public GlobalSettings()
        {
        }

        public static void LoadGirdSettings(int rowsPerPage, string noRecordsFoundText)
        {
            // grid pager
            SearchResultCriteria.RowsPerPageGlobal = rowsPerPage;
            SearchResultCriteria.NoRecordsFountTextGlobal = noRecordsFoundText;
        }

        public static void Load()
        {
            AppSettings.ProxyCache = new ASPProxyCache();
            AppSettings.SessionManager = new SessionManager();
            AppSettings.LogManager = new AppLogger("DHRM");

            // log4net 
            log4net.Config.XmlConfigurator.Configure();
            AppSettings.LogManager.Info("Application Started Successfully - " + DateTime.Now.ToString());


        }

        public static void EmailNotificationSettings(string attachmentPath, string connectinoString)
        {
            // configure email service
            var emailNotificationSettings =
                new EmailNotification.EmailServiceSettings(connectinoString);

            var attachmentsDirPath = attachmentPath;
            EmailNotification.Configuration.Register(emailNotificationSettings, attachmentsDirPath, autoStart: true);
        }
    }
}
