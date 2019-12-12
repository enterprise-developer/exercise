using TinyERP.Common.Common.IoC;
using TinyERP.UserManagement.Share.Dto;
using TinyERP.UserManagement.Share.Facade;
using TinyERP.UserMangement.Aggregate;
using TinyERP.UserMangement.Service;

namespace TinyERP.UserMangement.Share.Facade
{
    internal class UserManagementFacade : IUserManagementFacade
    {
        public int CreateUserIfNotExisted(CreateUserRequest createUserRequest)
        {
            IUserService service = IoC.Resolve<IUserService>();
            UserAggregateRoot user = service.GetUserByUserName(createUserRequest.UserName);
            if (user != null)
            {
                return user.Id;
            }
            user = service.CreateUser(createUserRequest);
            return user.Id;
        }
    }
}
