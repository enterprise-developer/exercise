namespace REST.Service
{
    using REST.Entity;
    using System.Collections.Generic;
    public interface IUserService
    {
        IList<User> GetUsers();
        User GetUser(int userId);
        User CreateUser(CreateUserRequest request);
        void UpdateUser(UpateUserRequest request);
    }
}