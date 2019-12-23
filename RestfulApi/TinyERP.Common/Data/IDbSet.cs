namespace TinyERP.Common.Data
{
    using System.Linq;
    public interface IDbSet<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        IQueryable<TEntity> AsQueryable();
    }
}
