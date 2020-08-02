using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TSoft.AppConfiguration.Helper
{
    public class SessionManager : ISessionManager
    {
        public void Clear()
        {
            HttpContext.Current.Session.Clear();
        }

        public T Get<T>(string sessionName)
        {
            return (T)HttpContext.Current.Session[sessionName];
        }

        public void RemoveAll()
        {
            HttpContext.Current.Session.RemoveAll();
        }

        public void Remove(string sessionName)
        {
            HttpContext.Current.Session.Remove(sessionName);
        }

        public void Set(string sessionName, object entity)
        {
            HttpContext.Current.Session[sessionName] = entity;
        }
    }
}
