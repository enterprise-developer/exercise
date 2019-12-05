using System;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace REST
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new LogExceptionFilterAttribute());
        }
    }

    //public class LogExceptionFilterAttribute : ExceptionFilterAttribute
    //{
    //    public override void OnException(HttpActionExecutedContext context)
    //    {
    //        Console.WriteLine(context);
    //    }
    //}
}
