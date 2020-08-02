using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSoft.AppConfiguration
{
    public interface IProxyCache
    {
        T Get<T>(string keyName, Func<object> fun);
        void Reset(string keyName);
        void ResetAll();
    }
}
