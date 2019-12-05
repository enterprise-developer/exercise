using log4net;

namespace TinyERP.Common.Logging
{
    public class FileLogger : ILogger
    {
        private log4net.ILog logger;
        public FileLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
            this.logger = LogManager.GetLogger(typeof(FileLogger));
        }
        public void Error(object obj)
        {
            this.logger.Error(obj);
        }
    }
}
