using System;
using System.Runtime.Remoting.Channels;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TinyERP.Common.Applications;
using TinyERP.Common.Helpers;
using TinyERP.Common.Tasks;

namespace TinyERP.Course.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private IApplication app;
        public WebApiApplication()
        {
            this.app = new Application();
            this.Error += ApplicationError;
        }

        protected void Application_Start()
        {
            this.app.OnInit();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.EnsureInitialized();
            this.app.OnStart();
        }

        protected void ApplicationError(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            this.app.OnError(ex);
        }
    }
}
