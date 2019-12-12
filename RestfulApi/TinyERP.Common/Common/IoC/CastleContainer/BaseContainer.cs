using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using TinyERP.Common.Common.Data;
using TinyERP.Common.Common.Helper;

namespace TinyERP.Common.Common.IoC.CastleContainer
{
    public class BaseContainer : IBaseContainer
    {
        IWindsorContainer container;
        public BaseContainer()
        {
            this.container = new WindsorContainer();
        }

        public void RegisterAsSingleton<IInterface, Impl>() where IInterface : class where Impl : IInterface
        {
            this.container.Register(Component.For<IInterface>().ImplementedBy<Impl>().LifestyleSingleton());
        }

        public void RegisterAsTransient<IInterface, Impl>(string name="") where IInterface : class where Impl : IInterface
        {
            if (string.IsNullOrWhiteSpace(name)) {
                name = typeof(IInterface).Name + "__" + typeof(Impl).Name;
            }
            this.container.Register(Component.For<IInterface>().ImplementedBy<Impl>().LifestyleTransient().Named(name));
        }        

        public TResult Resolve<TResult>(object[] args = null) where TResult : class
        {
            //Arguments winsorArg = Arguments.FromTyped(args);
            if (args == null || args.Length == 0)
            {
                return this.container.Resolve<TResult>();
            }
            Arguments winsorArg = new Arguments();
            for (int index = 0; index < args.Length; index++)
            {
                if (args[index] == null)
                {
                    continue;
                }
                IList<Type> types = AssemblyHelper.GetInterfaces(args[index]);
                foreach (Type item in types)
                {
                    winsorArg.AddTyped(item, args[index]);
                }
            }
            return this.container.Resolve<TResult>(winsorArg);
        }
    }
}