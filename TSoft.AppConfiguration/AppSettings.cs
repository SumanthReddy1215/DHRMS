using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSoft.AppConfiguration
{
    public class AppSettings
    {
        public static ISessionManager SessionManager;
        public static IProxyCache ProxyCache;
        public static IPasswordService PasswordManager;
        public static IEmailService EmailService;
        public static ILogger LogManager;
    }
}
