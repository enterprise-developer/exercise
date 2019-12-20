namespace TinyERP.Common.Common.Helper
{
    using System;
    using System.Reflection;
    public static class ObjectHelper
    {
        internal static TAtt GetAttribute<TAtt>(Type type) where TAtt: System.Attribute
        {
            return type.GetCustomAttribute<TAtt>();
        }
    }
}
