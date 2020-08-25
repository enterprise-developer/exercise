using System;

namespace TinyERP.Common.CQRS
{
    public class BaseEvent: IEvent
    {
        public Type GetEventHandlerType
        {
            get
            {
                return typeof(IEventHandler<>).MakeGenericType(this.GetType());
            }
        }
    }
}
