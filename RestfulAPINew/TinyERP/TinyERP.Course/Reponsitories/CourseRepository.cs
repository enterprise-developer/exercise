using System.Linq;
using TinyERP.Course.Context;

namespace TinyERP.Course.Reponsitories
{
    public class CourseRepository
    {
        public TinyERP.Course.Entities.Course GetByName(string name)
        {
            CourseContext context = new CourseContext();

            return context.Courses.FirstOrDefault(item => item.Name == name);
        }

        public TinyERP.Course.Entities.Course Create(TinyERP.Course.Entities.Course course)
        {
            CourseContext context = new CourseContext();
            context.Courses.Add(course);
            context.SaveChanges();
            return course;            
        }

    }
}
