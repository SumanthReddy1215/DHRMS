using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSoft.AppConfiguration
{
    public interface ILogger
    {
        void Error(string message);
        void Error(string message,Exception ex);
        void Info(string message);
        void Debug(string message);
        string LogError(string message);
        string LogError(string message, Exception ex);
        string LogError(string source,string message);
        string LogError(string source, string message, Exception ex);
    }
}
