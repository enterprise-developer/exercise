using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using TinyERP.Common;
using TinyERP.Common.Configurations;
using TinyERP.Common.Connector;
using TinyERP.Common.Responses;
using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.UserManagement.Share.Facade
{
    public class RemoteUserFacade : IUserFacade
    {
        public int CreateIfNotExist(CreateAuthorDto createAuthor)
        {
            IConnector connector = ConnectorFactory.Create(ConnectorType.Json);
            string url = $"{ConfigurationApp.Instance.UserManagement.EndPoint.Url}/api/users";
            return connector.Post<int>(url, createAuthor);
        }
    }
}
