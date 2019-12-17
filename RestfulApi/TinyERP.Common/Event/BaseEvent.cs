namespace TinyERP.Common.Event
{
    public abstract class BaseEvent : IEvent
    {
        public int Order { get; private set; }
        public BaseEvent(int order=(int) EventPriority.Normal)
        {
            this.Order = order;
        }
    }
}
