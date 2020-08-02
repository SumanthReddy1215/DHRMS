using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSoft.AppConfiguration
{
    public interface IEmailService
    {
        void Send(IEmail entity);
        void SendAsyn(IEmail entity);
    }
}
