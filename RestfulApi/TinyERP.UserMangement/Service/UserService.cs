namespace TinyERP.UserMangement.Service
{
    using System;
    using System.Collections.Generic;
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Common.Validation;
    using TinyERP.Common.Data.UoW;
    using TinyERP.Common.Service;
    using TinyERP.UserManagement.Share.Dto;
    using TinyERP.UserMangement.Aggregate;
    using TinyERP.UserMangement.Repository;

    public class UserService : BaseService, IUserService
    {
        public IList<UserAggregateRoot> GetUsers()
        {
            try
            {
                IUserRepository userRepository = IoC.Resolve<IUserRepository>();
                return userRepository.GetUsers();
            }
            catch (Exception ex) {
                throw new Exception("ldgjsldgjsldgjskld");
            }
        }

        public UserAggregateRoot GetUser(int userId)
        {
            IUserRepository userRepository = IoC.Resolve<IUserRepository>();
            return userRepository.GetUserDetail(userId);
        }

        public UserAggregateRoot CreateUser(CreateUserRequest request)
        {
            this.Validate(request);
            using (IUnitOfWork unitOfWork = this.CreateUnitOfWork<UserAggregateRoot>())
            {
                UserAggregateRoot user = new UserAggregateRoot()
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
            IUserRepository userRepository = IoC.Resolve<IUserRepository>();
            if (userRepository.GetUserByUserName(request.UserName) != null)
            {
                validator.Add(new ValidationError("addNewUser.userNameWasUsed", "user_name", request.UserName));
            }
            validator.ThrowIfError();
        }

        public void UpdateUser(UpateUserRequest request)
        {
            using (IUnitOfWork unitOfWork = this.CreateUnitOfWork<UserAggregateRoot>())
            {
                IUserRepository userRepository = IoC.Resolve<IUserRepository>(unitOfWork);
                UserAggregateRoot user = userRepository.GetUserDetail(request.UserId);
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.UserName = request.UserName;               
                userRepository.Update(user);
                unitOfWork.Commit();
            }
        }

        public UserAggregateRoot GetUserByUserName(string userName)
        {
            IUserRepository userRepository = IoC.Resolve<IUserRepository>();
            return userRepository.GetUserByUserName(userName);
        }
    }
}