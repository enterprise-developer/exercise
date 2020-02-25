using System.Linq;
using TinyERP.Course.Context;
using TinyERP.Course.Dtos;

namespace TinyERP.Course.Reponsitories
{
    public class CourseRepository
    {
        private CourseContext Context { get; set; }
        public CourseRepository()
        {
            this.Context = new CourseContext();
        }
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

        public bool IsExistName(string name, int excludedId)
        {
            CourseContext courseContext = new CourseContext();
            return courseContext.Courses.Any(item => item.Name.Equals(name) && item.Id != excludedId);
        }

        public void Update(Entities.Course course)
        {
            this.Context.SaveChanges();
        }

        public Entities.Course GetById(int id)
        {
            CourseContext context = new CourseContext();
            return context.Courses.FirstOrDefault(item => item.Id == id);
        }

    }
}
