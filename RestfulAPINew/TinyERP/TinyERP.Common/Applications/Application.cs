using System;
using System.Web.Http;
using TinyERP.Common.DI;
using TinyERP.Common.Exceptions;
using TinyERP.Common.Helpers;
using TinyERP.Common.Tasks;

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
            AssemblyHelper.Execute<IDatabaseMigrationTask>();
        }

        public void OnError(Exception ex)
        {
            AssemblyHelper.Execute<IApplicationErrorTask>(ex);
        }
    }
}
