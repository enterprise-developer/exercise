namespace TinyERP.Common.Data.MongoDb
{
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using System.Linq;

    internal class MongoDbSet<TEntity> : IDbSet<TEntity> where TEntity: class
    {
        private MongoCollection<TEntity> Collection { get; set; }
        public MongoDbSet(MongoCollection<TEntity> collection)
        {
            this.Collection = collection;
        }

        public void Add(TEntity entity)
        {
            this.Collection.Insert(entity);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return this.Collection.AsQueryable();
        }
    }
}
