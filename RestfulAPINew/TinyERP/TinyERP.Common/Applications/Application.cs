using System.Web.Http;
using TinyERP.Common.DI;
using TinyERP.Common.Helpers;
using TinyERP.Common.Tasks;
using TinyERP.UserManagement.Share.Facade;

namespace TinyERP.Common.Applications
{
    public class Application : IApplication
    {
        public void OnInit()
        {
            AssemblyHelper.Execute<IApplicationInitTask>();
            AssemblyHelper.Execute<IConfigWebApiTask>(GlobalConfiguration.Configuration);
        }

        public void OnStart()
        {
            AssemblyHelper.Execute<IApplicationStartTask>();
        }
    }
}
