namespace TinyERP.UserMangement.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Common.Validation;
    using TinyERP.Common.Data;
    using TinyERP.Common.Data.UoW;
    using TinyERP.Common.Service;
    using TinyERP.UserManagement.Share.Dto;
    using TinyERP.UserMangement.Aggregate;
    using TinyERP.UserMangement.Context;
    using TinyERP.UserMangement.Repository;

    public class UserService : BaseService, IUserService
    {
        private IUserRepository userRepository;
        public UserService()
        {
            this.userRepository = IoC.Resolve<IUserRepository>();
        }
        public IList<User> GetUsers()
        {
            return userRepository.GetUsers();
        }

        public User GetUser(int userId)
        {
            return this.userRepository.GetUserDetail(userId);
        }

        public User CreateUser(CreateUserRequest request)
        {
            this.Validate(request);
            using (IUnitOfWork unitOfWork = this.CreateUnitOfWork<User>())
            {
                User user = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = request.UserName
                };
                IUserRepository userRepository = IoC.Resolve<IUserRepository>(unitOfWork);
                userRepository.Add(user);
                unitOfWork.Commit();
                return GetUser(user.Id);
            }
        }

        private void Validate(CreateUserRequest request)
        {
            ValidationException validator = ValidationHelper.Validate(request, "common.invalid.request");
            if (this.userRepository.GetUserByUserName(request.UserName) != null)
            {
                validator.Add(new ValidationError("addNewUser.userNameWasUsed", "user_name", request.UserName));
            }
            validator.ThrowIfError();
        }

        public void UpdateUser(UpateUserRequest request)
        {
            using (IUnitOfWork unitOfWork = this.CreateUnitOfWork<User>())
            {
                User user = this.userRepository.GetUserDetail(request.UserId);
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.UserName = request.UserName;
                IUserRepository userRepository = IoC.Resolve<IUserRepository>();
                userRepository.Update(user);
                unitOfWork.Commit();
            }
        }

        public User GetUserByUserName(string userName)
        {
            return this.userRepository.GetUserByUserName(userName);
        }
    }
}