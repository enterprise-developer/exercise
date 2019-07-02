using System.Collections.Generic;
using TinyERP.Course.Dto;

namespace TinyERP.Course.Service
{
    public interface ICourseService
    {
        IList<Entity.Course> GetCourses();
        void CreateCourse(CreateCourseRequest request);
    }
}
