using System;
using TinyERP.Common.Repositories;

namespace TinyERP.Course.Reponsitories
{
    public interface ICourseRepository : IBaseRepository<TinyERP.Course.Entities.CourseAggregateRoot>
    {
        Entities.CourseAggregateRoot GetByName(string name);
        bool IsExistName(string name, Guid excludedId);
    }
}
