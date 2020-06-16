using System;
using TinyERP.Common.Attributes;
using TinyERP.Common.Entities;
using TinyERP.LoggerManagement.Context;

namespace TinyERP.LoggerManagement.Entities
{
    [DbContext(Use = typeof(LogDbContext))]
    public class Log: BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public string Message { get; set; }
    }
}
