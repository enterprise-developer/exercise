namespace TinyERP.UserMangement.Event.User
{
    using TinyERP.Common.Event;
    using TinyERP.UserMangement.Share;

    public class OnUserUpdated : BaseEvent
    {
        public IUser UserInfo { get; private set; }
        public OnUserUpdated(IUser user):base()
        {
            this.UserInfo = user;
        }
    }
}
