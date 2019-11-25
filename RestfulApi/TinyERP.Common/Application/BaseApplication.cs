namespace TinyERP.Common.Application
{
    using TinyERP.Common.Common.Helper;
    using TinyERP.Common.Common.Task;
    internal abstract class BaseApplication: IApplication
    {
        public virtual void OnApplicationEnding()
        {
            AssemblyHelper.Execute<IApplicationEnd>();
        }

        public virtual void OnApplicationStarting()
        {
            AssemblyHelper.Execute<IApplicationStarted>();
            AssemblyHelper.Execute<IBootStrapper>();
        }
    }
}
