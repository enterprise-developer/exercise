namespace Application.Common.IoC
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    internal class BaseContainer : IBaseContainer
    {
        private IWindsorContainer _container;
        public BaseContainer()
        {
            this._container = new WindsorContainer();
        }

        public void RegisterAsSingleton<IInterface, IImpl>()
            where IInterface : class
            where IImpl : IInterface
        {
            this._container.Register(Component.For<IInterface>().ImplementedBy<IImpl>().LifeStyle.Singleton);
        }

        public IInterface Resolve<IInterface>()
        {
            return this._container.Resolve<IInterface>();
        }
    }
}
