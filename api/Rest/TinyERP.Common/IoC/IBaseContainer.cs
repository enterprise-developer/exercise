namespace TinyERP.Common.IoC
{
    public interface IBaseContainer
    {
        IInterface Resolve<IInterface>();
        void RegisterAsSingleton<IInterrface, IImpl>() 
                where IInterrface : class 
                where IImpl : IInterrface;
    }
}
