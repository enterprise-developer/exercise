using System.Linq;
using TinyERP.Common;
using TinyERP.Common.Repositories;
using TinyERP.Course.Context;

namespace TinyERP.Course.Reponsitories
{
    public class CourseRepository : BaseRepository<TinyERP.Course.Entities.Course>, ICourseRepository
    {   
        public CourseRepository(CourseContext context, ContextMode contextMode = ContextMode.Write): base(context, contextMode)
        {
        }

        public CourseRepository() : base(new CourseContext(), ContextMode.Read)
        {
        }

        public TinyERP.Course.Entities.Course GetByName(string name)
        {
            return this.AsQueryable.FirstOrDefault(item => item.Name == name);
        }

        public bool IsExistName(string name, int excludedId)
        {
            return this.AsQueryable.Any(item => item.Name.Equals(name) && item.Id != excludedId);
        }
    }
}
