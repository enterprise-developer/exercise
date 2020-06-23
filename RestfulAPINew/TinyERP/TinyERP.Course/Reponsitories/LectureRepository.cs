using TinyERP.Common;
using TinyERP.Common.Contexts;
using TinyERP.Common.Repositories;

namespace TinyERP.Course.Reponsitories
{
    internal class LectureRepository : BaseRepository<Entities.Lecture>, ILectureRepository
    {
        public LectureRepository(IBaseContext context, ContextMode mode = ContextMode.Write) : base(context, mode) { }
        public LectureRepository() : base() { }
    }
}
