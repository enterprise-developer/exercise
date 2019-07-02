namespace TinyERP.UserMangement.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using TinyERP.Common.Common.Validation;
    using TinyERP.Common.Data;
    using TinyERP.UserManagement.Share.Dto;
    using TinyERP.UserMangement.Aggregate;
    using TinyERP.UserMangement.Context;

    public class UserService: IUserService
    {
        public IList<User> GetUsers()
        {
            IUserDbContext context = DbContextFactory.Create<IUserDbContext>();
            return context.Users.ToList();
        }

        public User GetUser(int userId)
        {
            IUserDbContext context = DbContextFactory.Create<IUserDbContext>();
            return context.Users.FirstOrDefault(item => item.Id == userId);
        }

        public User CreateUser(CreateUserRequest request)
        {
            this.Validate(request);
            IUserDbContext context = DbContextFactory.Create<IUserDbContext>();
            User user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName
            };
            context.Users.Add(user);
            context.SaveChanges();

            return this.GetUser(user.Id);
        }

        private void Validate(CreateUserRequest request)
        {
            ValidationException validator = ValidationHelper.Validate(request, "common.invalid.request");
            if (request.UserName=="abc") {
                validator.Add(new ValidationError("addNewUser.userNameWasUsed", "user_name", request.UserName));
            }
            validator.ThrowIfError(); ;
        }
        public void UpdateUser(UpateUserRequest request)
        {
            IUserDbContext context = DbContextFactory.Create<IUserDbContext>();
            User user = context.Users.FirstOrDefault(item => item.Id == request.UserId);
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.UserName = request.UserName;
            context.SaveChanges();
        }

        public User GetUserByUserName(string userName)
        {
            IUserDbContext context = DbContextFactory.Create<IUserDbContext>();
            User user = context.Users.FirstOrDefault(item => item.UserName.ToLower() == userName.ToLower());
            return user;
        }
    }
}