using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TinyERP.Common.CQRS;
using TinyERP.Common.DI;

namespace TinyERP.Common.Helpers
{
    public static class EventHelper
    {
        public static void InvokeEventHandle(IList<IEvent> events)
        {
            events = events.OrderByDescending(item => item.Priority).ToList();
            foreach (IEvent eventItem in events)
            {
                IList<object> eventHandlers = IoC.ResolveAll(eventItem.GetEventHandlerType);

                foreach (object eventHandler in eventHandlers)
                {
                    Type eventHandlerType = eventHandler.GetType();
                    MethodInfo methodInfo = eventHandlerType.GetMethod("Handle", new Type[] { eventItem.GetType() });
                    methodInfo.Invoke(eventHandler, new object[] { eventItem });
                }
            }
        }
    }
}
