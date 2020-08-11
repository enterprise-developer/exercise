using System.Threading.Tasks;
using TinyERP.Course.Dtos;

namespace TinyERP.Course.Services
{
    public interface ICourseService
    {
        // CreateCourseResponse Create(CreateCourseCommand request);
        //UpdateCourseResponse Update(UpdateCourseCommand request);
        Task<CourseDetail> GetCourseDetail(int id);
        CreateCourseSectionResponse CreateSection(CreateCourseSectionRequest request);
        CreateCourseLectureResponse CreateLecture(CreateLectureRequest request);
        void MoveSectionUp(MoveCourseSectionUpRequest request);
    }
}
