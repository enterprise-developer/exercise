namespace TinyERP.UserMangement.Command
{
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.CQRS;
    using TinyERP.Common.Data.UoW;
    using TinyERP.Common.Event;
    using TinyERP.UserManagement.Share.Dto;
    using TinyERP.UserMangement.Aggregate;
    using TinyERP.UserMangement.Event.User;
    using TinyERP.UserMangement.Repository;

    internal class UserCommandHandler : 
        BaseCommandHandler, 
        ICommandHandler<CreateUserRequest>,
        ICommandHandler<UpdateUserRequest>
    {
        public void Handle(CreateUserRequest command)
        {
            using (IUnitOfWork unitOfWork = this.CreateUnitOfWork<UserAggregateRoot>())
            {
                UserAggregateRoot user = new UserAggregateRoot(command);
                IUserRepository userRepository = IoC.Resolve<IUserRepository>(unitOfWork);
                userRepository.Add(user);
                unitOfWork.Commit();
                OnUserCreated ev = new OnUserCreated(user);
                IEventManager eventManager = IoC.Resolve<IEventManager>();
                eventManager.Publish(ev);
            }
        }

        public void Handle(UpdateUserRequest command)
        {
            using (IUnitOfWork unitOfWork = this.CreateUnitOfWork<UserAggregateRoot>())
            {
                IUserRepository userRepository = IoC.Resolve<IUserRepository>(unitOfWork);
                UserAggregateRoot user = userRepository.GetUserDetail(command.UserId);
                user.Update(command);
                userRepository.Update(user);
                unitOfWork.Commit();
                user.PublishEvents();
                
            }
        }
    }
}
