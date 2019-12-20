﻿namespace TinyERP.Common.Event
{
    using System.Collections.Generic;
    using System.Reflection;
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Logging;

    internal class EventManager : IEventManager
    {
        public ILogger Logger { get; }
        public EventManager()
        {
            this.Logger = IoC.Resolve<ILogger>();
        }
        public void Publish<TEvent>(TEvent ev) where TEvent : IEvent
        {
            MethodInfo publishMethod = this.GetType().GetMethod("_Publish", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic);
            MethodInfo genericMethod = publishMethod.MakeGenericMethod(new[] { ev.GetType() });
            genericMethod.Invoke(this, new object[] { ev });
        }
        private void _Publish<TEvent>(TEvent ev) where TEvent: IEvent
        {
            IList<IEventHandler<TEvent>> handlers = IoC.ResolveAll<IEventHandler<TEvent>>();
            if (handlers==null || handlers.Count==0) { return; }
            foreach (IEventHandler<TEvent> handler in handlers) {
                try
                {
                    handler.Handle(ev);
                }
                catch (System.Exception ex)
                {
                    this.Logger.Error(ex);
                }
            }
        }
    }
}
