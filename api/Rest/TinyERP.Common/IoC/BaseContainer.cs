using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace TinyERP.Common.IoC
{
    public class BaseContainer : IBaseContainer
    {
        private IWindsorContainer _container;
        public BaseContainer()
        {
            this._container = new WindsorContainer();
        }
        public void RegisterAsSingleton<IInterrface, IImpl>()
            where IInterrface : class
            where IImpl : IInterrface
        {
            this._container.Register(Component.For<IInterrface>().ImplementedBy<IImpl>().LifeStyle.Singleton);
        }

        public IInterface Resolve<IInterface>()
        {
            return this._container.Resolve<IInterface>();
        }
    }
}
