using TinyERP.Common.Helpers;
using TinyERP.Common.Tasks;

namespace TinyERP.Common.Applications
{
    public class Application : IApplication
    {
        public void OnStart()
        {
            AssemblyHelper.Execute<IApplicationStartTask>();
        }
    }
}
