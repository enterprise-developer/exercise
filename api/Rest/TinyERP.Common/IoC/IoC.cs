namespace TinyERP.Common.IoC
{
    public class IoC
    {
        public static IBaseContainer Container;
        static IoC()
        {
            IoC.Container = new BaseContainer();
        }
    }
}
