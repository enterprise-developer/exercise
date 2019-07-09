using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyERP.Common.Exception
{
    public class UnSupportException : System.Exception
    {
        public UnSupportException(string message) : base(message)
        {

        }
    }
}
