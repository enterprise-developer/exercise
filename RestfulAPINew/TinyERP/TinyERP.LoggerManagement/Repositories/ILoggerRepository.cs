using System.Threading.Tasks;
using TinyERP.LoggerManagement.Entities;

namespace TinyERP.LoggerManagement.Repositories
{
    public interface ILoggerRepository
    {
        Log Create(Log log);
    }
}
