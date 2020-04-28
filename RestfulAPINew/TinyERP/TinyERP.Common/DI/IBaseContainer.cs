using TinyERP.Common.Contexts;

namespace TinyERP.Common.DI
{
    public interface IBaseContainer
    {
        IInterface Resolve<IInterface>(IBaseContext context = null) where IInterface : class;
        void RegisterTransient<IInterface, IImpl>() where IInterface : class where IImpl : IInterface;
        void RegisterSingleton<IInterface, IImpl>() where IInterface : class where IImpl : IInterface;
    }
}
