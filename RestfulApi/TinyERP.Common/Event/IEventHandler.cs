namespace TinyERP.Common.Event
{
    public interface IEventHandler<TEvent> where TEvent: IEvent
    {
        void Handle(TEvent ev);
    }
}
