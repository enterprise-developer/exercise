namespace TinyERP.Common.DI
{
    public static class ContainerFactory
    {
        public static IBaseContainer Create(ContainerType type)
        {
            switch (type)
            {
                case ContainerType.Unity:
                    return new UnityContainer();
                case ContainerType.Windsor:
                default:
                    return new WindsorContainer();
            }
        }
    }
}
