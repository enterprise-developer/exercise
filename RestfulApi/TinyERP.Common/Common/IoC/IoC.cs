namespace TinyERP.Common.Common.IoC
{
    using TinyERP.Common.Common.IoC.CastleContainer;
    public class IoC
    {
        static IBaseContainer container;
        static IoC()
        {
            IoC.container = new BaseContainer();
        }
        public static TResult Resolve<TResult>() where TResult : class
        {
            return IoC.container.Resolve<TResult>();
        }

        public static void RegisterAsSingleton<IInterface, Impl>()
            where IInterface : class where Impl : IInterface
        {
            IoC.container.RegisterAsSingleton<IInterface, Impl>();
        }
    }
}