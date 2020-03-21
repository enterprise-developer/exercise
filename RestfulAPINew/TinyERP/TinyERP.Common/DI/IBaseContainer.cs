namespace TinyERP.Common.DI
{
    public interface IBaseContainer
    {
        IInterface Resolve<IInterface>() where IInterface : class;
        void RegisterTransient<IInterface, IImpl>() where IInterface : class where IImpl : IInterface;
    }
}
