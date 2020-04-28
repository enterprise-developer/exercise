using Unity;

namespace TinyERP.Common.DI
{
    internal class UnityContainer //: IBaseContainer
    {
        private IUnityContainer container;
        public UnityContainer()
        {
            this.container = new Unity.UnityContainer();
        }

        public void RegisterSingleton<IInterface, IImpl>()
            where IInterface : class
            where IImpl : IInterface
        {
            this.container.RegisterSingleton<IInterface, IImpl>();
        }

        public void RegisterTransient<IInterface, IImpl>()
            where IInterface : class
            where IImpl : IInterface
        {
            this.container.RegisterType<IInterface, IImpl>();
        }

        public IInterface Resolve<IInterface>() where IInterface : class
        {
            return this.container.Resolve<IInterface>();
        }
    }
}
