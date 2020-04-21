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
        public static IInterface Resolve<IInterface>() where IInterface : class
        {
            return IoC.container.Resolve<IInterface>();
        }
        public static void RegisterTransient<IInterface, IImpl>() where IInterface : class where IImpl : IInterface
        {
            IoC.container.RegisterTransient<IInterface, IImpl>();
        }

        public static void RegisterSingleton<IInterface, IImpl>() where IInterface : class where IImpl : IInterface
        {
            IoC.container.RegisterSingleton<IInterface, IImpl>();
        }
    }
}
