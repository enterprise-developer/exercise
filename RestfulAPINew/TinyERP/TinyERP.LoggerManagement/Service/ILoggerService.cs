using System;
using System.Threading.Tasks;

namespace TinyERP.LoggerManagement.Service
{
    public interface ILoggerService
    {
        void Create(Exception ex);
    }
}
