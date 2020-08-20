using TinyERP.Common.Contexts;

namespace TinyERP.Common.DI
{
    public class IoC
    {
        private static IBaseContainer container;
        static IoC()
        {
            ContainerType type = ContainerType.Windsor;
            IoC.container = ContainerFactory.Create(type);
        }
        public static IInterface Resolve<IInterface>(IBaseContext context = null) where IInterface : class
        {
            return IoC.container.Resolve<IInterface>(context);
        }
        public static void RegisterTransient<IInterface, IImpl>(string name = "") where IInterface : class where IImpl : IInterface
        {
            IoC.container.RegisterTransient<IInterface, IImpl>(name);
        }

        public static void RegisterSingleton<IInterface, IImpl>(string name = "") where IInterface : class where IImpl : IInterface
        {
            IoC.container.RegisterSingleton<IInterface, IImpl>(name);
        }
    }
}
