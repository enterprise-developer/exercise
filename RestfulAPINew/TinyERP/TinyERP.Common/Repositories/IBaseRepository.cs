namespace TinyERP.Common.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        TEntity Create(TEntity entity);
        TEntity GetById(int id, string include = "");
        void Update(TEntity entity);
    }
}
