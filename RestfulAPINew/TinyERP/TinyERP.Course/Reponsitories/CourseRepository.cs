using System.Linq;
using TinyERP.Common.Contexts;
using TinyERP.Course.Context;

namespace TinyERP.Course.Reponsitories
{
    public class CourseRepository : ICourseRepository
    {
        private CourseContext context;
        public CourseRepository(CourseContext context)
        {
            this.context = context;
        }
        public CourseRepository()
        {
            this.context = new CourseContext();
        }
        public TinyERP.Course.Entities.Course GetByName(string name)
        {
            return this.context.Courses?.FirstOrDefault(item => item.Name == name);
        }

        public TinyERP.Course.Entities.Course Create(TinyERP.Course.Entities.Course course)
        {
            this.context.Courses.Add(course);
            return course;
        }

        public bool IsExistName(string name, int excludedId)
        {
            return this.context.Courses.Any(item => item.Name.Equals(name) && item.Id != excludedId);
        }

        public void Update(Entities.Course course)
        {
            this.context.SaveChanges();
        }

        public Entities.Course GetById(int id)
        {
            return this.context.Courses.FirstOrDefault(item => item.Id == id);
        }

    }
}
