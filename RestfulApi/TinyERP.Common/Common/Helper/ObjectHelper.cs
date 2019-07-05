using System;
using System.Reflection;
using TinyERP.Common.Attribute;

namespace TinyERP.Common.Common.Helper
{
    public static class ObjectHelper
    {
        internal static TAtt GetAttribute<TAtt>(Type type) where TAtt: System.Attribute
        {
            return type.GetCustomAttribute<TAtt>();
        }
    }
}
