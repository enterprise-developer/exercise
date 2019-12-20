namespace TinyERP.Common.Data.MongoDb
{
    using MongoDB.Bson;
    using MongoDB.Kennedy;
    public abstract class BaseMongoEntity: IMongoEntity
    {
        public ObjectId _id { get; set; }
        public string _accessId { get; set; }
    }
}
