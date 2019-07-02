namespace REST.Common
{
    using System.Collections.Generic;
    public interface IPaging<DataType> where DataType : class
    {
        void SetData(IList<DataType> data);
        void SetTotalPage(int total);
        void SetPageIndex(int index);
    }
}