namespace TestERP.Common.IoC
{
    public interface IBaseContainer
    {
        IInterface Resolve<IInterface>();

        void RegisterAsSingleton<IInterface, IImplement>() where IInterface: class
            where IImplement: IInterface;
    }
}
