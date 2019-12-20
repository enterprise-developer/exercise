namespace TinyERP.Common.Common.Helper
{
    using System;
    using TinyERP.Common.Attribute;
    public class AttributeHelper
    {
        public static string GetTableName(Type type)
        {
            TableName att = ObjectHelper.GetAttribute<TableName>(type);
            if (att==null) {
                return type.FullName;
            }
            return att.Name;
        }
    }
}
