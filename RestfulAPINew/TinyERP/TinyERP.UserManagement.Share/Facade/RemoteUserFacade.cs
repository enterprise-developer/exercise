using System;
using System.Threading.Tasks;
using TinyERP.Common;
using TinyERP.Common.Configurations;
using TinyERP.Common.Connector;
using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.UserManagement.Share.Facade
{
    public class RemoteUserFacade : IUserFacade
    {
        public async Task<Guid> CreateIfNotExist(CreateAuthorDto createAuthor)
        {
            IConnector connector = ConnectorFactory.Create(ConnectorType.Json);
            string url = $"{ConfigurationApp.Instance.UserManagement.EndPoint.Url}/api/users";
            return await connector.Post<Guid>(url, createAuthor);
        }

        public async Task<AuthorInfo> GetAuthor(Guid id)
        {
            IConnector connector = ConnectorFactory.Create(ConnectorType.Json);
            string url = $"{ConfigurationApp.Instance.UserManagement.EndPoint.Url}/api/users/{id}/authorInfo";
            return await connector.Get<AuthorInfo>(url);
        }
    }
}
