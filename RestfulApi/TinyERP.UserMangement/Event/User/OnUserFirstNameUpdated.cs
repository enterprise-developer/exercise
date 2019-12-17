namespace TinyERP.UserMangement.Event.User
{
    using TinyERP.Common;
    using TinyERP.Common.Event;
    public class OnUserFirstNameUpdated: BaseEvent
    {

        public OnUserFirstNameUpdated(string name):base((int)EventPriority.High){}
    }
}
