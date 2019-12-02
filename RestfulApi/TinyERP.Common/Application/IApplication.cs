namespace TinyERP.Common.Application
{
    using System.Collections.Generic;
    public interface IApplication
    {
        ApplicationType Type { get; }
        void OnApplicationStarting();
        void OnApplicationEnding();
        void OnErrors(IList<System.Exception> errors);
    }
}
