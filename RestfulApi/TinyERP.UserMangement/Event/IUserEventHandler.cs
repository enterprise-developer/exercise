namespace TinyERP.UserMangement.Event
{
    using TinyERP.Common.Event;
    using TinyERP.UserMangement.Event.User;

    internal interface IUserEventHandler: 
        IEventHandler<OnUserCreated>,
        IEventHandler<OnUserUpdated>
    {
    }
}
