namespace TinyERP.Common.Logging
{
    public class FileLogger : ILogger
    {
        private log4net.ILog logger = log4net.LogManager.GetLogger("FileLogger");
        public void Error(object obj)
        {
            this.logger.Error(obj);
        }
    }
}
