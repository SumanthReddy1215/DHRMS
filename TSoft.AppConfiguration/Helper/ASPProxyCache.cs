using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TSoft.AppConfiguration.Helper
{
    public class ASPProxyCache : IProxyCache
    {
        private static object getObject(string keyName)
        {
            // verify key in cache
            if (HttpContext.Current.Cache[keyName] == null) return null;

            // get object from cache
            return HttpContext.Current.Cache[keyName];
        }
        public T Get<T>(string keyName, Func<object> fun)
        {
            // get cache object
            var obj = getObject(keyName);
            if (obj != null) return (T)obj;

            // call function
            obj = fun();

            // set cache
            HttpContext.Current.Cache[keyName] = obj;
            return (T)obj;
        }

        public void Reset(string keyName)
        {
            if (HttpContext.Current.Cache[keyName] != null)
            {
                HttpContext.Current.Cache.Remove(keyName);
            }
        }

        public void ResetAll()
        {
            var item = HttpContext.Current.Cache.GetEnumerator();
            while (item.MoveNext())
            {
                HttpContext.Current.Cache.Remove(item.Key.ToString());
            }
        }
    }
}
