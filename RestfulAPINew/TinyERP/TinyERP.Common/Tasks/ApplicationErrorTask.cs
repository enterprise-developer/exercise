using System;
using TinyERP.Common.DI;
using TinyERP.Common.Logs;

namespace TinyERP.Common.Tasks
{
    public class ApplicationErrorTask : IApplicationErrorTask
    {
        public void Execute(object arg = null)
        {
            if (arg == null)
            {
                return;
            }

            ILogger logger = IoC.Resolve<ILogger>();
            Exception ex = arg as Exception;
            logger.Error(ex);
        }
    }
}
