using Castle.MicroKernel.Registration;
using Castle.Windsor;

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
            this.container.Register(Component.For<IInterface>().ImplementedBy<Impl>());
        }

        public TResult Resolve<TResult>() where TResult : class
        {
            return this.container.Resolve<TResult>();
        }
    }
}