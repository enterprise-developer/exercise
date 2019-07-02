namespace REST.Common.IoC
{
    public interface IBaseContainer
    {
        TResult Resolve<TResult>() where TResult :class;
        void RegisterAsSingleton<IInterface, Impl>()
            where Impl : IInterface where IInterface : class;
    }
}