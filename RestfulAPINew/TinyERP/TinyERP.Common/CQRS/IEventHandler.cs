namespace TinyERP.Common.CQRS
{
    public interface IEventHandler<TEvent> where TEvent : IEvent
    {
        void Handle(TEvent ev);
    }
}
