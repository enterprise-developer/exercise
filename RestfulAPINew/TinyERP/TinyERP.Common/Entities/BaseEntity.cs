using System;

namespace TinyERP.Common.Entities
{
    public abstract class BaseEntity<IdType>
    {
        public IdType Id { get; set; }
    }
}
