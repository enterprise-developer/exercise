using System;
using TinyERP.Common.DI;
using TinyERP.Common.Mappers;
using TinyERP.Course.Query.Dtos;
using TinyERP.Course.Query.Entities;
using TinyERP.Course.Query.Reponsitories;

namespace TinyERP.Course.Query.Services
{
    public class CourseQueryService : ICourseQueryService
    {
        public CourseDetailResponse GetCourseDetail(Guid id)
        {
            ICourseQueryRepository repository = IoC.Resolve<ICourseQueryRepository>();
            CourseDetail courseDetail = repository.GetById(id);
            CourseDetailResponse courseDetailResponse = ObjectMapper.Cast<CourseDetail, CourseDetailResponse>(courseDetail);
            return courseDetailResponse;
        }
    }
}
