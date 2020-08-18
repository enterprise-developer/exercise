using System;
using TinyERP.Common.CQRS;

namespace TinyERP.Course.Dtos
{
    public class CreateCourseResponse : IBaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
