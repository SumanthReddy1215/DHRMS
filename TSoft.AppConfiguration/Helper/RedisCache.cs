using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSoft.AppConfiguration.Helper
{
    public class RedisCache : IProxyCache
    {
        public T Get<T>(string keyName, Func<object> fun)
        {
            throw new NotImplementedException();
        }

        public void Reset(string keyName)
        {
            throw new NotImplementedException();
        }

        public void ResetAll()
        {
            throw new NotImplementedException();
        }
    }
}
