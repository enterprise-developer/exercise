namespace TinyERP.Common.Data.MongoDb
{
    using MongoDB.Driver;
    using TinyERP.Common.Common.Helper;
    internal class MongoDbContext : IMongoDbContext
    {
        private MongoDatabase database;
        private MongoServer server;
        public MongoDbContext()
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
            this.server = dbClient.GetServer();
            this.database = this.server.GetDatabase("LearningMongoDb");
        }
        public void Dispose()
        {
            this.server.Disconnect();
        }

        public IDbSet<TEntity> GetDbSet<TEntity>(IOMode mode) where TEntity : class
        {
            string tableName = AttributeHelper.GetTableName(typeof(TEntity));
            var collection = this.database.GetCollection<TEntity>(tableName);
            return new MongoDbSet<TEntity>(collection);
        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
