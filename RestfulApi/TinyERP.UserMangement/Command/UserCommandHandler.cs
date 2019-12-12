namespace TinyERP.UserMangement.Command
{
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Common.Validation;
    using TinyERP.Common.CQRS;
    using TinyERP.Common.Data.UoW;
    using TinyERP.UserManagement.Share.Dto;
    using TinyERP.UserMangement.Aggregate;
    using TinyERP.UserMangement.Repository;

    internal class UserCommandHandler : 
        BaseCommandHandler, 
        ICommandHandler<CreateUserRequest>,
        ICommandHandler<UpdateUserRequest>
    {
        public void Handle(CreateUserRequest command)
        {
            this.Validate(command);
            using (IUnitOfWork unitOfWork = this.CreateUnitOfWork<UserAggregateRoot>())
            {
                UserAggregateRoot user = new UserAggregateRoot(command);
                IUserRepository userRepository = IoC.Resolve<IUserRepository>(unitOfWork);
                userRepository.Add(user);
                unitOfWork.Commit();
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

        public void Handle(UpdateUserRequest command)
        {
            this.Validate(command);
            using (IUnitOfWork unitOfWork = this.CreateUnitOfWork<UserAggregateRoot>())
            {
                IUserRepository userRepository = IoC.Resolve<IUserRepository>(unitOfWork);
                UserAggregateRoot user = userRepository.GetUserDetail(command.UserId);
                user.Update(command);
                userRepository.Update(user);
                unitOfWork.Commit();
            }
        }
        private void Validate(UpdateUserRequest request)
        {
            ValidationException validator = ValidationHelper.Validate(request, "common.invalid.request");
            IUserRepository userRepository = IoC.Resolve<IUserRepository>();
            if (userRepository.GetUserByUserName(request.UserName, request.UserId) != null)
            {
                validator.Add(new ValidationError("updateUser.userNameWasUsed", "user_name", request.UserName));
            }
            validator.ThrowIfError();
        }

    }
}
