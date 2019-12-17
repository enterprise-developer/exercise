namespace TinyERP.UserMangement.Event.User
{
    using TinyERP.Common.Event;
    using TinyERP.UserMangement.Share;
    public class OnUserCreated: BaseEvent
    {
        public IUser UserInfo { get; private set; }
        public OnUserCreated(IUser user):base()
        {
            this.UserInfo = user;
        }
    }
}
