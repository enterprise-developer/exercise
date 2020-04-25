using System.Threading.Tasks;
using TinyERP.LoggerManagement.Entities;

namespace TinyERP.LoggerManagement.Repositories
{
    public interface ILoggerRepository
    {
        void Create(Log log);
    }
}
