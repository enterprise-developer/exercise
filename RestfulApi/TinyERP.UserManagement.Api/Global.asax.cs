using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TinyERP.Common;
using TinyERP.Common.Application;

namespace REST
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private IApplication app;
        public WebApiApplication()
        {
             this.app= ApplicationFactory.Create(ApplicationType.WebApi);
            this.Error += WebApiApplication_Error1;
        }

        private void WebApiApplication_Error1(object sender, EventArgs e)
        {

            //throw new NotImplementedException();
            this.app.OnErrors(((HttpApplication)sender).Context.AllErrors);
        }

        protected void Application_Start()
        {
            app.OnApplicationStarting();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            app.OnApplicationEnding();
        }

        //public void Application_Error(object sender, System.EventArgs e)
        //{
        //    Console.Write(e);
        //}
    }
}
