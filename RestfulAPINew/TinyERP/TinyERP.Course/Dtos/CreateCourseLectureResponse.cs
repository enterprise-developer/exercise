﻿using System;
using TinyERP.Common.CQRS;

namespace TinyERP.Course.Dtos
{
    public class CreateCourseLectureResponse : IBaseResponse
    {
        public int Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid SectionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
    }
}
