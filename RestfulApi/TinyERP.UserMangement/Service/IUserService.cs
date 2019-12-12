namespace TinyERP.UserMangement.Service
{
    using System.Collections.Generic;
    using TinyERP.UserManagement.Share.Dto;
    using TinyERP.UserMangement.Aggregate;

    public interface IUserService
    {
        IList<UserAggregateRoot> GetUsers();
        UserAggregateRoot GetUser(int userId);
        UserAggregateRoot CreateUser(CreateUserRequest request);
        void UpdateUser(UpateUserRequest request);
        UserAggregateRoot GetUserByUserName(string userName);
    }
}