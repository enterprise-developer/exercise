using System;

namespace TinyERP.Common.Attributes
{
    public class DbContextAttribute : Attribute
    {
        public Type Use { get; set; }
    }
}
