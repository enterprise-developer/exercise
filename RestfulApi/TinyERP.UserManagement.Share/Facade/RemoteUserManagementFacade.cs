
using System.Configuration;
using System.Net.Http;
using TinyERP.Common.Common.Data;
using TinyERP.Common.Common.Helper;
using TinyERP.Common.Connector;
using TinyERP.UserManagement.Share.Dto;

namespace TinyERP.UserManagement.Share.Facade
{
    public class RemoteUserManagementFacade : IUserManagementFacade
    {
        public int CreateUserIfNotExisted(CreateUserRequest createUserRequest)
        {
            HttpClient client = new HttpClient();
            string userUrl = TinyERP.Common.Config.Configuration.Instance.UserManagement.ApiEndpoint; //ConfigurationManager.AppSettings["UserManagementUrl"];
            HttpResponseMessage response = client.PostAsync(userUrl + "/createIfNotExist",
                new JsonContent<CreateUserRequest>(createUserRequest)).Result;
            response.EnsureSuccessStatusCode();
            string result = response.Content.ReadAsStringAsync().Result;

            int userId = 0;

            ResponseData respondData = JsonHelper.ToObject<ResponseData>(result);
            userId = int.Parse(respondData.Data.ToString());
            return userId;
        }
    }
}
