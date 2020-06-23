using System.Threading.Tasks;
using TinyERP.Course.Dtos;

namespace TinyERP.Course.Services
{
    public interface ICourseService
    {
        Entities.Course Create(CreateCourseDto request);
        Entities.Course Update(UpdateCourseDto request);
        Task<CourseDetail> GetCourseDetail(int id);
        int CreateSection(CreateSectionDto request);
        int CreateLecture(CreateLectureDto request);
    }
}
