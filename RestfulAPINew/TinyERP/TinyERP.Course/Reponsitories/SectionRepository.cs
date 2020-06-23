using TinyERP.Common;
using TinyERP.Common.Contexts;
using TinyERP.Common.Repositories;

namespace TinyERP.Course.Reponsitories
{
    internal class SectionRepository : BaseRepository<Entities.Section>, ISectionRepository
    {
        public SectionRepository(IBaseContext context, ContextMode mode = ContextMode.Write) : base(context, mode)
        {
        }
        public SectionRepository() : base() { }
    }
}
