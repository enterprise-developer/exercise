namespace TinyERP.Common.DI
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using TinyERP.Common.Contexts;

    internal class WindsorContainer : IBaseContainer
    {
        private IWindsorContainer container;
        public WindsorContainer()
        {
            this.container = new Castle.Windsor.WindsorContainer();
        }

        public void RegisterSingleton<IInterface, IImpl>()
            where IInterface : class
            where IImpl : IInterface
        {
            this.container.Register(Component.For<IInterface>().ImplementedBy<IImpl>().LifestyleSingleton());
        }

        public void RegisterTransient<IInterface, IImpl>()
            where IInterface : class
            where IImpl : IInterface
        {
            this.container.Register(Component.For<IInterface>().ImplementedBy<IImpl>().LifestyleTransient());
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
    }
}
