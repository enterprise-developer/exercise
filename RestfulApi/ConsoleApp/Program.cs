using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyERP.Common;
using TinyERP.Common.Application;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IApplication app = ApplicationFactory.Create(ApplicationType.Console);
            app.OnApplicationStarting();
            /// start main app heree
            /// 
            Console.WriteLine("My main app started here");
            /// 
            /// 
            app.OnApplicationEnding();

            Console.Read();
        }
    }
}
