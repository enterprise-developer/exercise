using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace TestERP.Common.IoC
{
    public class BaseContainer : IBaseContainer
    {
        private IWindsorContainer _container;
        public BaseContainer()
        {
            this._container = new WindsorContainer();
        }
        public IInterface Resolve<IInterface>()
        {
            return this._container.Resolve<IInterface>();
        }

        public void RegisterAsSingleton<IInterface, IImplement>() where IInterface:class
            where IImplement: IInterface
        {
            this._container.Register(Component.For<IInterface>().ImplementedBy<IImplement>().LifeStyle.Singleton);
        }
    }
}
