namespace TinyERP.Common.DI
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using System;
    using System.Collections.Generic;
    using TinyERP.Common.Contexts;

    internal class WindsorContainer : IBaseContainer
    {
        private IWindsorContainer container;
        public WindsorContainer()
        {
            this.container = new Castle.Windsor.WindsorContainer();
        }

        public void RegisterSingleton<IInterface, IImpl>(string name = "")
            where IInterface : class
            where IImpl : IInterface
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                this.container.Register(Component.For<IInterface>().ImplementedBy<IImpl>().LifestyleSingleton());
            }
            else
            {
                this.container.Register(Component.For<IInterface>().ImplementedBy<IImpl>().LifestyleSingleton().Named(name));
            }
        }

        public void RegisterTransient<IInterface, IImpl>(string name = "")
            where IInterface : class
            where IImpl : IInterface
        {
            if (string.IsNullOrEmpty(name))
            {
                this.container.Register(Component.For<IInterface>().ImplementedBy<IImpl>().LifestyleTransient());
            }
            else
            {
                this.container.Register(Component.For<IInterface>().ImplementedBy<IImpl>().LifestyleTransient().Named(name));
            }
        }

        public IInterface Resolve<IInterface>(IBaseContext context = null) where IInterface : class
        {
            if (context != null)
            {
                Castle.MicroKernel.Arguments arg = new Castle.MicroKernel.Arguments();
                arg.AddTyped(typeof(IBaseContext), context);
                arg.AddTyped(typeof(ContextMode), ContextMode.Write);
                return this.container.Resolve<IInterface>(arg);
            }
            return this.container.Resolve<IInterface>();
        }

        public object Resolve(Type type)
        {
            return this.container.Resolve(type);
        }

        public IList<object> ResolveAll(Type type)
        {
            IList<object> results = new List<object>();
            Array items = this.container.ResolveAll(type);
            foreach (object item in items)
            {
                results.Add(item);
            }
            return results;
        }
    }
}
