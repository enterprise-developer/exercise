namespace TinyERP.Common.DI
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    internal class WindsorContainer : IBaseContainer
    {
        private IWindsorContainer container;
        public WindsorContainer()
        {
            this.container = new Castle.Windsor.WindsorContainer();
        }
        public void RegisterTransient<IInterface, IImpl>()
            where IInterface : class
            where IImpl : IInterface
        {
            this.container.Register(Component.For<IInterface>().ImplementedBy<IImpl>().LifestyleTransient());
        }

        public IInterface Resolve<IInterface>() where IInterface : class
        {
            return this.container.Resolve<IInterface>();
        }
    }
}
