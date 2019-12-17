namespace TinyERP.Common.Common.IoC
{
    using System.Collections.Generic;
    public interface IBaseContainer
    {
        TResult Resolve<TResult>(object[] args = null) where TResult : class;
        IList<TResult> ResolveAll<TResult>(object[] args = null) where TResult : class;
        void RegisterAsSingleton<IInterface, Impl>() where Impl : IInterface where IInterface : class;
        void RegisterAsTransient<IInterface, Impl>(string name="") where IInterface : class where Impl : IInterface;
    }
}