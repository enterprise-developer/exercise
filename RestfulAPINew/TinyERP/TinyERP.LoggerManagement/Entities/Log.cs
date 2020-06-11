using System;
using TinyERP.Common.Entities;

namespace TinyERP.LoggerManagement.Entities
{
    public class Log: BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public string Message { get; set; }
    }
}
