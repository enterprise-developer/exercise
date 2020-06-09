using System.Data.Entity;
using System.Linq;
using TinyERP.Common;
using TinyERP.Course.Context;

namespace TinyERP.Course.Reponsitories
{
    public class CourseRepository : ICourseRepository
    {
        private CourseContext context;
        private ContextMode mode;
        private IDbSet<TinyERP.Course.Entities.Course> dbSet;
        protected IQueryable<TinyERP.Course.Entities.Course> AsQueryable
        {
            get
            {
                if (this.mode == ContextMode.Read)
                {
                    return dbSet.AsNoTracking();
                }
                return dbSet;
            }
        }
        public CourseRepository(CourseContext context, ContextMode contextMode = ContextMode.Write)
        {
            this.context = context;
            this.mode = contextMode;
            this.dbSet = this.context.Courses;
        }

        public CourseRepository() : this(new CourseContext(), ContextMode.Read)
        {
        }

        public TinyERP.Course.Entities.Course GetByName(string name)
        {
            return this.AsQueryable.FirstOrDefault(item => item.Name == name);
        }

        public TinyERP.Course.Entities.Course Create(TinyERP.Course.Entities.Course course)
        {
            this.dbSet.Add(course);
            return course;
        }

        public bool IsExistName(string name, int excludedId)
        {
            return this.AsQueryable.Any(item => item.Name.Equals(name) && item.Id != excludedId);
        }

        public void Update(Entities.Course course)
        {
            this.context.SaveChanges();
        }

        public Entities.Course GetById(int id)
        {
            return this.AsQueryable.FirstOrDefault(item => item.Id == id);
        }

    }
}
