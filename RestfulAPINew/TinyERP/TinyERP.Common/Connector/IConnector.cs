using System.Threading.Tasks;

namespace TinyERP.Common.Connector
{
    public interface IConnector
    {
        Task<TData> Post<TData>(string url, object value);

        Task<TData> Get<TData>(string url);
    }
}
