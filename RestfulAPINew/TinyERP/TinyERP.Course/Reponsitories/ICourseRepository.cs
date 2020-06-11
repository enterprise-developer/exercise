using TinyERP.Common.Repositories;

namespace TinyERP.Course.Reponsitories
{
    public interface ICourseRepository : IBaseRepository<TinyERP.Course.Entities.Course>
    {
        Entities.Course GetByName(string name);
        bool IsExistName(string name, int excludedId);
    }
}
