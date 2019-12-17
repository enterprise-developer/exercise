namespace TinyERP.UserMangement.Event
{
    using TinyERP.Common.Event;
    using TinyERP.UserMangement.Event.User;
    internal class UserEventHandler : 
        IEventHandler<OnUserCreated>, 
        IEventHandler<OnUserUpdated>
    {
        public void Handle(OnUserCreated ev)
        {
            // update read data
        }

        public void Handle(OnUserUpdated ev)
        {
            // update read data
        }
    }
}
