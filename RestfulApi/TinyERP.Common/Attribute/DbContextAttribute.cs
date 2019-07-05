using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyERP.Common.Attribute
{
    public class DbContextAttribute: System.Attribute
    {
        public Type Use { get; set; }
    }
}
