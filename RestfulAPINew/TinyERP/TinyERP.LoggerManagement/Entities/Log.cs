using System;

namespace TinyERP.LoggerManagement.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Message { get; set; }
    }
}
