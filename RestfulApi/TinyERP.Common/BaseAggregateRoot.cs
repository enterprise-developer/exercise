namespace TinyERP.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Event;
    public abstract class BaseAggregateRoot
    {
        public IList<IEvent> Events { get; private set; }
        public BaseAggregateRoot()
        {
            this.Events = new List<IEvent>();
        }
        public void AddEvent<TEvent>(TEvent ev) where TEvent : IEvent
        {
            this.Events.Add(ev);
        }
        public void PublishEvents() {
            IEventManager eventManager = IoC.Resolve<IEventManager>();
            //  OnuserCreated=> high
            // OnuserUpdatedFirst=> normal
            // OnuserUpdatedLast=> normal
            // OnuserUpdatedUser=> normal
            // OnuserUpdatedUser....100=> normal

            foreach (IEvent ev in this.Events.OrderByDescending(item => item.Order).ToList()) {
                eventManager.Publish(ev);
            }
        }
    }
}
