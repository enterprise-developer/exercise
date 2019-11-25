namespace TinyERP.Common.Application
{
    public interface IApplication
    {
        void OnApplicationStarting();
        void OnApplicationEnding();
    }
}
