using TSoft.AppConfiguration;
using DHRM.BusinessEntity;

namespace DHRM.WebHelper
{
    public class AppSessionManager
    {
        public static UserInfoEntity UserInformation
        {
            get
            {
                return AppSettings.SessionManager.Get<UserInfoEntity>("_UserInfo_");
            }
            set
            {
                AppSettings.SessionManager.Set("_UserInfo_", value);
            }
        }
    }
}
