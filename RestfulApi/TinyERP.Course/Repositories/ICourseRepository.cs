

namespace TinyERP.Course.Data.Repositories
{
    using System.Collections.Generic;
    using TinyERP.Common.Data;

    public interface ICourseRepository: IBaseRepository<Entity.Course>
    {
        IList<Entity.Course> GetCourses();
    }
}
