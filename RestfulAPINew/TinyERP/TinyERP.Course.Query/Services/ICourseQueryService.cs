
using TinyERP.Course.Query.Dtos;

namespace TinyERP.Course.Query.Services
{
    public interface ICourseQueryService
    {
        CourseDetailResponse GetCourseDetail(int id);
    }
}
