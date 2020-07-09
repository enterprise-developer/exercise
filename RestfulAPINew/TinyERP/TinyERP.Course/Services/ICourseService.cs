using System.Threading.Tasks;
using TinyERP.Course.Dtos;

namespace TinyERP.Course.Services
{
    public interface ICourseService
    {
        CreateCourseResponse Create(CreateCourseRequest request);
        Entities.CourseAggregateRoot Update(UpdateCourseDto request);
        Task<CourseDetail> GetCourseDetail(int id);
        int CreateSection(CreateSectionDto request);
        int CreateLecture(CreateLectureDto request);
    }
}
