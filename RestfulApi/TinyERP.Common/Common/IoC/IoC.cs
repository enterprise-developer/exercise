namespace TinyERP.Common.Common.IoC
{
    using System.Collections.Generic;
    using TinyERP.Common.Common.IoC.CastleContainer;
    public class IoC
    {
        static IBaseContainer container;
        static IoC()
        {
            IoC.container = new BaseContainer();
        }
        public static TResult Resolve<TResult>(params object[] agrs) where TResult : class
        {
            return IoC.container.Resolve<TResult>(agrs);
        }

        public static IList<TResult> ResolveAll<TResult>(params object[] agrs) where TResult : class
        {
            return IoC.container.ResolveAll<TResult>(agrs);
        }

        public static void RegisterAsSingleton<IInterface, Impl>()
            where IInterface : class where Impl : IInterface
        {
            IoC.container.RegisterAsSingleton<IInterface, Impl>();
        }

        public static void RegisterAsTransient<IInterface, Impl>(string name="")
            where IInterface : class where Impl : IInterface
        {
            IoC.container.RegisterAsTransient<IInterface, Impl>(name);
        }
    }
}