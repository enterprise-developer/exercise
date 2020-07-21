using System.Threading.Tasks;
using TinyERP.Course.Dtos;

namespace TinyERP.Course.Services
{
    public interface ICourseService
    {
        CreateCourseResponse Create(CreateCourseRequest request);
        UpdateCourseResponse Update(UpdateCourseRequest request);
        Task<CourseDetail> GetCourseDetail(int id);
        CreateCourseSectionResponse CreateSection(CreateCourseSectionRequest request);
        int CreateLecture(CreateLectureDto request);
    }
}
