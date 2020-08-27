using System;

namespace TinyERP.Common.CQRS
{
    public interface IEvent
    {
        EventPriority Priority { get; }
        Type GetEventHandlerType { get; }
    }
}
