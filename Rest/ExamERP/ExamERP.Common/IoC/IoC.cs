namespace ExamERP.Common.IoC
{
    public class IoC
    {
        public static BaseContainer Container;

        public IoC()
        {
            IoC.Container = new BaseContainer();
        }
    }
}
