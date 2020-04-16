using Castle.Core.Logging;
using log4net;
using System;

namespace TinyERP.Common.Tasks
{
    public class ApplicationErrorTask : IApplicationErrorTask
    {

        static readonly ILog log = LogManager.GetLogger(typeof(ApplicationErrorTask));
        public void Execute(object arg = null)
        {
            if (arg == null)
            {
                return;
            }

            Exception ex = arg as Exception;
            log.Error($"message: {ex.Message} \n stack trace: {ex.StackTrace}");
        }
    }
}
