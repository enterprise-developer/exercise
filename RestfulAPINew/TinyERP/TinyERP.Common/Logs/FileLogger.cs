using log4net;
using log4net.Config;
using System;

namespace TinyERP.Common.Logs
{
    internal class FileLogger : ILogger
    {
        private ILog logger;
        public FileLogger()
        {
            XmlConfigurator.Configure();
            this.logger = LogManager.GetLogger(typeof(FileLogger));
        }
        public void Error(Exception ex)
        {
            this.logger.Error(ex.Message);
        }
    }
}
