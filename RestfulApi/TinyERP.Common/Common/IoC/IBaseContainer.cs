namespace TinyERP.Common.Common.IoC
{
    public interface IBaseContainer
    {
        TResult Resolve<TResult>(object[] args = null) where TResult : class;
        void RegisterAsSingleton<IInterface, Impl>() where Impl : IInterface where IInterface : class;
        void RegisterAsTransient<IInterface, Impl>() where IInterface : class where Impl : IInterface;
    }
}