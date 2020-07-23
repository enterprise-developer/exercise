using System.Linq;
using TinyERP.Common;
using TinyERP.Common.Contexts;
using TinyERP.Common.Repositories;

namespace TinyERP.Course.Reponsitories
{
    public class CourseRepository : BaseRepository<TinyERP.Course.Entities.CourseAggregateRoot>, ICourseRepository
    {   
        public CourseRepository(IBaseContext context, ContextMode contextMode = ContextMode.Write): base(context, contextMode)
        {
        }

        public CourseRepository() : base()
        {
        }

        public TinyERP.Course.Entities.CourseAggregateRoot GetByName(string name)
        {
            return this.dbSet.AsQueryable().FirstOrDefault(item => item.Name == name);
        }

        public bool IsExistName(string name, int excludedId)
        {
            return this.dbSet.AsQueryable().Any(item => item.Name.Equals(name) && item.Id != excludedId);
        }
    }
}
