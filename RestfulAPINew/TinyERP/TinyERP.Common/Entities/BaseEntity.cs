using System;
using System.ComponentModel.DataAnnotations;

namespace TinyERP.Common.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
