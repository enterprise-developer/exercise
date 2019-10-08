namespace Application.Common.IoC
{
    public interface IBaseContainer
    {
       IInterface Resolve<IInterface>();
        void RegisterAsSingleton<IInterface, IImpl>() where IInterface : class where IImpl : IInterface;
    }
}
