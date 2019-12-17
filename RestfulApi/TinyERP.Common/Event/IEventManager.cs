namespace TinyERP.Common.Event
{
    public interface IEventManager
    {
        void Publish<TEvent>(TEvent ev) where TEvent : IEvent;
    }
}
