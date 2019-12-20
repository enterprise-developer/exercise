namespace TinyERP.UserMangement.Aggregate
{
    using TinyERP.Common;
    using TinyERP.Common.Attribute;
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Common.Validation;
    using TinyERP.UserManagement.Share.Dto;
    using TinyERP.UserMangement.Context;
    using TinyERP.UserMangement.Event.User;
    using TinyERP.UserMangement.Repository;
    using TinyERP.UserMangement.Share;
    [DbContext(Use = typeof(IUserDbContext))]
    public class UserAggregateRoot: BaseAggregateRoot, IUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public UserStatus Status { get; set; }
        // EF
        public UserAggregateRoot(){}

        public UserAggregateRoot(CreateUserRequest command)
        {
            this.Validate(command);
            this.FirstName = command.FirstName;
            this.LastName = command.LastName;
            this.UserName = command.UserName;
            this.AddEvent(new OnUserCreated(this));
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

        internal void Update(UpdateUserRequest command)
        {
            this.Validate(command);

            this.FirstName = command.FirstName;
            this.AddEvent(new OnUserFirstNameUpdated(this.FirstName));
            this.LastName = command.LastName;
            this.UserName = command.UserName;
            this.AddEvent(new OnUserUpdated(this));
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