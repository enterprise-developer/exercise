

namespace TinyERP.Course.Data.Repositories
{
    using System.Collections.Generic;
    public interface ICourseRepository
    {
        IList<Entity.Course> GetCourses();
    }
}
