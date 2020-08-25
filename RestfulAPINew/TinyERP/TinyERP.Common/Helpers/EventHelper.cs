using System;
using System.Collections.Generic;
using System.Reflection;
using TinyERP.Common.CQRS;
using TinyERP.Common.DI;

namespace TinyERP.Common.Helpers
{
    public static class EventHelper
    {
        public static void InvokeEventHandle(IList<IEvent> events)
        {
            foreach (IEvent eventItem in events)
            {
                object eventHandler = IoC.Resolve(eventItem.GetEventHandlerType);
                Type eventHandlerType = eventHandler.GetType();
                MethodInfo methodInfo = eventHandlerType.GetMethod("Handle", new Type[] { eventItem.GetType() });
                methodInfo.Invoke(eventHandler, new object[] { eventItem });
            }
        }
    }
}
