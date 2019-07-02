using System.Collections.Generic;

namespace TinyERP.Common.Common
{
    public class Paging<TEntity> : IPaging<TEntity> where TEntity : class
    {
        public IList<TEntity> Data { get; private set; }
        public PagingInfo PagingInfo { get; set; }
        public Paging()
        {
            this.PagingInfo = new PagingInfo();
        }
        public void SetData(IList<TEntity> data)
        {
            this.Data = data;
        }

        public void SetPageIndex(int index)
        {
            this.PagingInfo.Index = index;
        }

        public void SetTotalPage(int total)
        {
            this.PagingInfo.Total = total;
        }
    }
}