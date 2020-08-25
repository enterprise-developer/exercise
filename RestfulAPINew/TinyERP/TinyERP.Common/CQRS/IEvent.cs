using System;

namespace TinyERP.Common.CQRS
{
    public interface IEvent
    {
        Type GetEventHandlerType { get; }
    }
}
