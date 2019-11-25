namespace TinyERP.Common.Application
{
    public class ApplicationFactory
    {
        public static IApplication Create(ApplicationType type) {
            switch (type) {
                case ApplicationType.WebApi:
                    return new WebApiApplication();
                case ApplicationType.Console:
                    return new ConsoleApplication();
                default:
                    throw new System.Exception("Unsupported application type");
            }
        }
    }
}
