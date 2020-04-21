using System;

namespace TinyERP.Common.Logs
{
    public interface ILogger
    {
        void Error(Exception ex);
    }
}
