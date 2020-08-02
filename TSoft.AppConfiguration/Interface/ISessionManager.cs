using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSoft.AppConfiguration
{
    public interface ISessionManager
    {
        T Get<T>(string sessionName);
        void Set(string sessionName, object entity);

        void Clear();
        void RemoveAll();
        void Remove(string sessionName);
    }
}
