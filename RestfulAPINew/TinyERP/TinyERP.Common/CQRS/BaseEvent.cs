using System;

namespace TinyERP.Common.CQRS
{
    public class BaseEvent : IEvent
    {
        public EventPriority Priority { get; private set; }
        public Type GetEventHandlerType
        {
            get
            {
                return typeof(IEventHandler<>).MakeGenericType(this.GetType());
            }
        }

        public BaseEvent(EventPriority priority = EventPriority.Normal)
        {
            this.Priority = priority;
        }

    }
}
