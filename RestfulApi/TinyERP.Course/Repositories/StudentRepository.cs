
namespace TinyERP.Course.Repositories
{
    using TinyERP.Common.Common.Data;
    using TinyERP.Common.Data;

    public class StudentRepository : BaseRepository<Entity.Student>, IStudentRepository
    {
        public StudentRepository() : base()
        {

        }

        public StudentRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
