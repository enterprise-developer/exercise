namespace TinyERP.UserMangement.Command
{
    using TinyERP.Common.CQRS;
    using TinyERP.UserManagement.Share.Dto;
    internal interface IUserCommandHandler: 
        ICommandHandler<CreateUserRequest>,
        ICommandHandler<UpdateUserRequest>
    {
    }
}
