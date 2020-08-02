using System;
using log4net;
using TSoft.AppConfiguration;

namespace DHRM.WebHelper
{
    public class AppLogger : ILogger
    {
        ILog _log;
        public AppLogger(string appName = "")
        {
            _log = log4net.LogManager.GetLogger(appName);
        }
        public void Debug(string message)
        {
            _log.Debug(message);
        }

        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Error(string message, Exception ex)
        {
            _log.Error(message, ex);
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public string LogError(string message)
        {
            string gui = Guid.NewGuid().ToString();
            message = string.Format("Reference: {0} Msg: {1}", gui, message);
            _log.Error(message);
            return gui;
        }

        public string LogError(string source, string message)
        {
            string gui = Guid.NewGuid().ToString();
            message = string.Format("Reference: {0} Msg: {1}", gui, message);
            var log = log4net.LogManager.GetLogger(source);
            log.Error(message);
            return gui;
        }

        public string LogError(string message, Exception ex)
        {
            string gui = Guid.NewGuid().ToString();
            message = string.Format("Reference: {0} Msg: {1}", gui, message);
            _log.Error(message, ex);
            return gui;
        }

        public string LogError(string source, string message, Exception ex)
        {
            string gui = Guid.NewGuid().ToString();
            message = string.Format("Reference: {0} Msg: {1}", gui, message);
            var log = log4net.LogManager.GetLogger(source);
            log.Error(message, ex);
            return gui;
        }
    }
}
