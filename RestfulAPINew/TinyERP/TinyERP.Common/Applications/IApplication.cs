using System;

namespace TinyERP.Common.Applications
{
    public interface IApplication
    {
        void OnStart();
        void OnInit();
        void OnError(Exception ex);
    }
}
