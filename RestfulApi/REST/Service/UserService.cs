namespace REST.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using REST.Context;
    using REST.Entity;
    using TinyERP.Common.Common.Validation;

    public class UserService: IUserService
    {
        public IList<User> GetUsers()
        {
            RESTDbContext context = new RESTDbContext();
            return context.Users.ToList();
        }

        public User GetUser(int userId)
        {
            RESTDbContext context = new RESTDbContext();
            return context.Users.FirstOrDefault(item => item.Id == userId);
        }

        public User CreateUser(CreateUserRequest request)
        {
            this.Validate(request);
            RESTDbContext context = new RESTDbContext();
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
            RESTDbContext context = new RESTDbContext();
            User user = context.Users.FirstOrDefault(item => item.Id == request.UserId);
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.UserName = request.UserName;
            context.SaveChanges();
        }
    }
}