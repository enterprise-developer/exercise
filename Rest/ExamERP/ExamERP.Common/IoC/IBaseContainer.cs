namespace ExamERP.Common.IoC
{
    public interface IBaseContainer
    {
        IInterface Resolve<IInterface>();
        void RegisterAsSingleton<IInterface, IImplement>() where IImplement : IInterface
            where IInterface : class;
    }
}
