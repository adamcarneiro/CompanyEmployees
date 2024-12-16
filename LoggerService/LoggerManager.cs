using Contracts;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService {
    public class LoggerManager : ILoggerManager {

        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerManager() { }  
        void ILoggerManager.LogDebug(string message) {
            //throw new NotImplementedException();
            logger.Debug(message);
        }

        void ILoggerManager.LogError(string message) {
            //throw new NotImplementedException();
            logger.Error(message);
        }

        void ILoggerManager.LogInfo(string message) {
            //throw new NotImplementedException();
            logger.Info(message);
        }

        void ILoggerManager.LogWarn(string message) {
            //throw new NotImplementedException();
            logger.Warn(message);
        }
    }
}
