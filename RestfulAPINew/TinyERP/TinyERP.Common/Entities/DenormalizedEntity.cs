using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TinyERP.Common.Entities
{
    public class DenormalizedEntity
    {        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Guid AggregateId { get; set; }
    }
}
